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
        private Config config;

        public SystemDiagram()
        {
            InitializeComponent();
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
                        string text = config.baseSettings.pressure_sensors[i].sensor_name + ": " + pressureData.sensors[i].ToString("0.00") + " bar";
                        int tx = (int)(imageX + (float)imageWidth * config.baseSettings.pressure_sensors[i].diagram_position_x);
                        int ty = (int)(imageY + (float)imageHeight * config.baseSettings.pressure_sensors[i].diagram_position_y);
                        pe.Graphics.DrawString(text, font, brush, tx, ty);
                    }
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
