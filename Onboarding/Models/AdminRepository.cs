using Newtonsoft.Json;
using Onboarding.Datalayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public class AdminRepository : IAdmin
    {
        DataAccess dataAccess = new();
        string connection = @"Server=.;Database=Users; trusted_Connection=True";
        public string DeactivateUser(int userId, int adminId)
        {
            dataAccess.ConnectionString = connection;
            dataAccess.SqlCmd = $"update Details set active ='{0}' where UserId =@id";

                dataAccess.UpdateActive(userId);
                string ResponseMsg = "User deactived";

                return ResponseMsg;
            
        }

        public string activateUser(int userId, int adminId)
        {
            dataAccess.ConnectionString = connection;
            dataAccess.SqlCmd = $"update Details set active ='{1}' where UserId =@id";
            dataAccess.UpdateActive(userId);
            string ResponseMsg = "User active";

            return ResponseMsg;
        }

        public string GetCohort(int adminId)
        {
            dataAccess.ConnectionString = connection;
            dataAccess.SqlCmd = $"select [UserId] ,[role],[firstname],[lastname],[email],[active] from Details";

            DataSet dataset= dataAccess.GetDataSet();            

            return ConvertDataSetasJSON(dataset);

        }
        
        public string AddEmail(string email, int adminId)
        {
            dataAccess.ConnectionString = connection;
            return dataAccess.AddEmail(email);
        }
        private static string ConvertDataSetasJSON(DataSet dataSet)
        {
            return JsonConvert.SerializeObject(dataSet.Tables[0]);
        }
    }
}
