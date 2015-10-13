using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    static class CarRentalCompany
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            MainMenu main = new MainMenu();
            main.Visible = false;

            Controller controller = new Controller(main);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            
           Application.Run(main);
            

        }
    }
}
