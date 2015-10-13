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
    public partial class ReturnRental : Form
    {
        private Controller controller;
        private Invoice invoice;

        public ReturnRental(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void btnCreatAccount_Click(object sender, EventArgs e)
        {
            loadForm(new AccountForm(controller));
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDriversLicense.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            invoice = controller.lookupInvoiceForAccount(txtDriversLicense.Text);
            if (invoice != null)
            {
                loadForm(new ReturnRentalReceipt(controller, invoice,this));
            }
            else
            {
                lblMessage.Text = "No rentals found.";
            }
           
        }
    }
}
