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
                            Firstname = Convert.ToString(row[1]),
                            Lastname = Convert.ToString(row[2]),
                            UserEmail = Convert.ToString(row[1]),
                            Password = "Not available",
                            
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
                    };
                }
                
            }

            return userdetails;
        }

        public string RegisterUser(User newUser)
        {
             string status; 
            dataAccess.ConnectionString = connection;
            status= dataAccess.CreateUser(newUser);

            return status;
        }
    public string PasswordReset(string email, string password)
        {
            dataAccess.ConnectionString = connection;
            dataAccess.SqlCmd = "update details set password=@password where email=@email";
            string message=dataAccess.PasswordReset(email,password);
            return message;
            
        }
    }
}
