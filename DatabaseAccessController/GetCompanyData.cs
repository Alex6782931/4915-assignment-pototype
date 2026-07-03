using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseAccessController
{
    public class GetCompanyData : DatabaseController
    {
        public GetCompanyData(string connectionString) : base(connectionString) { }

        //CUSTOMIZE
        // CUSTOMIZE TABLE
        public DataTable GetCustomizeRecordsData()
        {
            String sqlCmd = "SELECT * FROM Customize";
            return base.GetData(sqlCmd);
        }
        public int UpdateCustomizeStatus(int customizeID, string newStatus)
        {
            // Sanitizing input to prevent SQL injection
            string sqlCmd = $"UPDATE Customize SET status = '{newStatus.Replace("'", "''")}' WHERE customizeID = {customizeID}";
            return base.BatchUpdate(sqlCmd);
        }
        public int InsertCustomizeRequiredData(int dID, int dQty, int lID, int lQty, string color, string size, string desc)
        {
            string sqlCmd = $@"INSERT INTO CustomizeRequired 
    (desktopMaterialID, desktopQty, legMaterialID, legQty, color, size, description) 
    VALUES ({dID}, {dQty}, {lID}, {lQty}, '{color.Replace("'", "''")}', 
    '{size.Replace("'", "''")}', '{desc.Replace("'", "''")}')";

            return base.BatchUpdate(sqlCmd); // Uses ExecuteNonQuery internally
        }

        // UPDATE INVENTORY
        public int UpdateInventoryQty(int materialID, int quantityToReduce)
        {
            string sqlCmd = $@"UPDATE inventory 
                       SET materialQty = materialQty - {quantityToReduce} 
                       WHERE materialID = {materialID}";

            return base.BatchUpdate(sqlCmd); // Uses ExecuteNonQuery internally
        }

        //LOGIN
        public DataTable GetUserAccountData(string username)
        {
            string sqlCmd = $"SELECT * FROM user_accounts WHERE username = '{username.Replace("'", "''")}'"; 
            return base.GetData(sqlCmd);
        }

        //CUSTOMER TABLE
        public DataTable GetAllCustomerData()
        {
            String sqlCmd = "SELECT * FROM customer";
            return base.GetData(sqlCmd);
        }

        public int UpdateCustomerData(DataTable dtUpdated)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dtUpdated.Rows)
            {
                sb.Append($"UPDATE `customer` SET ");
                sb.Append($"`customerName` = '{row["customerName"]}', ");
                sb.Append($"`contactLastName` = '{row["contactLastName"]}', ");
                sb.Append($"`contactFirstName` = '{row["contactFirstName"]}', ");
                sb.Append($"`phone` = '{row["phone"]}', ");
                sb.Append($"`addressLine1` = '{row["addressLine1"]}', ");
                sb.Append($"`addressLine2` = '{row["addressLine2"]}', ");
                sb.Append($"`city` = '{row["city"]}', ");
                sb.Append($"`state` = '{row["state"]}', ");
                sb.Append($"`postalCode` = '{row["postalCode"]}', ");
                sb.Append($"`country` = '{row["country"]}', "); sb.Append(
                sb.Append($"`salesRepEmployeeNumber` = {row["salesRepEmployeeNumber"]}, ")); sb.Append(
                sb.Append($"`creditLimit` = {row["creditLimit"]} ")); sb.Append(
                sb.Append($"WHERE `customerNumber` = {row["customerNumber"]}; "));
            }

            return BatchUpdate(sb.ToString());
        }

        //AFTER SERVICE TABLE
        public DataTable GetAfterServiceRecordsData()
        {
            String sqlCmd = "SELECT * FROM after_service_records";
            return base.GetData(sqlCmd);
        }


        public int UpdateAfterServiceRecordsData(DataTable dtUpdated)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dtUpdated.Rows)
            {
                sb.Append($"UPDATE `after_service_records` SET ");
                sb.Append($"`customerName` = '{row["customerName"]}', ");
                sb.Append($"`contactLastName` = '{row["contactLastName"]}', ");
                sb.Append($"`contactFirstName` = '{row["contactFirstName"]}', ");
                sb.Append($"`phone` = '{row["phone"]}', ");
                sb.Append($"`addressLine1` = '{row["addressLine1"]}', ");
                sb.Append($"`addressLine2` = '{row["addressLine2"]}', ");
                sb.Append($"`city` = '{row["city"]}', ");
                sb.Append($"`state` = '{row["state"]}', ");
                sb.Append($"`postalCode` = '{row["postalCode"]}', ");
                sb.Append($"`country` = '{row["country"]}', "); sb.Append(
                sb.Append($"`salesRepEmployeeNumber` = {row["salesRepEmployeeNumber"]}, ")); sb.Append(
                sb.Append($"`creditLimit` = {row["creditLimit"]} ")); sb.Append(
                sb.Append($"WHERE `customerNumber` = {row["customerNumber"]}; "));
            }

            return BatchUpdate(sb.ToString());
        }

        //ORDER TABLE

        public DataTable GetAllOrderData()
        {
            string sqlCmd = "SELECT * FROM orders";
            return base.GetData(sqlCmd);
        }

        //INVENTORY TABLE

        public DataTable GetAllInventoryData()
        {
            string sqlCmd = "SELECT * FROM inventory";
            return base.GetData(sqlCmd);
        }

        //PROCURMENT TABLE

        public DataTable GetAllProcurementData()
        {
            string sqlCmd = "SELECT * FROM procurements";
            return base.GetData(sqlCmd);
        }

        //STAFF TABLE

        public DataTable GetAllStaffData()
        {
            string sqlCmd = "SELECT * FROM staff";
            return base.GetData(sqlCmd);
        }

        //LOGISTICS TABLE

        public DataTable GetAllLogisticsData()
        {
            string sqlCmd = "SELECT * FROM logistics_shipments";
            return base.GetData(sqlCmd);
        }

        //PRODUCTION TABLE

        public DataTable GetAllProductionData()
        {
            string sqlCmd = "SELECT * FROM production_requests";
            return base.GetData(sqlCmd);
        }

        //SUPPLIER TABLE

        public DataTable GetSupplierRecordsData() 
        {
            String sqlCmd = "SELECT * FROM suppliers";
            return base.GetData(sqlCmd);
        }

        //USER_ACCOUNT TABLE

        public DataTable GetUserAccountRecordsData() 
        {
            String sqlCmd = "SELECT * FROM user_accounts";
            return base.GetData(sqlCmd);
        }
    }
}
