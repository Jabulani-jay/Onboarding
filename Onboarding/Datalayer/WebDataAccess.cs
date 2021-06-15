using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Datalayer
{
    public class WebDataAccess
    {
        public String ContentConnectionString { get; set; }
        public string SqlCmd { get; set; }

        // Accessing Landing Page content
        // open connection
        // send command
        // retrieve data via Adapter
        // populate data set and return it. 
        public DataSet GetDataSet()
        {
            using (SqlConnection myConnection = new(ContentConnectionString))
            {
                myConnection.Open();
                using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);
                DataSet myDataSet = new();
                myDataAdapter.Fill(myDataSet, "DataSet");
                return myDataSet;
            };//end sqlConnection  
        }//end get
    }
}
