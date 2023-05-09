using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursova_rabota_471221012
{
    public partial class FormTriangle : Form
    {

        private Triangle _triangle;
        public Triangle Triangle
        {
            get
            {
                return _triangle;
            }
            set
            {
                _triangle = value;

                textBoxHypotenuseT.Text =(_triangle.p2.X-_triangle.p1.X).ToString();
                textBoxHeightT.Text = (_triangle.p2.Y - _triangle.p3.Y).ToString();
                textBoxXT.Text = _triangle.p1.X.ToString();
                textBoxYT.Text = _triangle.p1.Y.ToString();
                textBoxAreaT.Text = _triangle.Area.ToString();
                buttonColorT.BackColor = _triangle.Color;
            }
        }
        public FormTriangle()
        {
            InitializeComponent();
        }

        private void buttonOKT_Click(object sender, EventArgs e)
        {
            Triangle.Color = buttonColorT.BackColor;

            DialogResult = DialogResult.OK;
        }

        private void buttonCancleT_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonColorT_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
                buttonColorT.BackColor = cd.Color;
        }
    }
}
