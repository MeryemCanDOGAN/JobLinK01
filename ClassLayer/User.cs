using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLinK2.ClassLayer
{
    internal class User
    {
        public string email { get; set; }

        public string password { get; set; }

        public string userType { get; set; }

        public User(string email, string password, string userType)
        {
            this.email = email;
            this.password = password;
            this.userType = userType;
        }
    }
}
