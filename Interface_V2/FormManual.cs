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
    public partial class FormManual : Form
    {
        GSE gse;

        public FormManual(GSE gse)
        {
            InitializeComponent();
            this.gse = gse;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateServoData();
        }

        public void UpdateServoData()
        {
            GSE.ServoData states = gse.GetValveStates();
            numericUpDown2.ValueChanged -= numericUpDown2_ValueChanged;
            numericUpDown2.Value = states.servos[(int)numericUpDown1.Value];
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            gse.SetValveState((byte)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown2.Increment = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown2.Increment = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown2.Increment = 1;
        }
    }
}
