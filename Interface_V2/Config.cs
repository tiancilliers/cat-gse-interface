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
    }

    public class StateMachineSettings
    {

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

        public List<ValveSettings> valves;
        public List<SensorSettings> pressure_sensors {get; set;}
        public List<SensorSettings> temperature_sensors { get; set; }
    }

    public class SensorSettings
    {
        public double diagram_position_x { get; set; }
        public double diagram_position_y { get; set; }
        public string diagram_align { get; set; }
        public byte sensor_type { get; set; }
        public string sensor_name { get; set; }
    }

    public class ValveSettings
    {
        public string valve_name { get; set; }
        public int valve_state0_us { get; set; }
        public int valve_state1_us { get; set; }

        public double diagram_position_x { get; set; }
        public double diagram_position_y { get; set; }
        public string diagram_type { get; set; }
        public double diagram_state0_angle { get; set; }
        public double diagram_state1_angle { get; set; }
    }
}
