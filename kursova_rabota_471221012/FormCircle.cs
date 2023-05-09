using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_kr_471221012;
using Library_kr_471221012.Exceptions;
using Circle = Library_kr_471221012.Circle;

namespace kursova_rabota_471221012
{
    public partial class FormCircle : Form
    {

        private Circle _circle;
        public Circle Circle
        {
            get
            {
                return _circle;
            }
            set
            {
                _circle = value;

                textBoxRadiusC.Text = _circle.Radius.ToString();
                textBoxXC.Text = (_circle.Location.X+_circle.Radius).ToString();
                textBoxYC.Text = (_circle.Location.Y + _circle.Radius).ToString();
                textBoxPerimeterC.Text = _circle.Perimeter.ToString("0.###");
                textBoxAreaC.Text = _circle.Area.ToString("0.###");
                buttonColorC.BackColor = _circle.Color;
            }
        }
        public FormCircle()
        {
            InitializeComponent();
        }

        private void buttonOKC_Click(object sender, EventArgs e)
        {
            try
            {
                Circle.Radius = double.Parse(textBoxRadiusC.Text);
            }
            catch
            {
                MessageBox.Show("Only positive values allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxRadiusC.BackColor = Color.Yellow;
                return;
            }

            Circle.Color = buttonColorC.BackColor;

            DialogResult = DialogResult.OK;
        }

        private void buttonCancleC_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonColorC_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
                buttonColorC.BackColor = cd.Color;
        }
    }
}
