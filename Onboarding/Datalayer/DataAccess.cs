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
        public string ConnectionString { get; set; }
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
        public string CreateUser( User newUser )
        {
            SqlCmd = "INSERT INTO details (firstName, lastName, email, password) VALUES (@Firstname, @Lastname, @Email, @Password)";
            try
            {
                // Try to insert
                using (SqlConnection myConnection = new(ConnectionString))
                {
                    myConnection.Open();
                    using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                    myCommand.Parameters.AddWithValue("@firstname", Convert.ToString(newUser.Firstname));
                    myCommand.Parameters.AddWithValue("@lastname", Convert.ToString(newUser.Lastname));
                    myCommand.Parameters.AddWithValue("@email", Convert.ToString(newUser.UserEmail));
                    myCommand.Parameters.AddWithValue("@password", Convert.ToString(newUser.Password));
                    myCommand.ExecuteNonQuery();
                };//end sqlConnection 
                return "User created";
            }
            catch (SqlException exception)
            {
                if (exception.Number == 2627)// Cannot insert duplicate key row in object error01
                {
                    // check column where error occured

                    return "error adding user duplicate email or password found";
                } else if (exception.Number == 547)
                {
                    return "email not permitted to register";
                }
                else
                    throw ; // Throw exception if this exception is unexpected
            }
            
        }
        public string PasswordReset(string email, string password)
        {
            string message;
            using (SqlConnection myConnection = new(ConnectionString))
            {
                myConnection.Open();
                using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.Parameters.AddWithValue("@password",password);
                myCommand.ExecuteNonQuery();
                message= "password changed";
            };//end sqlConnection 
            return message;
        }
        public void UpdateActive(int id, int adminId, string action)

        {

                // Try to insert
                using (SqlConnection myConnection = new(ConnectionString))
                {
                    myConnection.Open();
                    using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                    myCommand.Parameters.AddWithValue("@id",id);
                    myCommand.ExecuteNonQuery();
                    updateLog(adminId, action);
                };//end sqlConnection 

        }
        public string AddEmail(string email)
        {
            SqlCmd = "INSERT INTO registered_emails (email) VALUES (@Email)";
            try
            {
                // Try to insert
                using (SqlConnection myConnection = new(ConnectionString))
                {
                    myConnection.Open();
                    using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                    myCommand.Parameters.AddWithValue("@Email", Convert.ToString(email));
                    myCommand.ExecuteNonQuery();
                };//end sqlConnection 
                return $"Email:{email} Added successfully";
            }
            catch (SqlException exception)
            {
                if (exception.Number == 2601)// Cannot insert duplicate key row in object error01
                {
                    // check column where error occured

                    return "error adding user duplicate email";
                }
                else
                    throw; // Throw exception if this exception is unexpected
            }

        }

        public void updateLog(int adminId, string action)
        {
            SqlCmd = "INSERT INTO adminActionLog ([adminId],[action]) VALUES (@adminId, @action)";
           
                using (SqlConnection myConnection = new(ConnectionString))
                {
                    myConnection.Open();
                    using SqlCommand myCommand = new SqlCommand(SqlCmd, myConnection);
                    myCommand.Parameters.AddWithValue("@adminId", Convert.ToInt32(adminId));
                    myCommand.Parameters.AddWithValue("@action", Convert.ToString(action));
                    myCommand.ExecuteNonQuery();
                };//end sqlConnection 
        }
    }
}
