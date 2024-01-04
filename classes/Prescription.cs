using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CareTech.classes
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public bool Headache { get; set; }
        public bool Nausea { get; set; }
        public bool Vomiting { get; set; }
        public bool Coughing { get; set; }
        public string Diagnosis { get; set; }
        public string MedicineName { get; set; }
        public int Dose { get; set; }
        public string Frequency { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime dateCreated { get; set; }

        public Prescription() { }  
        
        public Prescription(int patientID, int doctorID, int weight, int height, bool headache, bool nausea, bool vomiting, bool coughing, string diagnosis, string medicineName, int dose, string frequency, string additionalNotes)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            Weight = weight;
            Height = height;
            Headache = headache;
            Nausea = nausea;
            Vomiting = vomiting;
            Coughing = coughing;
            Diagnosis = diagnosis;
            MedicineName = medicineName;
            Dose = dose;
            Frequency = frequency;
            AdditionalNotes = additionalNotes;
            dateCreated = DateTime.Today;
        }
        
    }
}
