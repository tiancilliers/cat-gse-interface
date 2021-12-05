using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Interface_V2
{
    public class Config
    {
        public BaseSettings baseSettings;
        public Config(string path)
        {
            string content = File.ReadAllText(path);
            baseSettings = JsonConvert.DeserializeObject<BaseSettings>(content);
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

        public List<SensorSettings> pressure_sensors {get; set;}
        public List<SensorSettings> temperature_sensors { get; set; }
    }

    public class SensorSettings
    {
        public double diagram_position_x { get; set; }
        public double diagram_position_y { get; set; }
        public byte sensor_type { get; set; }
        public string sensor_name { get; set; }
    }
}
