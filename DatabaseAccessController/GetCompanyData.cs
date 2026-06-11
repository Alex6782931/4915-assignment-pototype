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
            String sqlCmd = "SELECT * FROM company";
            return base.GetData(sqlCmd);
        }
    }
}
