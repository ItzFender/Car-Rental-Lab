using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Account
    {
        //Variables
        private String firstName;
        private String lastName;
        private String DOB;
        private String driversLicense;
        private String address;
        private String city;
        private String state;
        private String zip;

        public Account(string aDriversLicense, string aFirstName, string aLastName, string aDOB, string aAddress, string aCity, string aState, string aZip)
        {
            this.firstName = aFirstName;
            this.lastName = aLastName;
            this.DOB = aDOB;
            this.driversLicense = aDriversLicense;
            this.address = aAddress;
            this.city = aCity;
            this.state = aState;
            this.zip = aZip;
        }

        public void setFirstName(String fName)
        {
            if (fName.Length > 50)
            {
                this.firstName = fName;
            }
        }
        public String getFirstName()
        {
            return firstName;
        }
        public void setLastName(String lName)
        {
            this.lastName = lName;
        }
        public String getLastName()
        {
            return lastName;
        }
        public void setDOB(String DOB)
        {
            this.DOB = DOB;
        }
        public String getDOB()
        {
            return DOB;
        }
        public void setLicenseNumber(String aDriversLicense)
        {
            this.driversLicense = aDriversLicense;
        }
        public String getDriversLicense()
        {
            return driversLicense;
        }
        public void setAddress(String address)
        {
            this.address = address;
        }
        public String getAddress()
        {
            return address;
        }
        public void setCity(String city)
        {
            this.city = city;
        }
        public String getCity()
        {
            return city;
        }
        public void setState(String state)
        {
            this.state = state;
        }
        public String getState()
        {
            return state;
        }
        public void setZip(String zip)
        {
            this.zip = zip;
        }
        public String getZip()
        {
            return zip;
        }
        
    }
}
