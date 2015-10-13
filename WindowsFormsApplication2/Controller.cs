using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public class Controller
    {
        private MainMenu main;
        private Database database = new Database();

        public Controller(MainMenu aMain)
        {
            this.main = aMain;
            aMain.setController(this);
        }

        public List<Car> loadAvailableCars()
        {
            List<Car> availableCars = new List<Car>();
            availableCars = database.loadAvailableCars();
            return availableCars;
        }

        internal string getRentalModelByCar(string carId)
        {
            return database.getRentalModelByCar(carId);
        }

        internal Account getAccount(string driversLicense)
        {
            return database.getAccount(driversLicense);
        }

        internal void saveInvoice(Invoice invoice, bool isAvailable)
        {
            database.saveInvoice(invoice);
            database.rentCar(invoice.getCarID(), isAvailable);
        }

        internal void updateInvoice(Invoice invoice, bool isAvailable)
        {
            database.updateInvoice(invoice);
            database.rentCar(invoice.getCarID(), isAvailable);
        }


        internal void addNewAccount(Account account)
        {
            database.addNewAccount(account);
        }

        internal Invoice lookupInvoiceForAccount(string driversLicense)
        {
            return database.lookupInvoiceForAccount(driversLicense);
        }

        internal Car getCar(string carId)
        {
            return database.getCar(carId);
        }
        internal double rentalModelCost(string carModel)
        {
            double cost = 99.99;
            switch (carModel)
            {
                case "Compact":
                    cost = 19.95;
                    break;
                case "Standard":
                    cost = 24.95;
                    break;
                case "Luxury":
                    cost = 39.00;
                    break;
            }
            return cost;
        }

        internal System.Data.DataSet loadInvoices()
        {
            return database.loadInvoces();
        }
    }
}
