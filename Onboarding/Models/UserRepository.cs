using Onboarding.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Onboarding.Models
{
    public class UserRepository : IUser
    {
        DataAccess dataAccess = new();
        string connection = @"Server=.;Database=Users; trusted_Connection=True";


        public User Login(string email, string password)
        {
            User userdetails=null;
            dataAccess.ConnectionString = connection;
            dataAccess.SqlCmd = $"SELECT * FROM details WHERE email= '{email}' AND password='{password}'";
            DataSet UserData = dataAccess.Login(email, password);

            foreach (DataTable table in UserData.Tables) // iterate tables
            {
                if (table.Rows.Count != 0)
                {
                    foreach (DataRow row in table.Rows) // iterate row
                    {

                        userdetails = new User()
                        {
                            UserID = Convert.ToInt32(row[0]),
                            Firstname = Convert.ToString(row[1]),
                            Lastname = Convert.ToString(row[2]),
                            UserEmail = Convert.ToString(row[1]),
                            Password = "Not available",
                            LoginStatus = true
                        };

                    }//end foreach row
                }
                else
                {
                    userdetails = new User()
                    {
                        Firstname = "Not available",
                        Lastname = "Not available",
                        UserEmail = "Not available",
                        Password = "Not available",
                        LoginStatus = false
                    };
                }
                
            }

            return userdetails;
        }

        public bool RegisterUser(User newUser)
        {
             bool status; 
            dataAccess.ConnectionString = connection;
            status= dataAccess.CreateUser(newUser);

            return status;
        }
    }
}
