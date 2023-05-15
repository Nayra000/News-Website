using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_managment
{
    public partial class ProductForm : Form
    {
        Market_ManagmentEntities3 db = new Market_ManagmentEntities3();
        string image_path="";

        public ProductForm()
        {
            InitializeComponent();
          
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'market_ManagmentDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.market_ManagmentDataSet.Category);
            comboBox1.SelectedItem = null;

        }
        void Clean_All()
        {
            name.Text = "";
            code.Text = "";
            price.Text = "";
            quantity.Text = "";
            notes.Text = "";
            pictureBox1.ImageLocation = null;
            comboBox1.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || price.Text == ""|| code.Text == "" || quantity.Text == "" || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("You should enter the product name , price ,quantity and code and choose a category");
            }
            else if (name.Text.Contains(" ") || price.Text.Contains(" ")  || code.Text.Contains(" ") || quantity.Text.Contains(" ") )
            {
                MessageBox.Show("Space is not allowed in the product name , price ,quantity and code");
            }
            else if (db.ProductTbs.Where(x => x.Code == code.Text ).Count() == 1)
            {
                MessageBox.Show("Enter another code");
            }
            else
            {
                decimal Price = 0;
                int quan = 0;
                decimal.TryParse(price.Text,out Price);
                int.TryParse(quantity.Text,out quan);
                if (Price == 0)
                    MessageBox.Show("Enter correct price");
                else if (quan == 0)
                    MessageBox.Show("Enter correct quantity");
                else
                {
                    ProductTb product = new ProductTb();
                    product.Name = name.Text;
                    product.Code = code.Text;
                    product.Price = Price;
                    product.Quantity = quan;
                    product.Notes = notes.Text;
                    product.Category = int.Parse(comboBox1.SelectedValue.ToString());
                    db.ProductTbs.Add(product);
                    db.SaveChanges();
                    if (image_path != "")
                    {
                        string newpath = Environment.CurrentDirectory + @"\images\products\" + product.Id + ".jpg";
                        File.Copy(image_path, newpath);
                        product.Image = newpath; //update only on the copy on memoey
                        db.SaveChanges();    //To update on databese
                    }
                    MessageBox.Show("The product has been added ");
                    Clean_All();
                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dialog.FileName;
                image_path = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clean_All();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product_List_Form product_List_Form = new Product_List_Form();
            product_List_Form.Show();
        }
    }
}
