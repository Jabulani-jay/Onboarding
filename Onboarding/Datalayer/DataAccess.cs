using Onboarding.Models;
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
        public String ConnectionString { get; set; }
        public string SqlCmd { get; set; }

        // Accessing Landing Page content
        // open connection
        // send command
        // retrieve data via Adapter
        // populate data set and return it. 
        public DataSet GetDataSet()
        {
            using (SqlConnection myConnection = new(ConnectionString))
            {
                myConnection.Open();
                using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);
                DataSet myDataSet = new();
                myDataAdapter.Fill(myDataSet, "DataSet");
                return myDataSet;
            };//end sqlConnection  
        }//end get

        public DataSet Login(string email, string password)
        {
            using (SqlConnection myConnection = new(ConnectionString))
            {
                myConnection.Open();
                using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);
                DataSet myDataSet = new();
                myDataAdapter.Fill(myDataSet, "DataSet");
                return myDataSet;
            };//end sqlConnection  
        }//end get
        public bool CreateUser( User newUser )
        {
            SqlCmd = "INSERT INTO details (firstName, lastName, email, password) VALUES (@Firstname, @Lastname, @Email, @Password)";
            bool InsertData=false;
            using (SqlConnection myConnection = new(ConnectionString))
            {
                myConnection.Open();
                using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                myCommand.Parameters.AddWithValue("@firstname",Convert.ToString(newUser.Firstname));
                myCommand.Parameters.AddWithValue("@lastname", Convert.ToString(newUser.Lastname));
                myCommand.Parameters.AddWithValue("@email", Convert.ToString(newUser.UserEmail));
                myCommand.Parameters.AddWithValue("@password", Convert.ToString(newUser.Password));
                myCommand.ExecuteNonQuery();
                InsertData = true; 
            };//end sqlConnection 
            return InsertData;
        }
    }
}
