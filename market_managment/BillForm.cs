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
    public partial class BillForm : Form
    {
        Market_ManagmentEntities3 db = new Market_ManagmentEntities3();

        public BillForm()
        {
            InitializeComponent();
            comboBox1.DataSource = db.Customertbs.Where(x => x.Is_active == true).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedValue = "Id";
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'market_ManagmentDataSet2.Customertb' table. You can move, or remove it, as needed.
            this.customertbTableAdapter.Fill(this.market_ManagmentDataSet2.Customertb);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customertbTableAdapter.FillBy(this.market_ManagmentDataSet2.Customertb);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
