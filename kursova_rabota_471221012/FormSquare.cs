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
using Square=Library_kr_471221012.Square;

namespace kursova_rabota_471221012
{
    public partial class FormSquare : Form
    {

        private Square _square;
        public Square Square
        {
            get
            {
                return _square;
            }
            set
            {
                _square = value;

                textBoxWidthS.Text = _square.a.ToString();
                textBoxXS.Text = _square.Location.X.ToString();
                textBoxYS.Text = _square.Location.Y.ToString();
                textBoxAreaS.Text = _square.Area.ToString();
                buttonColorS.BackColor = _square.Color;
            }
        }
        public FormSquare()
        {
            InitializeComponent();
        }

        private void buttonOKS_Click(object sender, EventArgs e)
        {
            try
            {
                Square.a = int.Parse(textBoxWidthS.Text);
            }
            catch
            {
                MessageBox.Show("Only positive values allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxWidthS.BackColor = Color.Yellow;
                return;
            }
            Square.Color = buttonColorS.BackColor;

            DialogResult = DialogResult.OK;
        }

        private void buttonCancleS_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonColorS_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
                buttonColorS.BackColor = cd.Color;
        }
    }
}
