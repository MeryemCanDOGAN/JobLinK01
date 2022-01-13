using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLinK2.ClassLayer
{
    internal class EmpProfile
    {
        public int userID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birthday { get; set; }
        public string country { get; set; }
        public int cityID { get; set; }
        public string email { get; set; }
        public string descript { get; set; }
        public string profile { get; set; }

        public EmpProfile(int userID, string name, string surname, string birthday, string country, int cityID, string email, string descript, string profile)
        {
            this.userID = userID;
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
            this.country = country;
            this.cityID = cityID;
            this.email = email;
            this.descript = descript;
            this.profile = profile;
        }
    }
}
