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
    public partial class AccountForm : Form
    {
        private Controller controller;
        public AccountForm(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtDOB.Text == "" || txtDriversLicenseNumber.Text == "" || txtAddress.Text == "" || txtCity.Text == "" || txtZip.Text == "")
            {
                MessageBox.Show("Invalid input");
            } else{
                Account account = new Account(txtDriversLicenseNumber.Text, txtFName.Text, txtLName.Text, txtDOB.Text, txtAddress.Text, txtCity.Text, cmboState.SelectedItem.ToString(), txtZip.Text);
                controller.addNewAccount(account);
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtDriversLicenseNumber.Text = "";
            txtDOB.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            cmboState.SelectedIndex = 0;
            txtZip.Text = "";
        }

    }
}
