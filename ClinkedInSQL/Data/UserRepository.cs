using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ClinkedInSQL.Models;
using ClinkedInSQL.Data;

namespace ClinkedInSQL.Data
{
    public class UserRepository
    {
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
    }
}
