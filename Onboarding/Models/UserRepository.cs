 using Onboarding.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Onboarding.Models
{
    public class UserRepository : IUser
    {
        DataAccess dataAccess = new();
        string connection = @"Server=.;Database=Users; trusted_Connection=True";
        public IWebHostEnvironment _hostingEnvironment;
        public UserRepository(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

        }
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
                            UserID=Convert.ToInt32(row[0]),
                            UserRole = Convert.ToInt32(row[1]),
                            Firstname = Convert.ToString(row[2]),
                            Lastname = Convert.ToString(row[3]),
                            UserEmail = Convert.ToString(row[4]),
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
        public User updateUserInfo(User user)
        {
            User userdetails = null;
            dataAccess.ConnectionString = connection;
            dataAccess.SqlCmd = $"UPDATE [dbo].[details] SET [firstname] = @firstname,[lastname] =@lastname WHERE UserId=@Id";

            dataAccess.updateRecord(user);
            dataAccess.SqlCmd = $"SELECT * FROM details WHERE UserId={user.UserID}";

            DataSet UserData = dataAccess.GetDataSet();

            foreach (DataTable table in UserData.Tables) // iterate tables
            {
                if (table.Rows.Count != 0)
                {
                    foreach (DataRow row in table.Rows) // iterate row
                    {

                        userdetails = new User()
                        {
                            UserID = Convert.ToInt32(row[0]),
                            UserRole = Convert.ToInt32(row[1]),
                            Firstname = Convert.ToString(row[2]),
                            Lastname = Convert.ToString(row[3]),
                            UserEmail = Convert.ToString(row[4]),
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

        public string UploadImage(ProfileImageDetails profileImage)
        {
            if (profileImage.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_hostingEnvironment.WebRootPath + "\\ProfileImages\\"))
                    {
                        Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "\\ProfileImages\\");
                    }
                    string name = profileImage.files.FileName;
                    dataAccess.ConnectionString = connection;
                    dataAccess.SqlCmd = $"SELECT * FROM ImageUpload WHERE UserId={profileImage.UserId}";
                    DataSet userImageDetails = dataAccess.GetDataSet();
                    if (userImageDetails.Tables[0].Rows.Count == 0)
                    {
                        dataAccess.AddImage(profileImage);
                        
                        using (FileStream fileStream = System.IO.File.Create(_hostingEnvironment.WebRootPath + "\\ProfileImages\\" + profileImage.UserId + Path.GetExtension(name)))
                        {
                            profileImage.files.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                        return "image added successfully";
                    }
                    else {
                        var path=userImageDetails.Tables[0].Rows[0][1];
                            System.IO.File.Delete(_hostingEnvironment.WebRootPath +path);
                        dataAccess.UpdateImage(profileImage);
                        

                        using (FileStream fileStream = System.IO.File.Create(_hostingEnvironment.WebRootPath + "\\ProfileImages\\" + profileImage.UserId + Path.GetExtension(name)))
                        {
                            profileImage.files.CopyTo(fileStream);
                            fileStream.Flush();
                            return "image uploaded successfully";
                        }
                    }
                    
                }
               catch (Exception ex)
                {

                    return ex.Message;
                }
            }
            else return "failed to upload";
        }
        public string GetImageUrl(int id)
        {
            dataAccess.ConnectionString = connection;
          return  dataAccess.getImageUrl(id);
        }

    }
}
