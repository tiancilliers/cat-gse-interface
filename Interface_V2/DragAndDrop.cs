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
    public partial class DragAndDrop : Control
    {
        private int testInt;

        [Description("Test Int"), Category("Data")]
        public int TestInt {
            get => this.testInt;
            set => this.testInt = value;
        }

        public DragAndDrop()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Brush b = new SolidBrush(Color.Red);
            pe.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
        }
    }
}
