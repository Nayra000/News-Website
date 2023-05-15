using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_managment
{
    public partial class UsersForm : Form
    {
        Market_ManagmentEntities3 db = new Market_ManagmentEntities3();

        public UsersForm()
        {
            InitializeComponent();
        }
        void open_Form()
        {
            Application.Run(new MainForm());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name, pass;
            name = textBox1.Text;
            pass = textBox2.Text;
            var x = db.Usertbs.Where(z => z.Username == name && z.Password == pass).Count();
            if (x ==1)
            {
                this.Close();
                Thread th = new Thread(open_Form);
                th.TrySetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Enter the username and password correctly");
            }
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
