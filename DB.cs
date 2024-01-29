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
using System.Configuration;
using System.Data;

namespace CareTech
{
    internal class DB
    {
        static public string connectionString = "server=localhost;database=caretech;user=root;password=caretech;";
        static public MySqlConnection connection;

        public DB()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        /////////////////////// PATIENT /////////////////////////////////
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
                    {
                        ;
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

        static public void CreateTempPatient(Patient patient)
        {
            string insertSql = @"INSERT INTO Patient 
                             (nationalID, name, phoneNumber,patientID) 
                             VALUES (@NationalID, @Name, @PhoneNumber, @PatientID)";
            try
            {
                connection = new MySqlConnection(connectionString);
                using (connection)
                {

                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertSql, connection))
                    {
                        ;
                        command.Parameters.AddWithValue("@NationalID", patient.NationalID);
                        command.Parameters.AddWithValue("@Name", patient.Name);
                        command.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
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

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM patient WHERE age IS NOT NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Patient patient = new Patient
                            {
                                PatientID = reader.GetInt32("patientID"),
                                NationalID = reader.GetString("nationalID"),
                                Name = reader.GetString("name"),
                                DOB = reader.IsDBNull(reader.GetOrdinal("DOB")) ? (DateTime?)null : reader.GetDateTime("DOB"),
                                Age = reader.GetInt32("age"),
                                Address = reader.GetString("address"),
                                PhoneNumber = reader.GetString("phoneNumber"),
                                Gender = reader.GetString("gender"),
                                MaritalStatus = reader.GetString("maritalStatus"),
                                Height = reader.GetInt32("height"),
                                Weight = reader.GetInt32("weight"),
                                BloodGroup = reader.GetString("bloodGroup")
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return patients;
        }


        public Patient GetPatientById(int patientId)
        {
            Patient patient = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL query to select a patient by ID
                string query = "SELECT * FROM patient WHERE patientID = @PatientId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);


                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Map database fields to Patient properties
                            patient = new Patient
                            {
                                PatientID = Convert.ToInt32(reader["patientID"]),
                                NationalID = reader["nationalID"].ToString(),
                                Name = reader["name"].ToString(),
                                DOB = reader["DOB"] is DBNull ? null : (DateTime?)reader["DOB"],
                                Age = Convert.ToInt32(reader["age"]),
                                Address = reader["address"].ToString(),
                                PhoneNumber = reader["phoneNumber"].ToString(),
                                Gender = reader["gender"].ToString(),
                                MaritalStatus = reader["maritalStatus"].ToString(),
                                Height = Convert.ToInt32(reader["height"]),
                                Weight = Convert.ToInt32(reader["weight"]),
                                BloodGroup = reader["bloodGroup"].ToString()
                            };
                        }
                    }
                }
            }

            return patient;
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
                diabetes, kidneyDisease, thyroidDisease, alcoholConsumption, pencillinAllergy, aspirinAllergy, sulfaDrugAllergy, 
                ibuprofen, coldHeatIntolerance, drugResistantInfection, abdominalPain, nausea, bloodyVomit, ulcerDisease, 
                lossOfApetite_heartBurn, fatigue_nightSweats, fever_chills, cartoidSurgery, cartoidSurgeryDate, heartStent, 
                heartStentDate, laparoscopy, laparoscopyDate, pacemaker, pacemakerDate, otherSurgeries)
                VALUES
                (@PatientID, @HyperTension, @HeartAttack, @HighCholestrol, @Stroke, @Cancer, @HeartFailure, @ClottingDisorder,
                @Diabetes, @KidneyDisease, @ThyroidDisease, @AlcoholConsumption, @pencillinAllergy, @AspirinAllergy, 
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
                    command.Parameters.AddWithValue("@pencillinAllergy", medicalAssessment.PencillinAllergy);
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

        public static Doctor GetDoctorById(int doctorId)
        {
            Doctor resultDoctor = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM doctor WHERE doctorID = @DoctorId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resultDoctor = new Doctor
                            {
                                DoctorID = Convert.ToInt32(reader["doctorID"]),
                                DoctorName = reader["doctorName"].ToString(),
                                NationalID = reader["nationalID"].ToString(),
                                DOB = reader["DOB"] is DBNull ? null : (DateTime?)reader["DOB"],
                                Age = Convert.ToInt32(reader["age"]),
                                Gender = reader["gender"].ToString(),
                                Address = reader["address"].ToString(),
                                PhoneNumber = reader["phoneNumber"].ToString(),
                                Email = reader["email"].ToString(),
                                DocPassword = reader["docPassword"].ToString(),
                                Specialization = reader["specialization"].ToString(),
                                JointDate = reader["jointDate"] is DBNull ? null : (DateTime?)reader["jointDate"]
                            };
                        }
                    }
                }
            }

            return resultDoctor;
        }

        //////////////// APPOINTMENT ////////////////
        public void InsertAppointment(_Appointment appointment)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO appointment 
                         (appointmentDate, appointmentTime, appointmentType, appointmentFees, patientID, doctorID, fees) 
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

        public List<_Appointment> GetAllAppointments()
        {
            List<_Appointment> appointments = new List<_Appointment>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL query to select all appointments
                string query = "SELECT * FROM appointment";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map database fields to _Appointment properties
                            _Appointment appointment = new _Appointment
                            {
                                AppointmentID = Convert.ToInt32(reader["appointmentID"]),
                                AppointmentDate = Convert.ToDateTime(reader["appointmentDate"]),
                                AppointmentTime = (TimeSpan)reader["appointmentTime"],
                                AppointmentType = reader["appointmentType"].ToString(),
                                AppointmentStatus = reader["appointmentStatus"].ToString(),
                                AppointmentFees = Convert.ToInt32(reader["appointmentFees"]),
                                PatientID = Convert.ToInt32(reader["patientID"]),
                                DoctorID = Convert.ToInt32(reader["doctorID"])
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }
        public List<_Appointment> GetAppointmentsForDate(DateTime selectedDate)
        {
            List<_Appointment> appointments = new List<_Appointment>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL query to select appointments for a specific date
                string query = "SELECT * FROM appointment WHERE DATE(appointmentDate) = @selectedDate";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Use parameterized query to prevent SQL injection
                    command.Parameters.AddWithValue("@selectedDate", selectedDate.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map database fields to _Appointment properties
                            _Appointment appointment = new _Appointment
                            {
                                AppointmentID = Convert.ToInt32(reader["appointmentID"]),
                                AppointmentDate = Convert.ToDateTime(reader["appointmentDate"]),
                                AppointmentTime = (TimeSpan)reader["appointmentTime"],
                                AppointmentType = reader["appointmentType"].ToString(),
                                AppointmentStatus = reader["appointmentStatus"].ToString(),
                                AppointmentFees = Convert.ToInt32(reader["appointmentFees"]),
                                PatientID = Convert.ToInt32(reader["patientID"]),
                                DoctorID = Convert.ToInt32(reader["doctorID"])
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public List<_Appointment> GetAppointmentsFromNow()
        {
            List<_Appointment> appointments = new List<_Appointment>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL query to select appointments for today
                string query = "SELECT * FROM appointment WHERE DATE(appointmentDate) = CURDATE() AND TIME(appointmentTime) >= CURTIME()";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map database fields to _Appointment properties
                            _Appointment appointment = new _Appointment
                            {
                                AppointmentID = Convert.ToInt32(reader["appointmentID"]),
                                AppointmentDate = Convert.ToDateTime(reader["appointmentDate"]),
                                AppointmentTime = (TimeSpan)reader["appointmentTime"],
                                AppointmentType = reader["appointmentType"].ToString(),
                                AppointmentStatus = reader["appointmentStatus"].ToString(),
                                AppointmentFees = Convert.ToInt32(reader["appointmentFees"]),
                                PatientID = Convert.ToInt32(reader["patientID"]),
                                DoctorID = Convert.ToInt32(reader["doctorID"])
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public int CountFollowUpAppointmentsForToday()
        {
            int count = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM appointment WHERE DATE(appointmentDate) = CURDATE() AND appointmentType = 'Follow Up'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return count;
        }


        public int CountConsultationAppointmentsForToday()
        {
            int count = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM appointment WHERE DATE(appointmentDate) = CURDATE() AND appointmentType = 'Consultation'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return count;
        }

        public int SumFeesForToday()
        {
            int totalFees = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL query to sum all fees for today
                string query = "SELECT SUM(appointmentFees) FROM appointment WHERE DATE(appointmentDate) = CURDATE()";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // ExecuteScalar is used since we are expecting a single value (sum of fees)
                    object result = command.ExecuteScalar();

                    // Check if the result is not DBNull
                    if (result != DBNull.Value)
                    {
                        totalFees = Convert.ToInt32(result);
                    }
                }
            }

            return totalFees;
        }


        ///////////////// PRESCRIPTION ///////////////////
        public void AddPrescription(Prescription prescription)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO prescription (patientID, doctorID, weight, height, headache, nausea, vomiting, " +
                               "coughing, diagnosis, medicineName, dose, frequency, additionalNotes, dateCreated) " +
                               "VALUES (@PatientID, @DoctorID, @Weight, @Height, @Headache, @Nausea, @Vomiting, " +
                               "@Coughing, @Diagnosis, @MedicineName, @Dose, @Frequency, @AdditionalNotes, @dateCreated)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", prescription.PatientID);
                    command.Parameters.AddWithValue("@DoctorID", prescription.DoctorID);
                    command.Parameters.AddWithValue("@Weight", prescription.Weight);
                    command.Parameters.AddWithValue("@Height", prescription.Height);
                    command.Parameters.AddWithValue("@Headache", prescription.Headache);
                    command.Parameters.AddWithValue("@Nausea", prescription.Nausea);
                    command.Parameters.AddWithValue("@Vomiting", prescription.Vomiting);
                    command.Parameters.AddWithValue("@Coughing", prescription.Coughing);
                    command.Parameters.AddWithValue("@Diagnosis", prescription.Diagnosis);
                    command.Parameters.AddWithValue("@MedicineName", prescription.MedicineName);
                    command.Parameters.AddWithValue("@Dose", prescription.Dose);
                    command.Parameters.AddWithValue("@Frequency", prescription.Frequency);
                    command.Parameters.AddWithValue("@AdditionalNotes", prescription.AdditionalNotes);
                    command.Parameters.AddWithValue("@dateCreated", prescription.dateCreated);

                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Prescription> GetPrescriptionsByPatientID(int patientID)
        {
            List<Prescription> prescriptions = new List<Prescription>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM prescription WHERE patientID = @PatientID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientID", patientID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Prescription prescription = new Prescription
                            {
                                PrescriptionID = Convert.ToInt32(reader["prescriptionID"]),
                                PatientID = Convert.ToInt32(reader["patientID"]),
                                DoctorID = Convert.ToInt32(reader["doctorID"]),
                                Weight = Convert.ToInt32(reader["weight"]),
                                Height = Convert.ToInt32(reader["height"]),
                                Headache = Convert.ToBoolean(reader["headache"]),
                                Nausea = Convert.ToBoolean(reader["nausea"]),
                                Vomiting = Convert.ToBoolean(reader["vomiting"]),
                                Coughing = Convert.ToBoolean(reader["coughing"]),
                                Diagnosis = reader["diagnosis"].ToString(),
                                MedicineName = reader["medicineName"].ToString(),
                                Dose = Convert.ToInt32(reader["dose"]),
                                Frequency = reader["frequency"].ToString(),
                                AdditionalNotes = reader["additionalNotes"].ToString(),
                                dateCreated = Convert.ToDateTime(reader["dateCreated"])

                            };

                            prescriptions.Add(prescription);
                        }
                    }
                }
            }

            return prescriptions;
        }


        ///////////////// LABS /////////////////////// 
        public List<Lab> GetAllLabs()
        {
            List<Lab> labs = new List<Lab>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM lab";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lab lab = new Lab
                            {
                                LabID = Convert.ToInt32(reader["lab_id"]),
                                PatientID = Convert.ToInt32(reader["patientID"]),
                                CBCResults = reader["cbc_results"].ToString(),
                                BMPResults = reader["bmp_results"].ToString(),
                                LipidPanelResults = reader["lipid_panel_results"].ToString(),
                                ThyroidTestsResults = reader["thyroid_tests_results"].ToString(),
                                HbA1CResult = Convert.ToDouble(reader["hba1c_result"]),
                                UrinalysisResults = reader["urinalysis_results"].ToString(),
                                LFTResults = reader["lft_results"].ToString(),
                                CoagulationPanelResults = reader["coagulation_panel_results"].ToString(),
                                SerumElectrolytesResults = reader["serum_electrolytes_results"].ToString(),
                                CRPResult = Convert.ToDouble(reader["crp_result"]),
                                ESRResult = Convert.ToDouble(reader["esr_result"]),
                                HIVTestResult = reader["hiv_test_result"].ToString(),
                                HepatitisTestResults = reader["hepatitis_test_results"].ToString(),
                                PTResult = Convert.ToDouble(reader["pt_result"]),
                                INRResult = Convert.ToDouble(reader["inr_result"]),
                                BloodTypingResults = reader["blood_typing_results"].ToString(),
                                DateCreated = Convert.ToDateTime(reader["dateCreated"])
                            };

                            labs.Add(lab);
                        }
                    }
                }
            }

            return labs;
        }


        //////////////// EQUIPMENT ////////////////
        public void InsertEquipment(Equipment equipment)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL query to insert data into the Equipment table
                string query = "INSERT INTO Equipment (EquipmentName, EquipmentType, Vendor, AcquisitionCost, ExpectedLifespan, MaintenanceDate) " +
                               "VALUES (@EquipmentName, @EquipmentType, @Vendor, @AcquisitionCost, @ExpectedLifespan, @MaintenanceDate)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EquipmentName", equipment.EquipmentName);
                    command.Parameters.AddWithValue("@EquipmentType", equipment.EquipmentType);
                    command.Parameters.AddWithValue("@Vendor", equipment.Vendor);
                    command.Parameters.AddWithValue("@AcquisitionCost", equipment.AcquisitionCost);
                    command.Parameters.AddWithValue("@ExpectedLifespan", equipment.ExpectedLifespan);
                    command.Parameters.AddWithValue("@MaintenanceDate", equipment.MaintenanceDate);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Equipment> GetAllEquipment()
        {
            List<Equipment> equipmentList = new List<Equipment>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL query to select all equipment from the Equipment table
                string query = "SELECT * FROM Equipment";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map database fields to Equipment properties
                            Equipment equipment = new Equipment
                            {
                                EquipmentID = Convert.ToInt32(reader["EquipmentID"]),
                                EquipmentName = reader["EquipmentName"].ToString(),
                                EquipmentType = reader["EquipmentType"].ToString(),
                                Vendor = reader["Vendor"].ToString(),
                                AcquisitionCost = Convert.ToDecimal(reader["AcquisitionCost"]),
                                ExpectedLifespan = Convert.ToInt32(reader["ExpectedLifespan"]),
                                MaintenanceDate = Convert.ToDateTime(reader["MaintenanceDate"])
                            };

                            equipmentList.Add(equipment);
                        }
                    }
                }
            }

            return equipmentList;
        }

        public void AddMember(string position, string name, string email, string phoneNumber, string password, string gender)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
                try
                {
                    connection.Open();

                    string insertQuery = "";

                    switch (position.ToLower())
                    {
                        case "receptionist":
                            insertQuery = "INSERT INTO receptionist (recepionistName, email, phoneNumber, receptionistPassword, gender) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Password, @Gender)";
                            break;

                        case "doctor":
                            insertQuery = "INSERT INTO doctor (doctorName, email, phoneNumber, docPassword, gender) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Password, @Gender)";
                            break;

                        default:
                            throw new Exception("Invalid position");
                    }

                    MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@FirstName", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Gender", gender);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
        }







    }

   





}



    


