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
using System.Windows.Shapes;

namespace CareTech
{
    /// <summary>
    /// Interaction logic for PatientList.xaml
    /// </summary>
    public partial class PatientList : Window
    {
        public PatientList()
        {
            InitializeComponent();
            LoadAppointments();
        }

        public class AppointmentViewModel
        {
            public string PatientInfo { get; set; }
        }
        private ObservableCollection<AppointmentViewModel> appointmentsViewModel = new ObservableCollection<AppointmentViewModel>();

        private void LoadAppointments()
        {
            DB db = new DB();
            List<Patient> patients = db.GetAllPatients();
            foreach (Patient p in patients)
            {
                AppointmentViewModel appointmentViewModel = new AppointmentViewModel
                {
                    PatientInfo = p.Name + " #" + p.PatientID
                };
                appointmentsViewModel.Add(appointmentViewModel);
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
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_finance.Visibility = Visibility.Visible;
                tt_analytics.Visibility = Visibility.Visible;
                tt_patients.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_appointements.Visibility = Visibility.Visible;
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

        private void analysis_Click(object sender, RoutedEventArgs e)
        {
            Analytics analytics = new Analytics();
            analytics.Show();
            this.Close();
        }

        private void finance_Click(object sender, RoutedEventArgs e)
        {
            Financce financce = new Financce();
            financce.Show();
            this.Close();
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Close();
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            PatientFile ap = new PatientFile();
            ap.Show();
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddPatient addPatient = new AddPatient();
            addPatient.Show();
        }
    }
}
