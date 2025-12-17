using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace ЛБ6_СМООП_
{

    [Serializable]
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public User() { }

        public User(string login, string password, string fullName)
        {
            Login = login;
            Password = password;
            FullName = fullName;
            RegistrationDate = DateTime.Now;
        }

        public override string ToString() => $"{FullName} ({Login})";
    }

}
