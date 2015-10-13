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
    public partial class ReturnRentalReceipt : Form
    {
        private Controller controller;
        private Invoice invoice;
        private Account account;
        private Car car;
        private Form frm;

        public ReturnRentalReceipt(Controller controller, Invoice invoice, Form frm)
        {
            this.controller = controller;
            this.invoice = invoice;
            this.frm = frm;
            account = controller.getAccount(invoice.getAccountID());
            car = controller.getCar(invoice.getCarID());
           
            InitializeComponent();
            lblLastName.Text = account.getLastName();
            lblFirstName.Text = account.getFirstName();
            lblAccountNumber.Text = account.getDriversLicense();
            lblAddress.Text = account.getAddress();
            lblCity.Text = account.getCity();
            lblState.Text = account.getState();
            lblZip.Text = account.getZip();
            lblDays.Text = invoice.getDuration();
            lblPreCost.Text = String.Format("{0:C}",Double.Parse(invoice.getPreCharge()));
            lblMake.Text = car.getMake();
            lblModel.Text = car.getModel();
            lblModelCost.Text = String.Format("{0:C}", controller.rentalModelCost(car.getRentalModel()));
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

        private void btnPay_Click(object sender, EventArgs e)
        {
            double miles;
            Double.TryParse(txtMilesDriven.Text, out miles);

            if (txtMilesDriven.Text != null && txtMilesDriven.Text != "" && Double.TryParse(lblMiles.Text, out miles) && miles > 0)
            {
                //complete invoice and make car available
                invoice.setMiles(lblMiles.Text);
                invoice.setTotal(lblTotal.Text);
                controller.updateInvoice(invoice, true);
                
                
                this.Close();
                frm.Close();

            }
            else
            {
                MessageBox.Show("You must enter in a correct value for Miles driven.");
            }
        }

        private void txtMilesDriven_TextChanged(object sender, EventArgs e)
        {
            double miles;
            lblMiles.Text = txtMilesDriven.Text;
            if (txtMilesDriven.Text != null && txtMilesDriven.Text != "" && Double.TryParse(lblMiles.Text, out miles) && miles > 0)
            {
                lblMiles.Text = txtMilesDriven.Text;
                double mileageCost = Double.Parse(lblMiles.Text) * .32;
                lblMileageCost.Text = String.Format("{0:C}", mileageCost);
                double total = mileageCost + Double.Parse(invoice.getPreCharge());
                lblTotal.Text = String.Format("{0:C}", total);
            }
            else
            {
                lblMiles.Text = "Invalid input";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
