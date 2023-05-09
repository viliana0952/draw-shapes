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
using Rectangle = Library_kr_471221012.Rectangle;

namespace kursova_rabota_471221012
{
    public partial class FormRectangle : Form
    {
        private Rectangle _rectangle;
        public Rectangle Rectangle
        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;

                textBoxWidthR.Text = _rectangle.Width.ToString();
                textBoxHeightR.Text = _rectangle.Height.ToString();
                textBoxXR.Text = _rectangle.Location.X.ToString();
                textBoxYR.Text = _rectangle.Location.Y.ToString();
                textBoxAreaR.Text = _rectangle.Area.ToString();
                buttonColorR.BackColor = _rectangle.Color;
            }
        }
        public FormRectangle()
        {
            InitializeComponent();
        }

        private void buttonOKR_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle.Width = int.Parse(textBoxWidthR.Text);
                Rectangle.Height = int.Parse(textBoxHeightR.Text);
            }
            catch
            {
                MessageBox.Show("Only positive values are allowed in the yellow textboxes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxHeightR.BackColor = Color.Yellow;
                textBoxWidthR.BackColor = Color.Yellow;
                return;
            }
            Rectangle.Color = buttonColorR.BackColor;

            DialogResult = DialogResult.OK;
        }

        private void buttonCancleR_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonColorR_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
                buttonColorR.BackColor = cd.Color;
        }
    }
}
