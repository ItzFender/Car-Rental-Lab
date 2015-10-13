using System;
using System.Collections;
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
    public partial class RentCar : Form
    {

        private Controller controller;
        private List<Car> availableCars;

        public RentCar(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            availableCars = controller.loadAvailableCars();
            ArrayList cars = new ArrayList();
            for (int i = 0; i < availableCars.Count(); i++)
            {
                cars.Add(new carDisplay(availableCars[i].getMake() + " " + availableCars[i].getModel() + " | " + availableCars[i].getRentalModel(), availableCars[i].getID()));
                //cmboCar.Items[i] = availableCars[i].getModel() + " " + availableCars[i].getModel();
                //cmboCar.Items[i].Value = availableCars[i].getID();
            }
            cmboCar.DataSource = cars;
            cmboCar.DisplayMember = "display";
            cmboCar.ValueMember = "value";
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if(txtPreCharge.Text == "" || txtPreCharge.Text == "0" || txtPreCharge.Text == null){
                MessageBox.Show("You must enter and calculate fields");
            } else {
                Invoice invoice = new Invoice(cmboCar.SelectedValue.ToString(), txtDuration.Text, txtPreCharge.Text, DateTime.Today.ToString("yyyy-MM-dd"));
                loadForm(new AccountLookup(controller, this, invoice));
            }
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double RentalModel = controller.rentalModelCost(controller.getRentalModelByCar(cmboCar.SelectedValue.ToString().Trim()));
            int days;
            if (int.TryParse(txtDuration.Text, out days))
            {

            }
            else
            {
                MessageBox.Show("Days must be a number");
            }
            Double preCost = RentalModel * days;
            txtPreCharge.Text = preCost.ToString();
            
        }

        public class carDisplay
        {
            private string value;
            private string display;

            public carDisplay(string strDisplay, string strValue)
            {

                this.display = strDisplay;
                this.value = strValue;
            }

            public string Value
            {
                get
                {
                    return value;
                }
            }

            public string Display
            {

                get
                {
                    return display;
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmboCar.SelectedIndex = 0;
            txtDuration.Text = "";
            txtPreCharge.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
