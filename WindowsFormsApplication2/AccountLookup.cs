using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace WindowsFormsApplication2
{
    public partial class AccountLookup : Form
    {
        private Controller controller;
        private Form frm;
        private Invoice invoice;
        private Account account;

        public AccountLookup(Controller controller, Form frm, Invoice aInvoice)
        {
            this.controller = controller;
            this.frm = frm;
            this.invoice = aInvoice;
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            account = controller.getAccount(txtDriversLicense.Text);
            Invoice checkForInvoice = controller.lookupInvoiceForAccount(txtDriversLicense.Text);

            if (account == null)
            {
                MessageBox.Show("Account could not be found");
            }
            else if (checkForInvoice != null)
            {
                MessageBox.Show("You have already rented a car that has not been returned yet.");
            }
            else {
                invoice.setAccountID(account.getDriversLicense());
                controller.saveInvoice(invoice, false);
                MessageBox.Show("Enjoy your rental", "My Application",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                frm.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
