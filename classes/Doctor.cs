using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareTech.classes
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string NationalID { get; set; }
        public DateTime? DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DocPassword { get; set; }
        public string Specialization { get; set; }
        public DateTime? JointDate { get; set; }

        // Parameterless constructor
        public Doctor() { }

        // Constructor with parameters
        public Doctor(string doctorName, string gender,
                      string phoneNumber, string email, string docPassword)
        {
            DoctorName = doctorName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            DocPassword = docPassword;
        }
    }
}
