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
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
        }

        private void btnRback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();

        }

        private void btnRregister_Click(object sender, EventArgs e)
        {
            string user = txtbRusername.Text.Trim();
            string pass = txtbRpasswd.Text.Trim();
            string confipass = txtbRconfipasswd.Text.Trim();
        }
    }
}
