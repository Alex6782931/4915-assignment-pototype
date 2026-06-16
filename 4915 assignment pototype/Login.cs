using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.CompilerServices;

namespace _4915_assignment_pototype
{
    public partial class Login : Form
    {
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("please fill username or password¡I", "require values is not fill in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Write sql code

            //// if login success
            ///
            //if (...)
            //{
            //    CustomerMain customer = new CustomerMain();
            //    customer.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("user name or pawwword is wrong¡I", "login unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    txtbpassword.Clear();
            //    txtbpassword.Focus();
            //}
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register();
            registerForm.Show();
        }
    }
}
