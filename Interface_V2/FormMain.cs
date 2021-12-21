using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Threading;

namespace Interface_V2
{
    public partial class FormMain : Form
    {
        GSE gse;
        Config config;
        FormManual manualEntry;
        private bool loggingEnabled = false;
        string configPath = "GSE_Config.json";
        Button[] stateButtons = new Button[8];

        public FormMain()
        {
            InitializeComponent();
            gse = new GSE(port1, tbxLogTX, tbxLogRX);
            manualEntry = new FormManual(gse);
            config = new Config(configPath);
            applyVisualConfig();
            stateButtons[1] = btnState1;
            stateButtons[2] = btnState2;
            stateButtons[3] = btnState3;
            stateButtons[4] = btnState4;
            stateButtons[5] = btnState5;
            stateButtons[6] = btnState6;
            stateButtons[7] = btnState7;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            updateSerialPorts();
            enableInterface(false);
        }

        private void btnPortOpen_Click(object sender, EventArgs e)
        {
            port1.PortName = (string)cbxPort.Items[cbxPort.SelectedIndex];
            //try 
            //{ 
                port1.Open();
                tbxIdent.Text = gse.GetIdent();
                tbxVersion.Text = gse.GetVersion();
                timer1.Start();
                applyGSEConfig();
                btnPortOpen.Enabled = false;
                btnPortClose.Enabled = true;
                enableInterface(true);
            //}
            //catch 
           // {
            //    port1.Close();
            //    MessageBox.Show("Unable to open port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnPortClose_Click(object sender, EventArgs e)
        {
            port1.Close();
            timer1.Stop();
            btnPortOpen.Enabled = true;
            enableInterface(false);
            btnPortClose.Enabled = false;
            tbxIdent.Text = "";
            tbxVersion.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (port1.IsOpen)
            {
                GSE.SensorData rawTemps = gse.GetTemperatureData();
                GSE.SensorData rawPress = gse.GetPressureData();
                GSE.ServoData rawValves = gse.GetValveStates();
                systemDiagram1.temperatureData = rawTemps;
                systemDiagram1.pressureData = rawPress;
                systemDiagram1.valveData = rawValves;
                systemDiagram1.Refresh();

                if (config != null && loggingEnabled)
                {
                    int len = config.baseSettings.logging_history_points;

                    for (int i = 0; i < 6; i++)
                    {
                        chartTemp.Series[i].Points.RemoveAt(0);
                        chartTemp.Series[i].Points.AddY(rawTemps.sensors[i]);

                        chartPress.Series[i].Points.RemoveAt(0);
                        chartPress.Series[i].Points.AddY(rawPress.sensors[i]/1000);
                    }

                    chartTemp.Update();
                    chartPress.Update();
                }

            }
        }

        private void cbxPort_DropDown(object sender, EventArgs e)
        {
            updateSerialPorts();
        }

        private void updateSerialPorts()
        {
            cbxPort.Items.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                cbxPort.Items.Add(port);
            }
            cbxPort.SelectedIndex = 0;
        }

        private void enableInterface(bool state)
        {
            gbxComms.Enabled = state;
            gbxControls.Enabled = state;
            gbxLogging.Enabled = state;
            gbxOverview.Enabled = state;
            btnConfig.Enabled = state;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            config = new Config(configPath);
            applyVisualConfig();
            applyGSEConfig();
        }

        private void applyGSEConfig()
        {
            GSE.SensorTypeData pressTypes = new GSE.SensorTypeData();
            GSE.SensorTypeData tempTypes = new GSE.SensorTypeData();
            pressTypes.types = new byte[6];
            tempTypes.types = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                pressTypes.types[i] = config.baseSettings.pressure_sensors[i].sensor_type;
                tempTypes.types[i] = config.baseSettings.temperature_sensors[i].sensor_type;
            }
            gse.SetSensorType(GSE.CMD_TEMP_TYPES, tempTypes);
            gse.SetSensorType(GSE.CMD_PRESS_TYPES, pressTypes);

            GSE.ServoData state0 = new GSE.ServoData();
            state0.servos = new ushort[16];
            for (int i = 0; i < config.baseSettings.valves.Count; i++)
            {
                state0.servos[i] = (ushort)config.baseSettings.valves[i].valve_state0_us;
            }
            gse.SetValveStates(state0);

            gse.SetMachineStates(GSE.CMD_SET_FUEL_STATES, loadStates(config.baseSettings.fuel_state_machine));
            gse.SetMachineStates(GSE.CMD_SET_OX_STATES, loadStates(config.baseSettings.oxidizer_state_machine));
            gse.ResetState();

            RefreshButtons();
        }

        private GSE.StateNode[] loadStates(StateMachineSettings cfgMachine)
        {
            GSE.StateNode[] nodes = new GSE.StateNode[8];
            for (int i = 0; i < 8; i++)
            {
                nodes[i] = new GSE.StateNode();
                if (i >= cfgMachine.states.Count) continue;
                nodes[i].state_servos = new ushort[16];
                for (int j = 0; j < cfgMachine.states[i].valve_names.Count; j++)
                {
                    int valve = config.FindServo(cfgMachine.states[i].valve_names[j]);
                    if (valve != -1) nodes[i].state_servos[valve] = config.MapServo((byte)valve, cfgMachine.states[i].valve_states[j]);
                }
                nodes[i].transitions = new GSE.StateTransition[8];
                for (int j = 0; j < cfgMachine.states[i].targets.Count; j++)
                {
                    StateTransition transition = cfgMachine.states[i].targets[j];
                    GSE.StateTransition to = new GSE.StateTransition();
                    int state = cfgMachine.FindState(transition.target_state);
                    if (state == -1) continue;
                    to.target_state = (byte)state;
                    switch (transition.trigger_type)
                    {
                        case "TRIGGER_BUTTON":
                            to.trigger_type = 1;
                            int button = config.FindButton(transition.button_name);
                            to.trigger_param1 = (uint)(button == -1 ? 0 : button);
                            break;
                        case "TRIGGER_TIMER":
                            to.trigger_type = 2;
                            to.trigger_param1 = (uint)transition.timer_delay;
                            break;
                        default:
                            to.trigger_type = 0;
                            break;
                    }
                    to.transition = new GSE.ServoKeyframe[4];
                    for (int k = 0; k < transition.transition.Count; k++)
                    {
                        to.transition[k] = new GSE.ServoKeyframe();
                        to.transition[k].delay_ms_before = (uint)transition.transition[k].delay_before;
                        int valve = config.FindServo(transition.transition[k].valve_name);
                        if (valve == -1) continue;
                        to.transition[k].servo_idx = (byte)valve;
                        to.transition[k].servo_state = config.MapServo((byte)valve, transition.transition[k].valve_state);
                    }
                    nodes[i].transitions[j] = to;
                }
            }
            return nodes;
        }

        private void applyVisualConfig()
        {
            tbxConfigIdent.Text = config.baseSettings.config_name;
            timer1.Interval = config.baseSettings.logging_interval;

            for (int i = 0; i < 6; i++)
            {
                if (config.baseSettings.temperature_sensors[i].sensor_name != "")
                    chartTemp.Series[i].Name = config.baseSettings.temperature_sensors[i].sensor_name;
                else
                    chartTemp.Series[i].Enabled = false;

                if (config.baseSettings.pressure_sensors[i].sensor_name != "")
                    chartPress.Series[i].Name = config.baseSettings.pressure_sensors[i].sensor_name;
                else
                    chartPress.Series[i].Enabled = false;

                chartPress.Series[i].Points.Clear();
                chartTemp.Series[i].Points.Clear();
                for (int j = 0; j < config.baseSettings.logging_history_points; j++)
                {
                    chartPress.Series[i].Points.AddY(0);
                    chartTemp.Series[i].Points.AddY(0);
                }
            }

            chartPress.ChartAreas[0].AxisY.Minimum = config.baseSettings.pressure_min;
            chartPress.ChartAreas[0].AxisY.Maximum = config.baseSettings.pressure_max;
            chartTemp.ChartAreas[0].AxisY.Minimum = config.baseSettings.temperature_min;
            chartTemp.ChartAreas[0].AxisY.Maximum = config.baseSettings.temperature_max;
            systemDiagram1.SetConfig(config);

            btnState1.Text = config.baseSettings.buttons[1].button_label;
            btnState2.Text = config.baseSettings.buttons[2].button_label;
            btnState3.Text = config.baseSettings.buttons[3].button_label;
            btnState4.Text = config.baseSettings.buttons[4].button_label;
            btnState5.Text = config.baseSettings.buttons[5].button_label;
            btnState6.Text = config.baseSettings.buttons[6].button_label;
            btnState7.Text = config.baseSettings.buttons[7].button_label;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            systemDiagram1.Refresh();
        }

        private void btnLogStart_Click(object sender, EventArgs e)
        {
            if (config != null)
            {
                loggingEnabled = true;
            }
        }

        private void btnLogStop_Click(object sender, EventArgs e)
        {
            loggingEnabled = false;
        }

        private void btnLogSave_Click(object sender, EventArgs e)
        {
            if (dialogLog.ShowDialog() == DialogResult.OK && config != null)
            {
                StreamWriter wr = new StreamWriter(dialogLog.FileName);
                for (int i = 0; i < config.baseSettings.logging_history_points; i++)
                {
                    wr.Write(i + ";");
                    for (int j = 0; j < 6; j++)
                    {
                        wr.Write(chartTemp.Series[j].Points.ElementAt(i).YValues[0] + ";");
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        wr.Write(chartPress.Series[j].Points.ElementAt(i).YValues[0] + ";");
                    }
                    wr.WriteLine();
                }
                wr.Close();
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            manualEntry.UpdateServoData();
            manualEntry.ShowDialog();
        }

        private void tmrPurge_Tick(object sender, EventArgs e)
        {
            tmrPurge.Enabled = false;
            btnPurgeFuel.Enabled = true;
            btnPurgeOx.Enabled = true;
            SetValveState("VALVE_OX_PURGE", 0.0);
            SetValveState("VALVE_FUEL_PURGE", 0.0);
        }

        private void cbxHeliumFlow_CheckedChanged(object sender, EventArgs e)
        {
            SetValveState("VALVE_HE_BLEED", cbxHeliumFlow.Checked ? 1.0 : 0.0);
            //SetValveState("VALVE_OX_VENT", cbxHeliumFlow.Checked ? 1.0 : 0.0);
            //SetValveState("VALVE_FUEL_VENT", cbxHeliumFlow.Checked ? 1.0 : 0.0);
        }

        private void btnPurgeOx_Click(object sender, EventArgs e)
        {
            SetValveState("VALVE_OX_PURGE", 1.0);
            tmrPurge.Enabled = true;
            btnPurgeFuel.Enabled = false;
            btnPurgeOx.Enabled = false;
        }

        private void SetValveState(string valve, double state)
        {
            int servoID = config.FindServo(valve);
            if (servoID == -1) return;
            gse.SetValveState((byte)servoID, (int)(config.baseSettings.valves[servoID].valve_state1_us*state + (config.baseSettings.valves[servoID].valve_state0_us) *(1-state)));
        }

        private void btnPurgeFuel_Click(object sender, EventArgs e)
        {
            SetValveState("VALVE_FUEL_PURGE", 1.0);
            tmrPurge.Enabled = true;
            btnPurgeFuel.Enabled = false;
            btnPurgeOx.Enabled = false;
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            gse.Abort();
            RefreshButtons();
            btnState3.BackColor = Color.LightGreen;
            btnState4.BackColor = Color.LightGreen;
        }

        private void btnState1_Click(object sender, EventArgs e)
        {
            gse.SendButtonPressed(1);
            RefreshButtons();
            btnState1.BackColor = Color.LightGreen;
        }
        
        private void RefreshButtons() { 
        
            Thread.Sleep(50);
            byte[] states = gse.GetStates();
            //MessageBox.Show("State0: " + states[0] + ", State1: " + states[1]);
            // set only buttons that can be pressed now
            for (int i = 1; i < 8; i++)
            {
                stateButtons[i].Enabled = false;
                stateButtons[i].BackColor = Color.LightGray;
            }
            foreach (StateTransition t in config.baseSettings.fuel_state_machine.states[states[0]].targets) {
                if (t.trigger_type == "TRIGGER_BUTTON" && config.FindButton(t.button_name) != -1)
                {
                    stateButtons[config.FindButton(t.button_name)].Enabled = true;
                }
            }
            foreach (StateTransition t in config.baseSettings.oxidizer_state_machine.states[states[1]].targets)
            {
                if (t.trigger_type == "TRIGGER_BUTTON" && config.FindButton(t.button_name) != -1)
                {
                    stateButtons[config.FindButton(t.button_name)].Enabled = true;
                }
            }
        }

        private void btnState2_Click(object sender, EventArgs e)
        {
            gse.SendButtonPressed(2);
            RefreshButtons();
            btnState2.BackColor = Color.LightGreen;
        }

        private void btnState3_Click(object sender, EventArgs e)
        {
            gse.SendButtonPressed(3);
            RefreshButtons();
            btnState3.BackColor = Color.LightGreen;
        }

        private void btnState4_Click(object sender, EventArgs e)
        {
            gse.SendButtonPressed(4);
            RefreshButtons();
            btnState4.BackColor = Color.LightGreen;
        }

        private void btnState5_Click(object sender, EventArgs e)
        {
            gse.SendButtonPressed(5);
            RefreshButtons();
            btnState5.BackColor = Color.LightGreen;
        }

        private void btnState6_Click(object sender, EventArgs e)
        {
            gse.SendButtonPressed(6);
            RefreshButtons();
            btnState6.BackColor = Color.LightGreen;
        }

        private void btnState7_Click(object sender, EventArgs e)
        {
            gse.SendButtonPressed(7);
            RefreshButtons();
            btnState7.BackColor = Color.LightGreen;
        }
    }
}
