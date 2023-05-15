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
    public partial class NewUserForm : Form
    {
        Market_ManagmentEntities3 db = new Market_ManagmentEntities3();
        string image_path="";
        public NewUserForm()
        {
            InitializeComponent();
          //  MessageBox.Show(Environment.CurrentDirectory);
        }
        
        private void NewUserForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (db.Usertbs.Where(x => x.Password == passtxt.Text).ToList().Count() == 1)
            {
                MessageBox.Show("Password is invalid");
            }
            else
            { 
                Usertb user = new Usertb();
                user.Username = usertxt.Text;
                user.Password = passtxt.Text;
                db.Usertbs.Add(user);
                db.SaveChanges();
                if (image_path != "")
                {
                    string newpath = Environment.CurrentDirectory + @"\images\users\" + user.Id + ".jpg";
                    File.Copy(image_path, newpath);
                    user.Image = newpath; //update only on the copy on memoey
                    db.SaveChanges();    //To update on databese
                }
                MessageBox.Show("A new user has been added ");
                usertxt.Text = "";
                passtxt.Text = "";
                pictureBox1.Image = null;
            }
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation=dialog.FileName;
                image_path = dialog.FileName;
            }
        }

        private void usertxt_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
