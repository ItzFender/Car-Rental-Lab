using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Invoice
    {
        private String invoiceID;
        private String carID;
        private String accountID;
        private String duration;
        private String preCharge;
        private String miles;
        private String total;
        private String date;

        public Invoice()
        {
            carID = null;
            accountID = null;
            duration = null;
            preCharge = null;
            miles = null;
            total = null;
            date = null;
        }

        public Invoice(string aCarID, string aDuration, string aPreCharge, string aDate) : this()
        {
            this.carID = aCarID;
            this.duration = aDuration;
            this.preCharge = aPreCharge;
            this.date = aDate;
        }

        public Invoice(string aInvoiceId, string aCarId, string aAccountId, string aDuration, string aPreCharge, string aMiles, string aTotal, string aDate)
        {
            // TODO: Complete member initialization
            this.invoiceID = aInvoiceId;
            this.carID = aCarId;
            this.accountID = aAccountId;
            this.duration = aDuration;
            this.preCharge = aPreCharge;
            this.miles = aMiles;
            this.total = aTotal;
            this.date = aDate;
        }

        public void setInvoiceID(String aInvoiceId)
        {
            this.invoiceID = aInvoiceId;
        }

        public String getInvoiceId()
        {
            return this.invoiceID;
        }


        public void setCarID(String aCarID)
        {
            this.carID = aCarID;
        }

        public String getCarID()
        {
            return this.carID;
        }


        public void setAccountID(String aAccountID)
        {
            this.accountID = aAccountID;
        }

        public String getAccountID()
        {
            return this.accountID;
        }


        public void setDuration(String aDuration)
        {
            this.duration = aDuration;
        }

        public String getDuration()
        {
            return this.duration;
        }


        public void setPreCharge(String aPreCharge)
        {
            this.preCharge = aPreCharge;
        }

        public String getPreCharge()
        {
            return this.preCharge;
        }


        public void setMiles(String aMiles)
        {
            this.miles = aMiles;
        }

        public String getMiles()
        {
            return this.miles;
        }

        public void setTotal(String aTotal)
        {
            this.total = aTotal;
        }

        public String getTotal()
        {
            return this.total;
        }


        public void setDate(String aDate)
        {
            this.date = aDate;
        }

        public String getDate()
        {
            return this.date;
        }
    }
}
