using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql;
using MySql.Data.MySqlClient;
using CareTech.classes;
using System.Data.SqlClient;
using System.Windows.Controls;
namespace CareTech
{
    internal class DB
    {
        static public string connectionString = "server=localhost;database=DB;user=root;password=caretech;";
        static public MySqlConnection connection;

        //MySqlConnection connection;
        public DB() 
        { 
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        static public void CreatePatient(Patient patient)
        {
            string insertSql = @"INSERT INTO Patient 
                             (nationalID, name, DOB, age, address, phoneNumber, gender, maritalStatus, height, weight, bloodGroup, patientID) 
                             VALUES (@NationalID, @Name, @DOB, @Age, @Address, @PhoneNumber, @Gender, @MaritalStatus, @Height, @Weight, @BloodGroup, @PatientID)";
            try 
            {
                connection = new MySqlConnection(connectionString);
                using (connection)
                {

                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertSql, connection))
                    {;
                        command.Parameters.AddWithValue("@NationalID", patient.NationalID);
                        command.Parameters.AddWithValue("@Name", patient.Name);
                        command.Parameters.AddWithValue("@DOB", patient.DOB);
                        command.Parameters.AddWithValue("@Age", patient.Age);
                        command.Parameters.AddWithValue("@Address", patient.Address);
                        command.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                        command.Parameters.AddWithValue("@Gender", patient.Gender);
                        command.Parameters.AddWithValue("@MaritalStatus", patient.MaritalStatus);
                        command.Parameters.AddWithValue("@Height", patient.Height);
                        command.Parameters.AddWithValue("@Weight", patient.Weight);
                        command.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);
                        command.Parameters.AddWithValue("@PatientID", patient.PatientID);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Patient created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating patient: {ex.Message}");
            }
        }


        public List<string> GetPatientIdsAndNames()
        {
            List<string> patientsInfo = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT patientID, name FROM patient";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int patientID = reader.GetInt32("patientID");
                            string name = reader.GetString("name");

                            // Convert patientID to string and concatenate with name
                            string patientInfo = $"{patientID.ToString()} - {name}";

                            patientsInfo.Add(patientInfo);
                        }
                    }
                }
            }

            return patientsInfo;
        }
        ////////////////////////EMERGENCY CONTACT///////////////////////////


        public static void CreateEmergencyContact(EmergencyContact emergencyContact)
        {
            string insertSql = @"
                INSERT INTO emergencycontact (patientID, name, phoneNumber, relationship)
                VALUES (@PatientID, @Name, @PhoneNumber, @Relationship);
            ";

            try
            {
                connection = new MySqlConnection(connectionString);
                using (connection)
                {

                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertSql, connection))
                    {
                        command.Parameters.AddWithValue("@PatientID", emergencyContact.PatientID);
                        command.Parameters.AddWithValue("@Name", emergencyContact.Name);
                        command.Parameters.AddWithValue("@PhoneNumber", emergencyContact.PhoneNumber);
                        command.Parameters.AddWithValue("@Relationship", emergencyContact.Relationship); 
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("emergency contact created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating patient: {ex.Message}");
            }
        }

        /////////////// MEDICAL ASSESSMENT///////////////

        public static void CreateMedicalAssessment(MedicalAssessment medicalAssessment)
        {
            string insertSql = @"
                INSERT INTO medicalassessment
                (patientID, hyperTension, heartAttack, highCholestrol, stroke, cancer, heartFailure, clottingDisorder, 
                diabetes, kidneyDisease, thyroidDisease, alcoholConsumption, pencillinAllgery, aspirinAllergy, sulfaDrugAllergy, 
                ibuprofen, coldHeatIntolerance, drugResistantInfection, abdominalPain, nausea, bloodyVomit, ulcerDisease, 
                lossOfApetite_heartBurn, fatigue_nightSweats, fever_chills, cartoidSurgery, cartoidSurgeryDate, heartStent, 
                heartStentDate, laparoscopy, laparoscopyDate, pacemaker, pacemakerDate, otherSurgeries)
                VALUES
                (@PatientID, @HyperTension, @HeartAttack, @HighCholestrol, @Stroke, @Cancer, @HeartFailure, @ClottingDisorder,
                @Diabetes, @KidneyDisease, @ThyroidDisease, @AlcoholConsumption, @PencillinAllergy, @AspirinAllergy, 
                @SulfaDrugAllergy, @Ibuprofen, @ColdHeatIntolerance, @DrugResistantInfection, @AbdominalPain, @Nausea, 
                @BloodyVomit, @UlcerDisease, @LossOfApetite_HeartBurn, @Fatigue_NightSweats, @Fever_Chills, @CartoidSurgery, 
                @CartoidSurgeryDate, @HeartStent, @HeartStentDate, @Laparoscopy, @LaparoscopyDate, @Pacemaker, @PacemakerDate, @OtherSurgeries)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", medicalAssessment.PatientID);
                    command.Parameters.AddWithValue("@HyperTension", medicalAssessment.Hypertension);
                    command.Parameters.AddWithValue("@HeartAttack", medicalAssessment.HeartAttack);
                    command.Parameters.AddWithValue("@HighCholestrol", medicalAssessment.HighCholestrol);
                    command.Parameters.AddWithValue("@Stroke", medicalAssessment.Stroke);
                    command.Parameters.AddWithValue("@Cancer", medicalAssessment.Cancer);
                    command.Parameters.AddWithValue("@HeartFailure", medicalAssessment.HeartFailure);
                    command.Parameters.AddWithValue("@ClottingDisorder", medicalAssessment.ClottingDisorder);
                    command.Parameters.AddWithValue("@Diabetes", medicalAssessment.Diabetes);
                    command.Parameters.AddWithValue("@KidneyDisease", medicalAssessment.KidneyDisease);
                    command.Parameters.AddWithValue("@ThyroidDisease", medicalAssessment.ThyroidDisease);
                    command.Parameters.AddWithValue("@AlcoholConsumption", medicalAssessment.AlcoholConsumption);
                    command.Parameters.AddWithValue("@PencillinAllergy", medicalAssessment.PencillinAllergy);
                    command.Parameters.AddWithValue("@AspirinAllergy", medicalAssessment.AspirinAllergy);
                    command.Parameters.AddWithValue("@SulfaDrugAllergy", medicalAssessment.SulfaDrugsAllergy);
                    command.Parameters.AddWithValue("@Ibuprofen", medicalAssessment.IbuprofenAllergy);
                    command.Parameters.AddWithValue("@ColdHeatIntolerance", medicalAssessment.ColdHeatIntolerance);
                    command.Parameters.AddWithValue("@DrugResistantInfection", medicalAssessment.DrugResistantInfection);
                    command.Parameters.AddWithValue("@AbdominalPain", medicalAssessment.AbdominalPain);
                    command.Parameters.AddWithValue("@Nausea", medicalAssessment.Nausea);
                    command.Parameters.AddWithValue("@BloodyVomit", medicalAssessment.bloodyVomit);
                    command.Parameters.AddWithValue("@UlcerDisease", medicalAssessment.UlcerDisease);
                    command.Parameters.AddWithValue("@LossOfApetite_HeartBurn", medicalAssessment.LossOfApetite_HeartBurn);
                    command.Parameters.AddWithValue("@Fatigue_NightSweats", medicalAssessment.Fatigue_NightSweats);
                    command.Parameters.AddWithValue("@Fever_Chills", medicalAssessment.Fever_Chills);
                    command.Parameters.AddWithValue("@CartoidSurgery", medicalAssessment.CartoidSurgery);
                    command.Parameters.AddWithValue("@CartoidSurgeryDate", medicalAssessment.CartoidSurgeryDate);
                    command.Parameters.AddWithValue("@HeartStent", medicalAssessment.HeartStent);
                    command.Parameters.AddWithValue("@HeartStentDate", medicalAssessment.HeartStentDate);
                    command.Parameters.AddWithValue("@Laparoscopy", medicalAssessment.laparoscopy);
                    command.Parameters.AddWithValue("@LaparoscopyDate", medicalAssessment.laparoscopyDate);
                    command.Parameters.AddWithValue("@Pacemaker", medicalAssessment.Pacemaker);
                    command.Parameters.AddWithValue("@PacemakerDate", medicalAssessment.PacemakerDate);
                    command.Parameters.AddWithValue("@OtherSurgeries", medicalAssessment.OtherSurgeries);
                    command.ExecuteNonQuery();
                }
            }
        }


        /////////////////// DOCTOR ///////////////////////////
        public void InsertDoctor(Doctor doctor)
        {
            string insertSql = @"INSERT INTO doctor 
                                 (doctorName, nationalID, DOB, age, gender, address, 
                                  phoneNumber, email, docPassword, specialization, jointDate) 
                                 VALUES 
                                 (@DoctorName, @NationalID, @DOB, @Age, @Gender, @Address, 
                                  @PhoneNumber, @Email, @DocPassword, @Specialization, @JointDate)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
                    command.Parameters.AddWithValue("@NationalID", doctor.NationalID);
                    command.Parameters.AddWithValue("@DOB", doctor.DOB);
                    command.Parameters.AddWithValue("@Age", doctor.Age);
                    command.Parameters.AddWithValue("@Gender", doctor.Gender);
                    command.Parameters.AddWithValue("@Address", doctor.Address);
                    command.Parameters.AddWithValue("@PhoneNumber", doctor.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", doctor.Email);
                    command.Parameters.AddWithValue("@DocPassword", doctor.DocPassword);
                    command.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                    command.Parameters.AddWithValue("@JointDate", doctor.JointDate); 
                    command.ExecuteNonQuery();
                }
            }
        }

        public void PopulateDoctorDropdown(ComboBox cb)
        {
            cb.Items.Clear(); // Clear existing items

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT doctorID, doctorName FROM doctor";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int doctorID = reader.GetInt32("doctorID");
                            string doctorName = reader.GetString("doctorName");

                            // Convert doctorID to string and concatenate with name
                            string doctorInfo = $"{doctorName} - {doctorID.ToString()}";

                            // Add doctorInfo as an item to the ComboBox
                            cb.Items.Add(doctorInfo);
                        }
                    }
                }
            }
        }


        //////////////// APPOINTMENT ////////////////
        public void InsertAppointment(_Appointment appointment)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO appointment 
                         (appointmentDate, appointmentTime, appointmentType, appointmentFees, patientID, doctorID) 
                         VALUES (@AppointmentDate, @AppointmentTime, @AppointmentType, @AppointmentFees, @PatientID, @DoctorID)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                    command.Parameters.AddWithValue("@AppointmentType", appointment.AppointmentType);
                    command.Parameters.AddWithValue("@AppointmentFees", appointment.AppointmentFees);
                    command.Parameters.AddWithValue("@PatientID", appointment.PatientID);
                    command.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);

                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }
        }




    }
}


