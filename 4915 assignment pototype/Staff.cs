using _4915_assignment_pototype.staff;
using SDP_EntityModels;
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

namespace _4915_assignment_pototype
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private async void Staff_Load(object sender, EventArgs e)
        {
            DataTable dt = await GetStaffRecordsDataFromApiResponse();
            dataStaff.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async Task<DataTable> GetStaffRecordsDataFromApiResponse()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonString = await client.GetStringAsync("https://localhost:7146/api/SimpleGetAPI/GetStaffRecordsData");
                    return ParseJsonToDataTable(jsonString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff: {ex.Message}");
                return CreateEmptyStaffTable();
            }
        }

        private async void btnStaffSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtStaffSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a staff name keyword to search.");
                return;
            }
            DataTable dt = await FindStaffRecordsDataFromApiResponse(searchName);
            dataStaff.DataSource = dt;
        }

        private async Task<DataTable> FindStaffRecordsDataFromApiResponse(string fullName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://localhost:7146/api/SimpleGetAPI/FindStaffRecordsData?fullName={fullName}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        return ParseJsonToDataTable(jsonString);
                    }
                    return CreateEmptyStaffTable();
                }
            }
            catch (Exception) { return CreateEmptyStaffTable(); }
        }

        private async void btnStaffClear_Click(object sender, EventArgs e)
        {
            txtStaffSearch.Clear();
            DataTable dt = await GetStaffRecordsDataFromApiResponse();
            dataStaff.DataSource = dt;
            if (dt != null) dt.AcceptChanges();
        }

        private async void btnStaffUpdate_Click(object sender, EventArgs e)
        {
            dataStaff.EndEdit();
            if (dataStaff.DataSource != null) this.BindingContext[dataStaff.DataSource].EndCurrentEdit();

            DataTable mainTable = (DataTable)dataStaff.DataSource;
            if (mainTable == null || mainTable.Rows.Count == 0) return;

            DataTable dtChanges = mainTable.GetChanges(DataRowState.Modified);
            if (dtChanges == null) dtChanges = mainTable.Copy(); // Fallback for search mode

            int rowsUpdated = await UpdateStaffRecordsToAPI(dtChanges);
            if (rowsUpdated > 0)
            {
                mainTable.AcceptChanges();
                MessageBox.Show($"{rowsUpdated} staff listings updated successfully.");
            }
        }


        private async Task<int> UpdateStaffRecordsToAPI(DataTable dtUpdated)
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

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7146/api/SimpleGetAPI/UpdateStaffRecordsData", content);
                    if (response.IsSuccessStatusCode) return int.Parse(await response.Content.ReadAsStringAsync());
                    return 0;
                }
            }
            catch (Exception) { return 0; }
        }

        private DataTable ParseJsonToDataTable(string jsonString)
        {
            DataTable dataTable = CreateEmptyStaffTable();
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement rowElement in doc.RootElement.EnumerateArray())
                    {
                        DataRow newRow = dataTable.NewRow();
                        foreach (JsonProperty property in rowElement.EnumerateObject())
                        {
                            if (dataTable.Columns.Contains(property.Name)) newRow[property.Name] = property.Value.ToString();
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
            }
            return dataTable;
        }

        private DataTable CreateEmptyStaffTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("staffID", typeof(string));
            dataTable.Columns.Add("fullName", typeof(string));
            dataTable.Columns.Add("role", typeof(string));
            dataTable.Columns.Add("department", typeof(string));
            dataTable.Columns.Add("email", typeof(string));
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
}
