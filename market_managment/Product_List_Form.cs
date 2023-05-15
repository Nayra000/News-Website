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
    public partial class Product_List_Form : Form
    {
        Market_ManagmentEntities3 db = new Market_ManagmentEntities3();
        int id;
        ProductTb productTb;
        string image_path = "";
        public Product_List_Form()
        {
            InitializeComponent();
            dataGridView1.DataSource=db.ProductTbs.OrderBy(x=>x.Price).ToList();

        }

        void ClearAll()
        {
            nametxt.Text = "";
            codetxt.Text = "";
            quantitytxt.Text = "";
            pricetxt.Text = "";
            pictureBox1.ImageLocation=null;
            notestxt.Text = "";
            comboBox1.SelectedItem = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ProductTbs.Where(x => (x.Code == codetxt.Text) || (x.Name.Contains(nametxt.Text))).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ProductTbs.ToList();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            productTb =db.ProductTbs.FirstOrDefault(x=>x.Id==id);
         //   var o=db.ProductTbs.Find(id);
            if (productTb != null)
            {
                nametxt.Text = productTb.Name;
                codetxt.Text = productTb.Code;
                quantitytxt.Text = productTb.Quantity.ToString();
                pricetxt.Text=productTb.Price.ToString();
                notestxt.Text = productTb.Notes;
                pictureBox1.ImageLocation = productTb.Image;
                comboBox1.SelectedValue = productTb.Category;
              
            }

        }

        private void Product_List_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'market_ManagmentDataSet1.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.market_ManagmentDataSet1.Category);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (nametxt.Text == "" || pricetxt.Text == "" || codetxt.Text == "" || quantitytxt.Text == "" || comboBox1.SelectedValue ==null)
            {
                MessageBox.Show("You should enter the product name , price ,quantity and code and choose a category");
            }
            else if (nametxt.Text.Contains(" ") || pricetxt.Text.Contains(" ") || codetxt.Text.Contains(" ") || quantitytxt.Text.Contains(" "))
            {
                MessageBox.Show("Space is not allowed in the product name , price ,quantity and code");
            }
            else if (db.ProductTbs.Where(x=>x.Code==codetxt.Text  && id !=x.Id).Count()==1 )
            {
                MessageBox.Show("Enter another code");
            }
            else
            {
                productTb = db.ProductTbs.FirstOrDefault(x => x.Id == id);

                decimal Price = 0;
                int quan = 0;
                decimal.TryParse(pricetxt.Text, out Price);
                int.TryParse(quantitytxt.Text, out quan);
                if (Price == 0)
                    MessageBox.Show("Enter correct price");
                else if (quan == 0)
                    MessageBox.Show("Enter correct quantity");
                else
                {
                    if (image_path != "")
                    {
                        string newpath = Environment.CurrentDirectory + @"\images\products\" +productTb.Id + ".jpg";
                        File.Copy(image_path, newpath,true);
                        productTb.Image = newpath; //update only on the copy on memoey
                        db.SaveChanges();    //To update on databese
                    }
                    productTb.Name = nametxt.Text;
                    productTb.Code = codetxt.Text;
                    productTb.Notes = notestxt.Text;
                    productTb.Price = decimal.Parse(pricetxt.Text);
                    productTb.Quantity = int.Parse(quantitytxt.Text);
                    productTb.Image = pictureBox1.ImageLocation;
                    productTb.Category=int.Parse(comboBox1.SelectedValue.ToString());
                    db.SaveChanges();
                    MessageBox.Show("Update successfully");
                    dataGridView1.DataSource = db.ProductTbs.ToList();
                    ClearAll();
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

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Are you really want to delete the product ? ", "Delete", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                db.ProductTbs.Remove(productTb);
                db.SaveChanges();
                MessageBox.Show("Delete !");
                dataGridView1.DataSource = db.ProductTbs.ToList();
                ClearAll();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearAll();    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int cat_id = int.Parse(comboBox1.SelectedValue.ToString());
            dataGridView1.DataSource = db.ProductTbs.Where(x => x.Category == cat_id).ToList();
            ClearAll();
        }
    }
}
