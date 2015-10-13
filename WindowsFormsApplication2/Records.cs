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
    public partial class Records : Form
    {
        private DataSet DS = null;
        private Controller controller;

        public Records(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
            DS = controller.loadInvoices();
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
