using CareTech.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CareTech
{
    /// <summary>
    /// Interaction logic for DoctorDashboard.xaml
    /// </summary>
    public partial class DoctorDashboard : Window
    {
        public DoctorDashboard()
        {
            InitializeComponent();
            LoadAppointments();
            DB db = new DB();
            followUpCount.Text = db.CountFollowUpAppointmentsForToday().ToString();
            consultationCount.Text =db.CountConsultationAppointmentsForToday().ToString() ;  
            totalPatientCount.Text= (db.CountFollowUpAppointmentsForToday()+ db.CountConsultationAppointmentsForToday()).ToString();
            totalfeestxt.Text =db.SumFeesForToday().ToString();
        }
        

        


        public class AppointmentViewModel
        {
            public string PatientInfo { get; set; }
            public string AppointmentTime { get; set; }
            public int AppointmentID { get; set; }
        }
        private ObservableCollection<AppointmentViewModel> appointmentsViewModel = new ObservableCollection<AppointmentViewModel>();

        private void LoadAppointments()
        {
            DB db = new DB();
             string connectionString = "server=localhost;database=caretech;user=root;password=caretech;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Your SQL query to select today's appointments
                string query = "SELECT * FROM appointment WHERE DATE(appointmentDate) = CURDATE() AND TIME(appointmentTime) >= CURTIME()";


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int patientId = Convert.ToInt32(reader["patientID"]);
                            Patient patient = db.GetPatientById(patientId);

                            // Map database fields to AppointmentViewModel properties
                            AppointmentViewModel appointmentViewModel = new AppointmentViewModel
                            {
                                PatientInfo = patient.Name+" #"+patient.PatientID,
                                AppointmentTime = $"{reader["appointmentTime"]}",
                                AppointmentID = Convert.ToInt32(reader["appointmentID"])
                            };

                            appointmentsViewModel.Add(appointmentViewModel);
                        }
                    }
                }
            }

            appointmentListView.ItemsSource = appointmentsViewModel;
        }

        private void Details_CLick(object sender, RoutedEventArgs e)
        {
            if (appointmentListView.SelectedItem is AppointmentViewModel selectedAppointment)
            {
                // Create a new instance of the window
                PatientFile pf = new PatientFile();
                pf.idtxt.Text = selectedAppointment.PatientInfo.Split('#')[1];
                pf.PatientID = Convert.ToInt32(selectedAppointment.PatientInfo.Split('#')[1]);
                int patientid = int.Parse(selectedAppointment.PatientInfo.Split('#')[1]);
                pf.SetPatientID(patientid);
                pf.Show();
                // Set the PatientID property of the new window
               
                

                this.Close();
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_finance.Visibility = Visibility.Collapsed;
                tt_analytics.Visibility = Visibility.Collapsed;
                tt_patients.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_appointements.Visibility = Visibility.Collapsed;
                tt_ocr.Visibility = Visibility.Collapsed;
                tt_equip.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_finance.Visibility = Visibility.Visible;
                tt_analytics.Visibility = Visibility.Visible;
                tt_patients.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_appointements.Visibility = Visibility.Visible;
                tt_ocr.Visibility= Visibility.Visible;
                tt_equip.Visibility= Visibility.Visible;
            }
        }

        /*private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }*/

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void home_Click(object sender, RoutedEventArgs e)
        {
            DoctorDashboard ap = new DoctorDashboard();
            ap.Show();
            this.Close();
        }

        private void appointments_Click(object sender, RoutedEventArgs e)
        {
            AddAppointment ap = new AddAppointment();
            ap.Show();
            this.Close();
        }

        private void patients_Click(object sender, RoutedEventArgs e)
        {
            PatientList ap = new PatientList();
            ap.Show();
            this.Close();
        }

        private void analytics_Click(object sender, RoutedEventArgs e)
        {
            Analytics ap = new Analytics();
            ap.Show();
            this.Close();
        }

        private void finance_Click(object sender, RoutedEventArgs e)
        {
            Financce ap = new Financce();
            ap.Show();
            this.Close();
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings ap = new Settings();
            ap.Show();
            this.Close();
        }

        private void shortcut_appointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments ap = new Appointments();
            ap.Show();
            this.Close();
        }

        private void shortcut_patients_Click(object sender, RoutedEventArgs e)
        {
            PatientList ap = new PatientList();
            ap.Show();
            this.Close();
        }

        private void shortcut_analytics_Click(object sender, RoutedEventArgs e)
        {
            Analytics ap = new Analytics();
            ap.Show();
            this.Close();
        }

        private void shortcut_finance_Click(object sender, RoutedEventArgs e)
        {
            Financce ap = new Financce();
            ap.Show();
            this.Close();
        }

        private void file_Click(object sender, RoutedEventArgs e)
        {
            PatientFile ap = new PatientFile();
            ap.Show();
            this.Close();
        }

        private void file2_Click(object sender, RoutedEventArgs e)
        {
            PatientFile ap = new PatientFile();
            ap.Show();
            this.Close();
        }

        private void prescription1_Click(object sender, RoutedEventArgs e)
        {
            NewPrescription ap = new NewPrescription();
            ap.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewPrescription ap = new NewPrescription();
            ap.Show();
        }

        private void prescription3_Click(object sender, RoutedEventArgs e)
        {
            NewPrescription ap = new NewPrescription();
            ap.Show();
        }
        private void OCR_Click(object sender, RoutedEventArgs e)
        {
            OCR ap = new OCR();
            ap.Show();
            this.Close();
        }

        private void Equp_Click(object sender, RoutedEventArgs e)
        {
            EquipmentList eq = new EquipmentList();
            eq.Show();
            this.Close();
        }

        
    }
}
