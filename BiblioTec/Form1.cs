using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BiblioTec
{
    public partial class Form1 : Form
    {
        conexion SQLconex = new conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = (Height - pictureBox3.Height) / 2;
            int y = (Width - pictureBox3.Width) / 2;
            pictureBox3.Location = new Point(y, x);
            x = Height - 10 - button1.Height;
            y = Width - 10 - button1.Width;
            button1.Location = new Point(y, x);
            pictureBox4.Width = Width;
            y = pictureBox4.Height + 25;
            x = 50;
            label1.Location = new Point(x, y);
            x = label1.Width + x + 15;
            label3.Location = new Point(x, y);
            x = 50;
            y = y + label1.Height + 15;
            label2.Location = new Point(x, y);
            label3.Visible = false;
            label1.Text = "¡Bienvenido!";
            label2.Text = "¡Pase su credencial por el lector!";
            //dataGridView1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Moy")
            {
                Administracion adm = new Administracion();
                adm.Show();
                textBox1.Text = "";
            }
            else
            {
                string strFile = @"C:\BiblioTec\bdactual.xls";
                string sheetName = "34300";
                DataTable dtXLS = new DataTable(sheetName);
                try
                {

                    string strConnectionString = "";
                    if (strFile.Trim().EndsWith(".xlsx"))
                        strConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", strFile);
                    else if (strFile.Trim().EndsWith(".xls"))
                    {
                        strConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\";", strFile);
                    }
                    OleDbConnection SQLConn = new OleDbConnection(strConnectionString);
                    OleDbDataAdapter SQLAdapter = new OleDbDataAdapter();
                    string sql = "SELECT alusex, alunom, aluapp FROM [" + sheetName + "$] WHERE aluctr in ('" + textBox1.Text + "')";
                    OleDbCommand selectCMD = new OleDbCommand(sql, SQLConn);
                    //OleDbDataReader read = selectCMD.ExecuteReader();
                    SQLAdapter.SelectCommand = selectCMD;
                    DataSet objDataset1 = new DataSet();
                    SQLAdapter.Fill(objDataset1, "dtXLS");
                    DataView dvEmp = new DataView(objDataset1.Tables[0]);
                    label3.Text = Convert.ToString(objDataset1.Tables["alunom"]);
                    /*while(read.Read())
                    {

                    }*/
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    dataGridView1.DataSource = dvEmp;
                    SQLConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
