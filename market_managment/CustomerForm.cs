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
    public partial class CustomerForm : Form
    {
        Market_ManagmentEntities3 db = new Market_ManagmentEntities3();
        int id;
        Customertb c;

        public CustomerForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.Customertbs.ToList();
        }
        void ClearAll()
        {
            nametxt.Text = "";
            phonetxt.Text = "";
            emailtxt.Text = "";
            addresstxt.Text = "";
            notestxt.Text = "";
            companynametxt.Text = "";
            checkBox1.Checked=false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (nametxt.Text == "" || phonetxt.Text == "")
            {
                MessageBox.Show("You must enter the name and the phone ");
            }
            else if (nametxt.Text.Contains(" ") || phonetxt.Text.Contains(" "))
            {
                MessageBox.Show("Space is not allowed in the name and the phone number ");
            }
            else if (db.Customertbs.Where(x => x.Phone == phonetxt.Text).Count()==1)
            {
                MessageBox.Show("Enter anorher phone number ");
            }
            else
            {
                Customertb customer = new Customertb();
                customer.Name = nametxt.Text;
                customer.Phone = phonetxt.Text;
                customer.Email = emailtxt.Text;
                customer.Notes = notestxt.Text;
                customer.Address = addresstxt.Text;
                customer.Company_Name = companynametxt.Text;
                customer.Is_active = checkBox1.Checked;
                db.Customertbs.Add(customer);
                db.SaveChanges();
                MessageBox.Show("A new client has been added ");
                dataGridView1.DataSource = db.Customertbs.ToList();
            }

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customertbs.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nametxt.Text;
            string phone = phonetxt.Text;
            var res = db.Customertbs.Where(x => x.Name.Contains( name) || x.Phone == phone).ToList();
            dataGridView1.DataSource = res;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            c = db.Customertbs.Find(id);
            if (c != null)
            {
                nametxt.Text = c.Name;
                phonetxt.Text = c.Phone;
                emailtxt.Text = c.Email;
                notestxt.Text = c.Notes;
                addresstxt.Text = c.Address;
                companynametxt.Text = c.Company_Name;
                checkBox1.Checked = (bool)c.Is_active;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nametxt.Text == "" || phonetxt.Text == "")
            {
                MessageBox.Show("You must enter the name and the phone ");
            }
            else if (nametxt.Text.Contains(" ") || phonetxt.Text.Contains(" "))
            {
                MessageBox.Show("Space is not allowed in the name and the phone number ");
            }
            else if (db.Customertbs.Where(x => x.Phone == phonetxt.Text).Count() == 1)
            {
                MessageBox.Show("Enter anorher phone number ");
            }
            else
            {
                c.Name = nametxt.Text;
                c.Phone = phonetxt.Text;
                c.Email = emailtxt.Text;
                c.Notes = notestxt.Text;
                c.Address = addresstxt.Text;
                c.Company_Name = companynametxt.Text;
                c.Is_active = checkBox1.Checked;
                MessageBox.Show("Update !");
                db.SaveChanges();
                dataGridView1.DataSource = db.Customertbs.ToList();

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Are you really want to delete the customer ? ", "Delete", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                db.Customertbs.Remove(c);
                db.SaveChanges();
                MessageBox.Show("Delete !");
                dataGridView1.DataSource = db.Customertbs.ToList();
            }
        }
    }
}
