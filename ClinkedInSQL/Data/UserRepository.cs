using System;
using System.Collections.Generic;
// Contains the provider-specific ADO.NET objects used to connect to a SQL Server 7 
// Or SQL Server 2000 database, execute a command, and transfer information to and from a DataSet. 
// SqlClient interacts with SQL Server
// For the database connections and objects
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClinkedInSQL.Models;
using ClinkedInSQL.Data;

namespace ClinkedInSQL.Data
{
    public class UserRepository
    {
        // Method Template
            // 1. Connection
            // 2. Command
            // 3. Read or Execute
            
        public List<User> GetAll()
        {
            var users = new List<User>();

            var connection = new SqlConnection("Server=localhost;Database=ClinkedIn;Trusted_Connection=True;");
            connection.Open();

            var getAllUsersCommand = connection.CreateCommand();
            getAllUsersCommand.CommandText = @"select name, releasedate, isprisoner, age 
                                               from users";

            var reader = getAllUsersCommand.ExecuteReader();

            while (reader.Read())
            {
                var name = reader["name"].ToString();
                var releasedate = (DateTime)reader["releasedate"];
                var isprisoner = (bool)reader["isprisoner"];
                var age = (int)reader["age"];
                var user = new User(name, releasedate, isprisoner, age);

                users.Add(user);

            }

            connection.Close();

            return users;
        }

        public List<UserServices> GetUsersServices(int id)
        {

            var userServicesList = new List<UserServices>();

            var connection = new SqlConnection("Server=localhost;Database=ClinkedIn;Trusted_Connection=True;");
            connection.Open();

            var getUsersByServicesCommand = connection.CreateCommand();
            getUsersByServicesCommand.CommandText = $@"Select u.Id, u.Name, s.Name, s.Description
                                                        From UserServiceJoin as us
                                                        Join Users u on u.Id = us.UserId
                                                        Join Services s on s.Id = us.ServiceId
                                                        Where u.Id = @Id";

           getUsersByServicesCommand.Parameters.AddWithValue("@Id", id);

            var reader = getUsersByServicesCommand.ExecuteReader();

            while (reader.Read())
            {
                var userid = (int)reader["Id"];
                var username = reader["Name"].ToString();
                var servicename = reader["Name"].ToString();
                var description = reader["Description"].ToString();
                var singleex = new UserServices(userid, username, servicename, description);

                userServicesList.Add(singleex);

            }
            connection.Close();

            return userServicesList;
        }
    }
}
