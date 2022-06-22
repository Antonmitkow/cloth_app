using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cloth_app_mitkow_anton_ekz
{
    public partial class Autorization : Form
    {
        bool error = false;

        public Autorization()
        {
            InitializeComponent();
            pictureBox2.Image = Captcha(pictureBox2.Width, pictureBox2.Height);
        }

        string text_capt;
        private Bitmap Captcha(int width, int height)
        {

            Bitmap result = new Bitmap(width, height);
            Brush[] brushes = { Brushes.Red, Brushes.Blue, Brushes.Aqua };
            string text = "123567890QWERTY";
            text_capt = String.Empty;
            Graphics g = Graphics.FromImage((Image)result);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                text_capt += text[random.Next(text.Length)];
            }

            for (int i = 0; i < 4; i++)
            {
                g.DrawString(text_capt[i].ToString(), new Font("Tahoma", 50F), brushes[random.Next(brushes.Length)], new Point(i * random.Next(30, 40), random.Next(20, 40)));
            }


            for (int i = 0; i < 30; i++)
            {
                g.DrawLine(new Pen(Color.Black), random.Next(width), random.Next(height), random.Next(width), random.Next(height));
            }


            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(Network.connect);
            string query = $"Select UserID, UserLogin, UserPassword,UserRole from [User] where UserLogin = '{login}' and UserPassword = '{password}'";
            SqlCommand command = new SqlCommand(query, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dataTable);
           

            if (dataTable.Rows.Count == 1)
            {
                if (error && textBox3.Text.ToLower() == text_capt.ToLower() || !error)
                {
                    MessageBox.Show("Вы успешно зашли", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Administrator admin = new Administrator();
                    this.Hide();
                    admin.Show();
                }
            }
            else
            {
                error = true;
                MessageBox.Show("Такого аккаунта не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OnLoad(e);
            }

            if(error == true)
            {
                getErrorState();
            }
           
           

        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(118, 227, 131);
        }

        private void getErrorState()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Enabled = true;
            textBox3.Visible = true;
            pictureBox2.Visible = true;
        }

       
    }
}
