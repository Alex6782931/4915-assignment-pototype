using _4915_assignment_pototype;
using SDP_EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915_assignment_pototype
{
    public partial class User_Account : Form
    {
        public User_Account()
        {
            InitializeComponent();
        }

        private async void User_Account_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetUserAccountRecordsDataFromApiResponse();
            dataAccounts.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async Task<DataTable> GetUserAccountRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetUserAccountRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading security logs: {ex.Message}");
                return CreateEmptyAccountTable();
            }
        }

        private async void btnAccountSearch_Click(object sender, EventArgs e)
        {
            string searchUser = txtAccountSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchUser))
            {
                MessageBox.Show("Please enter a username keyword to filter accounts.");
                return;
            }
            DataTable dt = await FindUserAccountRecordsDataFromApiResponse(searchUser);
            dataAccounts.DataSource = dt;
        }

        private async Task<DataTable> FindUserAccountRecordsDataFromApiResponse(string username)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindUserAccountRecordsData?username={username}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptyAccountTable();
                }
            }
            catch (Exception) { return CreateEmptyAccountTable(); }
        }

        private async void btnAccountClear_Click(object sender, EventArgs e)
        {
            txtAccountSearch.Clear();
            DataTable dt = await GetUserAccountRecordsDataFromApiResponse();
            dataAccounts.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async void btnAccountUpdate_Click(object sender, EventArgs e)
        {
            dataAccounts.EndEdit();
            if (dataAccounts.DataSource != null) this.BindingContext[dataAccounts.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataAccounts.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Integrated Search Fallback Fix

            int rowsUpdated = await UpdateUserAccountRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} security profiles updated successfully.");
            }
        }

        private async Task<int> UpdateUserAccountRecordsToAPI(DataTable dtUpdated)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                    var listModified = new List<Dictionary<string, string>>();

                    foreach (DataRow row in dtUpdated.Rows)
                    {
                        var dict = new Dictionary<string, string>();
                        foreach (DataColumn col in dtUpdated.Columns) dict[col.ColumnName] = row[col]?.ToString() ?? "";
                        listModified.Add(dict);
                    }

                    JsonDataTable jsonDT = new JsonDataTable
                    {
                        dtAdded = "[]",
                        dtModified = JsonSerializer.Serialize(listModified, jsonOptions),
                        dtDeleted = "[]"
                    };

                    string jsonString = JsonSerializer.Serialize(jsonDT);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateUserAccountRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyAccountTable();
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                    {
                        DataRow newRow = dataTable.NewRow();
                        foreach (JsonProperty property in doc.RootElement.EnumerateObject())
                        {
                            if (dataTable.Columns.Contains(property.Name)) newRow[property.Name] = property.Value.ToString();
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
            }
            return dataTable;
        }

        private DataTable CreateEmptyAccountTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("username", typeof(string));
            dataTable.Columns.Add("passwordHash", typeof(string));
            dataTable.Columns.Add("staffID", typeof(string));
            dataTable.Columns.Add("customerID", typeof(string)); // Added
            dataTable.Columns.Add("accessLevel", typeof(string));
            return dataTable;
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
    }

    public class JsonDataTable
    {
        public string dtAdded { get; set; }
        public string dtModified { get; set; }
        public string dtDeleted { get; set; }
    }
}