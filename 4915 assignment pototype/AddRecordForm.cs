using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _4915_assignment_pototype
{
    public partial class AddRecordForm : Form
    {
        public AddRecordForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var newStaff = new
            {
                StaffID = txtID.Text,
                FullName = txtName.Text,
                Role = txtRole.Text,
                Department = txtDept.Text,
                Email = txtEmail.Text
            };

            using (HttpClient client = new HttpClient())
            {
                var json = JsonSerializer.Serialize(newStaff);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/AddStaff", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Staff added successfully!");
                    this.Close(); // Close the add form
                }
                else
                {
                    MessageBox.Show("Error adding staff.");
                }
            }
        }

        private void AddRecordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
