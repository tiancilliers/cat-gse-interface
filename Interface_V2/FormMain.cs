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

namespace Interface_V2
{
    public partial class FormMain : Form
    {
        GSE gse;
        Config config;
        FormManual manualEntry;
        private bool loggingEnabled = false;
        string configPath = "GSE_Config.json";

        public FormMain()
        {
            InitializeComponent();
            gse = new GSE(port1, tbxLogTX, tbxLogRX);
            manualEntry = new FormManual(gse);
            config = new Config(configPath);
            applyVisualConfig();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            updateSerialPorts();
            enableInterface(false);
        }

        private void btnPortOpen_Click(object sender, EventArgs e)
        {
            port1.PortName = (string)cbxPort.Items[cbxPort.SelectedIndex];
            try 
            { 
                port1.Open();
                tbxIdent.Text = gse.GetIdent();
                tbxVersion.Text = gse.GetVersion();
                timer1.Start();
                applyGSEConfig();
                btnPortOpen.Enabled = false;
                btnPortClose.Enabled = true;
                enableInterface(true);
            }
            catch 
            {
                port1.Close();
                MessageBox.Show("Unable to open port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (dialogConfig.ShowDialog() == DialogResult.OK)
            {
                config = new Config(configPath);
                applyVisualConfig();
                applyGSEConfig();
            }
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
            //gse.SetValveState();
        }

        private void cbxHeliumFlow_CheckedChanged(object sender, EventArgs e)
        {
            GSE.ServoData state0 = new GSE.ServoData();
            state0.servos = new ushort[16];
            for (int i = 0; i < config.baseSettings.valves.Count; i++)
            {
                state0.servos[i] = cbxHeliumFlow.Checked ? (ushort)config.baseSettings.valves[i].valve_state1_us : (ushort)config.baseSettings.valves[i].valve_state0_us;
            }
            gse.SetValveStates(state0);
        }
    }
}
