using System;
using System.Linq;
using SDP_EntityModels; // References your entity models project

namespace DatabaseAccessController
{
    public class DatabaseAccessController
    {
        // OPTION A: If you are using Entity Framework Core connected to SQL Server
        public Staff VerifyLogin(string username, string password)
        {
            using (var db = new FurnitureDbContext())
            {
                // Find staff matching the username (case-insensitive)
                var staff = db.Staffs.FirstOrDefault(s => s.Username.ToLower() == username.ToLower());

                if (staff != null)
                {
                    // To meet your "System Security" requirement, you should ideally verify a salted hash here.
                    // For a quick prototype, standard string matching works:
                    if (staff.Password == password)
                    {
                        return staff; // Returns the full staff object including their Role attribute
                    }
                }
                return null; // Invalid credentials
            }
        }
    }
}
