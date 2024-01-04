using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareTech.classes
{
    public class _Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string AppointmentType { get; set; }
        public string AppointmentStatus { get; set; }
        public int AppointmentFees { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int fees { get; set; }

        public _Appointment() { }

        public _Appointment( DateTime appointmentDate, TimeSpan appointmentTime,
                           string appointmentType, int appointmentFees,
                           int patientID, int doctorID)
        {
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            AppointmentType = appointmentType;
            AppointmentFees = appointmentFees;
            PatientID = patientID;
            DoctorID = doctorID;
            if (appointmentType == "Follow Up")
                fees = 300;
            else fees = 200;
        }
    }
}
