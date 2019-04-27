using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedInSQL.Models
{
    public class User
    {
        public User(string name, DateTime releasedate, bool isprisoner, int age)
        {
            Name = name;
            ReleaseDate = releasedate;
            IsPrisoner = isprisoner;
            Age = age;

        }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsPrisoner { get; set; }
        public int Age { get; set; }

    }

    public class UserServices
    {
        public UserServices(int id, string username, string servicename, string description)
        {
            Id = id;
            UserName = username;
            ServiceName = servicename;
            Description = description;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
    }
}
