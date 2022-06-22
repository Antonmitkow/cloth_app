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
    public partial class Administrator : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        int countProduct;
        public Administrator()
        {
            InitializeComponent();

            getCountProduct();
            comboBox2.SelectedIndex = 0;
           

        }
        private void getCountProduct()
        {
            string queryForCountProduct = "Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product";
            using (SqlConnection connection = new SqlConnection(Network.connect))
            {
                connection.Open();
                adapter = new SqlDataAdapter(queryForCountProduct, connection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);

                countProduct = dataSet.Tables[0].Rows.Count;

            }
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            getCountProduct(); 
            panel1.BackColor = Color.FromArgb(118, 227, 131);
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string queryOnProduct = $"Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product where ProductName like '%"+textBox1.Text + "%' OR ProductCost like '%" + textBox1.Text + "%' OR ProductDescription like '%" + textBox1.Text + "%' OR ProductManufacturer like '%" + textBox1.Text + "%'";

            using (SqlConnection connection = new SqlConnection(Network.connect))
            {
                connection.Open();
                adapter = new SqlDataAdapter(queryOnProduct, connection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);

                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Product product = new Product(
                        dataSet.Tables[0].Rows[i][1].ToString(),
                        dataSet.Tables[0].Rows[i][2].ToString(),
                        dataSet.Tables[0].Rows[i][4].ToString(),
                       Convert.ToDouble(dataSet.Tables[0].Rows[i][5].ToString()),
                       Convert.ToInt32(dataSet.Tables[0].Rows[i][6].ToString()),
                        dataSet.Tables[0].Rows[i][3].ToString(),
                        dataSet.Tables[0].Rows[i][0].ToString()
                        );
                    flowLayoutPanel1.Controls.Add(product);
                }

                label1.Text = "Количество: " + dataSet.Tables[0].Rows.Count + " из " + countProduct;

                if (flowLayoutPanel1.Controls.Count == 0)
                {
                    label5.BackColor = Color.Red;
                    label5.Text = "Ничего не найдено";
                    label5.Visible = true;
                }
                else
                {
                    label5.Visible = false;
                }
            }
            //using (SqlConnection connection = new SqlConnection(Network.connect))
            //{

            //    SqlCommand command = new SqlCommand(queryOnProduct, connection);
            //    SqlDataReader reader;
            //    connection.Open();
            //    reader = command.ExecuteReader();
            //    command.Dispose();

            //    flowLayoutPanel1.Controls.Clear();
            //    if(reader.HasRows)
            //    {
            //        while(reader.Read())
            //        {
            //            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            //            {
            //                Product product = new Product(
            //                 dataSet.Tables[0].Rows[i][1].ToString(),
            //            dataSet.Tables[0].Rows[i][2].ToString(),
            //            dataSet.Tables[0].Rows[i][4].ToString(),
            //           Convert.ToDouble(dataSet.Tables[0].Rows[i][5].ToString()),
            //           Convert.ToInt32(dataSet.Tables[0].Rows[i][6].ToString()),
            //            dataSet.Tables[0].Rows[i][3].ToString(),
            //            dataSet.Tables[0].Rows[i][0].ToString()
            //                    );
            //                flowLayoutPanel1.Controls.Add(product);
            //            }
            //        }
            //    }

            //label1.Text = "Количество: " + dataSet.Tables[0].Rows.Count + " из " + countProduct;

            //    if (flowLayoutPanel1.Controls.Count == 0)
            //    {
            //        label5.BackColor = Color.Red;
            //        label5.Text = "Ничего не найдено";
            //        label5.Visible = true;
            //    }
            //    else
            //    {
            //        label5.Visible = false;
            //    }
            //    reader.Close();
            //}
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryOnProduct = "";
            if (comboBox1.SelectedIndex == 0)
            {
            queryOnProduct = $"Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product order by ProductCost asc ";
            } 
            if (comboBox1.SelectedIndex == 1)
            {
            queryOnProduct = $"Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product order by ProductCost desc";
            }

            using (SqlConnection connection = new SqlConnection(Network.connect))
            {
                connection.Open();
                adapter = new SqlDataAdapter(queryOnProduct, connection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);

                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Product product = new Product(
                        dataSet.Tables[0].Rows[i][1].ToString(),
                        dataSet.Tables[0].Rows[i][2].ToString(),
                        dataSet.Tables[0].Rows[i][4].ToString(),
                       Convert.ToDouble(dataSet.Tables[0].Rows[i][5].ToString()),
                       Convert.ToInt32(dataSet.Tables[0].Rows[i][6].ToString()),
                        dataSet.Tables[0].Rows[i][3].ToString(),
                        dataSet.Tables[0].Rows[i][0].ToString()
                        );
                    flowLayoutPanel1.Controls.Add(product);
                }

                label1.Text = "Количество: " + dataSet.Tables[0].Rows.Count + " из " + countProduct;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryOnProduct = "";
            
            if (comboBox2.SelectedIndex == 0)
            {
                queryOnProduct = "Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                queryOnProduct = "Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product where ProductManufacturer = 'БТК Текстиль'";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                queryOnProduct = "Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product where ProductManufacturer = 'Империя ткани'";
            }
            if (comboBox2.SelectedIndex == 3)
            {
                queryOnProduct = "Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product where ProductManufacturer = 'Май Фабрик'";
            }
            if (comboBox2.SelectedIndex == 4)
            {
                queryOnProduct = "Select ProductArticleNumber,ProductName,ProductDescription,ProductPhoto,ProductManufacturer,ProductCost,ProductQuantityInStock from Product where ProductManufacturer = 'Комильфо'";
            }


            using (SqlConnection connection = new SqlConnection(Network.connect))
            {
                connection.Open();
                adapter = new SqlDataAdapter(queryOnProduct, connection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);

                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Product product = new Product(
                        dataSet.Tables[0].Rows[i][1].ToString(),
                        dataSet.Tables[0].Rows[i][2].ToString(),
                        dataSet.Tables[0].Rows[i][4].ToString(),
                       Convert.ToDouble(dataSet.Tables[0].Rows[i][5].ToString()),
                       Convert.ToInt32(dataSet.Tables[0].Rows[i][6].ToString()),
                        dataSet.Tables[0].Rows[i][3].ToString(),
                        dataSet.Tables[0].Rows[i][0].ToString()
                        );
                    flowLayoutPanel1.Controls.Add(product);
                }
               
                label1.Text = "Количество: " + dataSet.Tables[0].Rows.Count + " из " + countProduct;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autorization autorization = new Autorization();
            this.Hide();
            autorization.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductRedactor productRedactorForm =new  ProductRedactor("","","", 0, 0,"","");
            
            productRedactorForm.ShowDialog();
        }

        private void Administrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
