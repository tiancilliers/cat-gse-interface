using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace Interface_V2
{
    public class Config
    {
        public BaseSettings baseSettings;
        public Config(string path)
        {
            try
            {
                string content = File.ReadAllText(path);
                baseSettings = JsonConvert.DeserializeObject<BaseSettings>(content);
            }
            catch
            {
                MessageBox.Show("Unable to read config file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int FindServo(string servoName)
        {
            for (int i = 0; i < baseSettings.valves.Count; i++) if (servoName.Equals(baseSettings.valves[i].valve_name)) return i;
            return -1;
        }

        public int FindButton(string buttonName)
        {
            for (int i = 0; i < baseSettings.valves.Count; i++) if (buttonName.Equals(baseSettings.buttons[i].button_name)) return i;
            return -1;
        }

        public ushort MapServo(byte servo, double value)
        {
            return (ushort)Utilities.Map(value, 0, 1, baseSettings.valves[servo].valve_state0_us, baseSettings.valves[servo].valve_state1_us);
        }
    }

    public class StateKeyframe
    {
        public int delay_before { get; set; } = 0;
        public string valve_name { get; set; } = "";
        public double valve_state { get; set; } = 0;
    }

    public class StateTransition
    {
        public string trigger_type { get; set; }
        public string button_name { get; set; } = "";
        public int timer_delay { get; set; } = 0;
        public string target_state { get; set; }
        public List<StateKeyframe> transition { get; set; } = new List<StateKeyframe>();
    }

    public class StateNode
    {
        public string state_name { get; set; }
        public List<string> valve_names { get; set; } = new List<string>();
        public List<int> valve_states { get; set; } = new List<int>();
        public List<StateTransition> targets { get; set; } = new List<StateTransition>();
    }

    public class StateMachineSettings
    {
        public List<StateNode> states { get; set; }

        public int FindState(string stateName)
        {
            for (int i = 0; i < states.Count; i++) if (stateName.Equals(states[i].state_name)) return i;
            return -1;
        }
    }

    public class BaseSettings
    {
        public string config_name { get; set; }
        public int logging_history_points { get; set; }
        public int logging_interval { get; set; }
        public string diagram_path { get; set; }
        public double pressure_min { get; set; }
        public double pressure_max { get; set; }
        public double temperature_min { get; set; }
        public double temperature_max { get; set; }

        public StateMachineSettings oxidizer_state_machine { get; set; }
        public StateMachineSettings fuel_state_machine { get; set; }
        public List<ButtonSettings> buttons { get; set; }
        public List<ValveSettings> valves { get; set; }
        public List<SensorSettings> pressure_sensors {get; set;}
        public List<SensorSettings> temperature_sensors { get; set; }
    }

    public class ButtonSettings
    {
        public string button_name { get; set; } = "";
        public string button_label { get; set; } = "";
    }

    public class SensorSettings
    {
        public double diagram_position_x { get; set; } = 0;
        public double diagram_position_y { get; set; } = 0;
        public string diagram_align { get; set; } = "";
        public byte sensor_type { get; set; }
        public string sensor_name { get; set; }
    }

    public class ValveSettings
    {
        public string valve_name { get; set; }
        public int valve_state0_us { get; set; }
        public int valve_state1_us { get; set; }

        public double diagram_position_x { get; set; } = 0;
        public double diagram_position_y { get; set; } = 0;
        public string diagram_type { get; set; } = "";
        public double diagram_state0_angle { get; set; } = 0;
        public double diagram_state1_angle { get; set; } = 0;
    }
}
