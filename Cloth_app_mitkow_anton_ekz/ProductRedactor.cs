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
    public partial class ProductRedactor : Form
    {
        public ProductRedactor(string title, string discription, string manufacturer, double cost, int countInStock, string image, string article)
        {
            InitializeComponent();
            textBox1.Text = article;
            textBox2.Text = title;
            textBox3.Text = discription;
            textBox4.Text = cost.ToString();
            textBox5.Text = countInStock.ToString();
            comboBox1.Text = manufacturer;
            if(image != "")
            {
                pictureBox2.Image = Image.FromFile("Product/" + image);
            }

        }

        private void ProductRedactor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Administrator administratorForm = new Administrator();
            this.Hide();
            administratorForm.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(textBox5.Text == "0")
            {
                DialogResult result = MessageBox.Show("Действительно хотите удалить товар","Удаление товара", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
               if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(Network.connect))
                    {
                        string queryDelete = $"delete from Product where ProductArticleNumber = '{textBox1.Text}'";
                        SqlCommand sqlCommand = new SqlCommand(queryDelete, connection);
                        connection.Open();

                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Продукт удален!");
                            this.Hide();
                        }
                        catch
                        {
                            MessageBox.Show("Артикль не найден");
                        }
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Нельзя удалить товар который есть на складе", "Ошибка удаления",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(Network.connect))
            {
                string queryOnCreateProduct = "Insert into Product(ProductArticleNumber,ProductName,ProductDescription,ProductManufacturer,ProductCost,ProductQuantityInStock) valUes(@article,@title,@description,@manufacturer,@cost,@count)";
                SqlCommand comm = new SqlCommand(queryOnCreateProduct, connection);

                comm.Parameters.AddWithValue("@article",textBox1.Text);
                comm.Parameters.AddWithValue("@title", textBox2.Text);
                comm.Parameters.AddWithValue("@description", textBox3.Text);
                comm.Parameters.AddWithValue("@manufacturer", comboBox1.Text);
                comm.Parameters.AddWithValue("@cost", textBox4.Text);
                comm.Parameters.AddWithValue("@count", textBox5.Text);
                connection.Open();

                try {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Товар добавлен");
                    Hide();
                }
                catch (InvalidCastException a)
                {
                    MessageBox.Show("Не удалось добавить товар");
                    if (a.Data == null)
                    {
                        throw;
                    }
                    else
                    {
                        // Take some action.
                    }
                }


            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(Network.connect))
            {
                
                string queryForUpdateData = "Update Product SET ProductName=@titile, ProductDescription=@description, ProductManufacturer= @manufacturer,ProductCost=@cost,ProductQuantityInStock=@count where ProductArticleNumber=@article";
                SqlCommand command =new  SqlCommand(queryForUpdateData, connection);
            
                command.Parameters.AddWithValue("@titile", textBox2.Text);
                command.Parameters.AddWithValue("@description", textBox3.Text);
                command.Parameters.AddWithValue("@manufacturer", comboBox1.Text);
                command.Parameters.AddWithValue("@cost", textBox4.Text);
                command.Parameters.AddWithValue("@count", textBox5.Text);
                command.Parameters.AddWithValue("@article", textBox1.Text);
                connection.Open();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Продукт обновлен!");
                    this.Hide();
                }
                catch(InvalidCastException a)
                {
                    MessageBox.Show("Не удалось обновить");
                    if (a.Data == null)
                    {
                        throw;
                    }
                }
                
                
            }
        }
    }
}
