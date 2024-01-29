using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareTech.classes
{
    public class Receptionist
    {
        public int ReceptionistID { get; set; }
        public string ReceptionistName { get; set; }
        public string NationalID { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ReceptionistPassword { get; set; }

        // Default constructor
        public Receptionist()
        {
            // Default constructor
        }

        // Parameterized constructor
        public Receptionist(string name, string gender, string phoneNumber, string email, string password)
        {
            ReceptionistName = name;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            ReceptionistPassword = password;
        }
    }

}
