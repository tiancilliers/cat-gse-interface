using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_V2
{
    public partial class SystemDiagram : Control
    {
        private Image image;
        public GSE.SensorData temperatureData;
        public GSE.SensorData pressureData;
        public GSE.ServoData valveData;
        private Config config;

        public SystemDiagram()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Brush brush = new SolidBrush(Color.White);
            pe.Graphics.FillRectangle(brush, 0, 0, base.Width, base.Height);

            if (image != null) 
            {
                int imageX = 0;
                int imageY = 0;
                int imageWidth = base.Width;
                int imageHeight = base.Height;

                double potentialHeight = image.Height * ((double)base.Width / image.Width);
                double potentialWidth = image.Width * ((double)base.Height / image.Height);
                if (potentialHeight > base.Height)
                {
                    imageX = (int)(base.Width - potentialWidth) / 2;
                    imageWidth = (int)potentialWidth;
                } 
                else
                {
                    imageY = (int)(base.Height - potentialHeight) / 2;
                    imageHeight = (int)potentialHeight;
                }

                pe.Graphics.DrawImage(image, imageX, imageY, imageWidth, imageHeight);

                brush = new SolidBrush(Color.Black);
                Font font = SystemFonts.DefaultFont;

                for (int i = 0; i < 6; i++)
                {
                    /*if (temperatureData.sensors != null)
                    {
                        string text = config.baseSettings.temperature_sensors[i].sensor_name + ": " + temperatureData.sensors[i].ToString("0.00") + " K";
                        int tx = (int)(imageX + (float)imageWidth * config.baseSettings.temperature_sensors[i].diagram_position_x);
                        int ty = (int)(imageY + (float)imageHeight * config.baseSettings.temperature_sensors[i].diagram_position_y);
                        pe.Graphics.DrawString(text, font, brush, tx, ty);
                    }*/

                    if (pressureData.sensors != null)
                    {
                        string text = config.baseSettings.pressure_sensors[i].sensor_name + ": " + (pressureData.sensors[i]/1000).ToString("0.00") + " kPa";
                        int tx = (int)(imageX + (float)imageWidth * config.baseSettings.pressure_sensors[i].diagram_position_x);
                        int ty = (int)(imageY + (float)imageHeight * config.baseSettings.pressure_sensors[i].diagram_position_y);
                        StringFormat format = new StringFormat();
                        format.Alignment = config.baseSettings.pressure_sensors[i].diagram_align == "L" ? StringAlignment.Near : StringAlignment.Far;
                        pe.Graphics.DrawString(text, font, brush, tx, ty-5, format);
                    }
                }

                Pen pen = new Pen(Color.Black, 3);

                if (valveData.servos == null) return;

                for (int i = 0; i < 16 && i < config.baseSettings.valves.Count; i++)
                {
                    string type = config.baseSettings.valves[i].diagram_type;
                    int tx = (int)(imageX + (float)imageWidth * config.baseSettings.valves[i].diagram_position_x);
                    int ty = (int)(imageY + (float)imageHeight * config.baseSettings.valves[i].diagram_position_y);
                    double angle_state0 = config.baseSettings.valves[i].diagram_state0_angle;
                    double angle_state1 = config.baseSettings.valves[i].diagram_state1_angle;
                    int us_state0 = config.baseSettings.valves[i].valve_state0_us;
                    int us_state1 = config.baseSettings.valves[i].valve_state1_us;
                    double angle = Utilities.Map((double)valveData.servos[i], (double)us_state0, (double)us_state1, angle_state0, angle_state1);
                    pe.Graphics.TranslateTransform((float)tx, (float)ty);
                    pe.Graphics.RotateTransform((float)angle);
                    if (type == "I")
                    {
                        pe.Graphics.DrawLine(pen, 0, -10, 0, 10);
                    }
                    else if (type == "L")
                    {
                        pe.Graphics.DrawLine(pen, 0, 0, 0, -10);
                        pe.Graphics.DrawLine(pen, 0, 0, 10, 0);
                    }
                    pe.Graphics.ResetTransform();
                }
            }
        }

        public void SetConfig(Config config)
        {
            this.config = config;
            this.image = Image.FromFile(config.baseSettings.diagram_path);
            this.Refresh();
        }
    }
}
