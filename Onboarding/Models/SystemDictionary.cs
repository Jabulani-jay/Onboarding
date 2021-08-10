using Newtonsoft.Json;
using Onboarding.Datalayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Models
{
    public class SystemDictionary : ISystem
    {
        string action;
        DataAccess dataAccess = new();
        string connection = @"Server=.;Database=Users; trusted_Connection=True";

        public string GetLog(int adminId)
        {
            action = $"admin {adminId} get cohort";
            dataAccess.SqlCmd = "SELECT * FROM adminActionLog";
            dataAccess.ConnectionString=connection;
            DataSet dataset = dataAccess.GetDataSet();
            dataAccess.updateLog(adminId, action);
            return JsonConvert.SerializeObject(dataset.Tables[0]);
        }
    }
}
