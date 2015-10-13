using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication2
{
    class Database
    {
        
        private string myConnectionString = "server=181.224.138.192;port=3306;uid=johngeff_cslab;pwd=cslab;database=johngeff_CSLab;";
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public void saveInvoice(Invoice invoice){
            try{
                DateTime dt = DateTime.Parse(invoice.getDate());

                string sql = "INSERT INTO Invoice (CarId, AccountId, Duration, PreCharge, Date) values(@carId, @accountId, @duration, @preCharge, @date)";
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
               
                MySqlCommand command = new MySqlCommand(sql,conn);
                command.Parameters.AddWithValue("carId", invoice.getCarID());
                command.Parameters.AddWithValue("accountId", invoice.getAccountID());
                command.Parameters.AddWithValue("duration", invoice.getDuration());
                command.Parameters.AddWithValue("preCharge", invoice.getPreCharge());
                command.Parameters.AddWithValue("date", dt.ToString("yyyy-MM-dd"));
                conn.Open();
                
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Car> loadAvailableCars()
        {
            List<Car> AvailableCars = new List<Car>();

            try
            {
                string sql = "SELECT Car.* FROM Car WHERE (Available = true)";
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                MySqlCommand command = new MySqlCommand(sql, conn);

                conn.Open();

                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        AvailableCars.Add(new Car(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return AvailableCars;
        }

        internal string getRentalModelByCar(string aCarId)
        {
            string rentalModel = "";
            try
            {
                string sql = "SELECT Car.RentalModel FROM Car WHERE (Car.Id = @carId)";
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("carId", aCarId);

                conn.Open();

                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        rentalModel =reader[0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return rentalModel;
        }

        internal Account getAccount(string aDriversLicense)
        {
            Account account = null;
            try
            {
                string sql = "SELECT Account.* FROM Account WHERE (Account.DriversLicense = @driversLicense)";
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("driversLicense", aDriversLicense);

                conn.Open();

                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        account = new Account(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return account;
        }

        internal void addNewAccount(Account account)
        {
            try
            {
                DateTime dt = DateTime.Parse(account.getDOB());
                string sql = "INSERT INTO Account (DriversLicense, FirstName, LastName, DOB, Address, City, State, Zip) values(@driversLicense, @firstName, @lastName, @dob, @address, @city, @state, @zip)";

                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("driversLicense", account.getDriversLicense());
                command.Parameters.AddWithValue("firstName", account.getFirstName());
                command.Parameters.AddWithValue("lastName", account.getLastName());
                command.Parameters.AddWithValue("dob", dt.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("address", account.getAddress());
                command.Parameters.AddWithValue("city", account.getCity());
                command.Parameters.AddWithValue("state", account.getState());
                command.Parameters.AddWithValue("zip", account.getZip());

                conn.Open();

                command.ExecuteNonQuery();

                MessageBox.Show("Added new account !!", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        internal void rentCar(string aCarId, bool available)
        {
           
            try
            {
                string sql = "UPDATE Car SET Available = @available WHERE Id = @carId";

                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("available", available);
                command.Parameters.AddWithValue("carId", aCarId);
               
                conn.Open();

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        internal Invoice lookupInvoiceForAccount(string aDriversLicense)
        {
            Invoice invoice = null;
            try
            {
                string sql = "SELECT * FROM Invoice WHERE (Total = -1 AND AccountId = @driversLicense)";
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("driversLicense", aDriversLicense);

                conn.Open();

                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        invoice = new Invoice(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return invoice;
        }

        internal Car getCar(string aCarId)
        {
            Car car = null;
            try
            {
                string sql = "SELECT Car.* FROM Car WHERE (Car.Id = @aCarId)";
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("aCarId", aCarId);

                conn.Open();

                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        car = new Car(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return car;
        }

        internal void updateInvoice(Invoice invoice)
        {
            try
            {
                string sql = "UPDATE Invoice SET Total = @total, Miles = @miles WHERE InvoiceId = @invoiceId";

                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("total", invoice.getTotal());
                command.Parameters.AddWithValue("miles", invoice.getMiles());
                command.Parameters.AddWithValue("invoiceId", invoice.getInvoiceId());


                conn.Open();

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        internal DataSet loadInvoces()
        {
            DataSet DS = null;
            try
            {
                string sql = "SELECT * FROM Invoice";
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, conn);
                conn.Open();

                DS = new DataSet();
                mySqlDataAdapter.Fill(DS);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return DS;
        }
    }

}
    

