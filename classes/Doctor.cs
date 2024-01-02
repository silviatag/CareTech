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
        public Doctor(string doctorName, string nationalID, DateTime? dob, string gender,
                      string address, string phoneNumber, string email, string docPassword,
                      string specialization, DateTime? jointDate)
        {
            DoctorName = doctorName;
            NationalID = nationalID;
            DOB = dob;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            DocPassword = docPassword;
            Specialization = specialization;
            JointDate = jointDate;
            if (DOB.HasValue)
            {
                DateTime currentDate = DateTime.Now;
                Age = currentDate.Year - DOB.Value.Year;

                // Check if the birthday for this year has occurred or not
                if (DOB.Value.Date > currentDate.AddYears(-Age))
                {
                    Age--;
                }
            }
        }
    }
}
