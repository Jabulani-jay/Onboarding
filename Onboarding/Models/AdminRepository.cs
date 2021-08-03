using Onboarding.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public class AdminRepository : IAdmin
    {
        DataAccess dataAccess = new();
        string connection = @"Server=.;Database=Users; trusted_Connection=True";
        public string DeactivateUser(int id)
        {
            dataAccess.ConnectionString = connection;
            dataAccess.SqlCmd = $"update Details set active ='{0}' where UserId =@id";

            dataAccess.UpdateActive(id);
            string ResponseMsg = "User deactived";

            return ResponseMsg;
        }

        public string activateUser(int id)
        {
            dataAccess.ConnectionString = connection;
            dataAccess.SqlCmd = $"update Details set active ='{1}' where UserId =@id";
            dataAccess.UpdateActive(id);
            string ResponseMsg = "User active";

            return ResponseMsg;
        }
    }
}
