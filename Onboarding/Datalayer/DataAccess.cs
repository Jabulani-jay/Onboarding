using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.Datalayer
{
    public class DataAccess
    {
        private String ConnectionString = @"Server=.;Database=Contentdb; trusted_Connection=True";
        
        // Accessing Landing Page content
        // open connection
        // send command
        // retrieve data via Adapter
        // populate data set and return it. 
        public DataSet getLandingPageSet()
        {
            using (SqlConnection myConnection = new(ConnectionString))
            {
                myConnection.Open();
                using SqlCommand myCommand = new SqlCommand("SELECT * FROM landing_page", myConnection);
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);
                DataSet myDataSet = new();
                myDataAdapter.Fill(myDataSet, "landing_page");
                return myDataSet;
            };//end sqlConnection  
        }//end get
    }
}
