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
    public partial class FormBGFlag : Form
    {
        private Flag _flag;
        public Flag Flag
        {
            get
            {
                return _flag;
            }
            set
            {
                _flag = value;

                textBoxWidthF.Text = _flag.Width.ToString();
                textBoxHeightF.Text = _flag.Height.ToString();
                textBoxHeight3F.Text = (_flag.Height/3).ToString("0.###");
                textBoxXF.Text = _flag.Location.X.ToString();
                textBoxYF.Text = _flag.Location.Y.ToString();
                textBoxAreaF.Text = _flag.Area.ToString();
                textBoxArea3F.Text = _flag.Area2.ToString();
                textBoxTranspF.Text = _flag.Transparency.ToString();
            }
        }
        public FormBGFlag()
        {
            InitializeComponent();
        }

        private void buttonOKF_Click(object sender, EventArgs e)
        {
            var tr= int.Parse(textBoxTranspF.Text);
            if (tr > 255 || tr < 0)
            {
                MessageBox.Show("The allowed transparency is between 0 and 255", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTranspF.BackColor=Color.Yellow;
            }
            else
            {
                try
                {
                    Flag.Width = double.Parse(textBoxWidthF.Text);
                    Flag.Height = double.Parse(textBoxHeightF.Text);
                }
                catch
                {
                    MessageBox.Show("Only positive values are allowed in the yellow textboxes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxWidthF.BackColor = Color.Yellow;
                    textBoxHeightF.BackColor = Color.Yellow;
                    return;
                }
                
                Flag.Transparency = int.Parse(textBoxTranspF.Text);

                DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancleF_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
