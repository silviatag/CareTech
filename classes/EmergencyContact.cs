using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareTech.classes
{
    public class EmergencyContact
    {
        public int EmergencyContactID { get; set; }
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Relationship { get; set; }

        // Empty constructor
        public EmergencyContact() { }

        // Constructor without EmergencyContactID (for inserts where it's auto-incremented)
        public EmergencyContact(int patientID, string name, string phoneNumber, string relationship)
        {
            PatientID = patientID;
            Name = name;
            PhoneNumber = phoneNumber;
            Relationship = relationship;
        }
    }
}
