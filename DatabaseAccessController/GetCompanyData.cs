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

        public DataTable GetAllCustomerData()
        {
            String sqlCmd = "SELECT * FROM customers";
            return base.GetData(sqlCmd);
        }

        public int UpdateCustomerData(DataTable dtUpdated)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dtUpdated.Rows)
            {
                sb.Append($"UPDATE `customers` SET ");
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

        public DataTable GetAllOrderData()
        {
            String sqlCmd = "SELECT * FROM orders";
            return base.GetData(sqlCmd);
        }

    } 
}
