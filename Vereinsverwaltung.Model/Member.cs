using System;

namespace Vereinsverwaltung.Model
{
    public class Member
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }
        public String Birthdate { get; set; }
    }
}
