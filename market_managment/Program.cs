using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market_managment
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new UsersForm());
         //  Application.Run(new NewUserForm());
         //  Application.Run(new MainForm());
         //  Application.Run(new ProductForm());
          // Application.Run(new Product_List_Form());
          // Application.Run(new CustomerForm());
          // Application.Run(new BillForm());
        }
    }
}
