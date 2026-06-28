using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class MakeOrder : Form
    {
        public MakeOrder()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["CustomerMain"];
            mainForm.Show();
            this.Close();
        }

        private void MakeOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
