using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainMenu : Form
    {
        private Controller controller;
        public MainMenu()
        {
            
            InitializeComponent();
        }

        public void setController(Controller aController)
        {
            controller = aController;
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            loadForm(new RentCar(controller));
        }

        private void loadForm(Form frm)
        {
            frm.FormClosed += new FormClosedEventHandler(frmFormClosed);
            this.Hide();

            frm.Show();
        }

        void frmFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            loadForm(new ReturnRental(controller));
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            loadForm(new Records(controller));
        }
    }
}
