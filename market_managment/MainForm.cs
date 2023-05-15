using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_managment
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUserForm f=new NewUserForm();
            f.Show();
        }

        private void editProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Product_List_Form p = new Product_List_Form();
            p.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void listProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_List_Form p=new Product_List_Form();    
            p.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customersManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm(); 
            customerForm.Show();    
        }
    }
}
