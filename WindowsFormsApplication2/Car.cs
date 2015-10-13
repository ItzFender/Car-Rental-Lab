using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Car
    {
        private string id;
        private string make;
        private string model;
        private string year;
        private string rentalModel;
        private bool available;

        public Car()
        {
            //empty Constructor
        }

        public Car(string aID)
        {
            this.id = aID;
        }

        public Car(string aID, string aMake, string aModel, string aYear, string aRentalModel, string isAvailable)
        {
            this.id = aID;
            this.make = aMake;
            this.model = aModel;
            this.year = aYear;
            this.rentalModel = aRentalModel;
            if (isAvailable == "0")
            {
                this.available = false;
            }
            else
            {
                this.available = true;
            }
        }

        public void setID(string aID)
        {
            this.id = aID;
        }
        public string getID()
        {
            return this.id;
        }

        public void setMake(string aMake)
        {
            this.make = aMake;
        }
        public string getMake()
        {
            return this.make;
        }

        public void setModel(string aModel)
        {
            this.model = aModel;
        }
        public string getModel()
        {
            return this.model;
        }

        public void setYear(string aYear)
        {
            this.year = aYear;
        }
        public string getYear()
        {
            return this.year;
        }

        public void setRentalModel(string aRentalModel)
        {
            this.rentalModel = aRentalModel;
        }
        public string getRentalModel()
        {
            return this.rentalModel;
        }

        public void setAvailable(string isAvailable)
        {
            if (isAvailable == "0")
            {
                this.available = false;
            }
            else
            {
                this.available = true;
            }
        }
        public bool getAvailable()
        {
            return this.available;
        }

        public void toString()
        {
            string aString = "";
            aString += id;
            aString += " " + make;
            aString += " " + model;
            Console.WriteLine(aString);
        }
    }
}
