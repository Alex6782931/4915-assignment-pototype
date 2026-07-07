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
using System.Net;
using System.Net.Security;

namespace _4915_assignment_pototype
{
    public partial class MessagesForm : Form
    {
        // Update this line to use the HTTP port listed in your console
        private string baseUrl = "http://localhost:5262/api/SimpleGetAPI";
        private int currentLoggedInStaffID = 1;

        public MessagesForm()
        {
            // Bypasses the certificate validation to avoid the mismatch error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            InitializeComponent();
        }

        private async void MessagesForm_Load(object sender, EventArgs e)
        {
            await LoadMessages();
            await LoadStaffList();
        }

        private async Task LoadMessages()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync($"{baseUrl}/GetMessagesForStaff?staffId={currentLoggedInStaffID}");
                dgvMessages.DataSource = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked! Starting send process...");

            try
            {
                // Debug: Show what we are sending
                string receiverID = cmbStaffList.SelectedValue?.ToString();
                MessageBox.Show("Sending to: " + receiverID + " | Message: " + txtMessageBody.Text);

                var messageData = new
                {
                    SenderID = "1",
                    ReceiverID = receiverID,
                    Content = txtMessageBody.Text
                };

                string json = JsonSerializer.Serialize(messageData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsync($"{baseUrl}/SendMessage", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Message sent successfully!");
                        txtMessageBody.Clear();
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Server Error: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error: " + ex.Message);
            }
        }

        private async Task LoadStaffList()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Use the HTTP port you confirmed works
                    string json = await client.GetStringAsync("http://localhost:5262/api/SimpleGetAPI/GetAllStaffData");

                    // Deserialize into the Dictionary list first
                    var rawList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);

                    // Convert Dictionaries to a list of Staff objects
                    var staffList = rawList.Select(d => new Staff
                    {
                        fullName = d.ContainsKey("fullName") ? d["fullName"] : "Unknown",
                        staffID = d.ContainsKey("staffID") ? d["staffID"] : "0"
                    }).ToList();

                    // Clear and bind
                    cmbStaffList.DataSource = null;
                    cmbStaffList.DataSource = staffList;
                    cmbStaffList.DisplayMember = "fullName";
                    cmbStaffList.ValueMember = "staffID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Binding Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Find the hidden main menu that is already running and bring it back to the screen
            Form mainForm = Application.OpenForms["staffMain"];
            if (mainForm != null)
            {
                mainForm.Show();
            }

            // Close the current table form cleanly
            this.Close();
        }

        public class Staff
        {
            public string fullName { get; set; }
            public string staffID { get; set; }
        }
    }
}