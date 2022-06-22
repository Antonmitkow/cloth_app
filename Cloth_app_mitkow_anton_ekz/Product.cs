using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloth_app_mitkow_anton_ekz
{
    public partial class Product : UserControl
    {
        string title , discription,  manufacturer,    image,  article;

      

       

        

        double cost;

      

        private void Product_Click(object sender, EventArgs e)
        {
            ClickToForRedactor();
        }

        int countInStock;
        public Product(string title, string discription, string manufacturer, double cost, int countInStock, string image, string article)
        {
            InitializeComponent();

            label1.Text = title;
            label2.Text = discription;
            label3.Text += manufacturer;
            label4.Text +=cost.ToString();
            if(countInStock != 0)
            {
                label5.Text += countInStock.ToString();
            }
            else  {
                label5.Text +=  countInStock.ToString();
                panel4.BackColor = Color.Gray;
            }
            if( image != "")
            {
                pictureBox1.Image = Image.FromFile("Product/"+image);
            }
            label6.Text = article;

            this.title = title;
            this.discription = discription; this.manufacturer = manufacturer;    this.image = image;  this.article=article;
            this.cost = cost;
                this.countInStock = countInStock;
        }

        
        

        private void ClickToForRedactor()
        {
            DialogResult result = MessageBox.Show("Действительно хотите удалить/изменить товар", "Редактор", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProductRedactor productRedactorForm = new ProductRedactor(title, discription, manufacturer, cost, countInStock, image, article);
                productRedactorForm.ShowDialog();
            }
        }
    }
}
