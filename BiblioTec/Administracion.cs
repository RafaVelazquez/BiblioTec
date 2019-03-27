using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BiblioTec
{
    public partial class Administracion : Form
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void Administracion_Load(object sender, EventArgs e)
        {
            int x = Width - button1.Width - 20;
            int y = Height - button1.Height - 20;
            button1.Location = new Point(x, y);
            x = 0;
            int y2 = pictureBox4.Height;
            y = Height - y2 - (Height - y) - 20;
            tabControl1.Location = new Point(x, y2);
            x = Width;
            tabControl1.Size = new Size(x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
