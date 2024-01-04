using MindFusion.Scheduling;
using System;
using System.Collections.Generic;
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
using MindFusion.Scheduling.Wpf.Samples.CS.DualView;
using Xceed;
using Syncfusion;
using CareTech.classes;

namespace CareTech
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        public AddAppointment()
        {
            InitializeComponent();
            DB dB = new DB();
            dB.PopulateDoctorDropdown(pickAdoc);
            _schedule.Schedule = _calendar.Schedule;

            // Select the current date
            _calendar.Selection.Set(DateTime.Today);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF5cWWJCf0x3THxbf1x0ZFFMZV9bR3dPIiBoS35RdURhW39fdnFWRWJcUEJ1");

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
                tt_ocr.Visibility = Visibility.Visible;
                tt_equip.Visibility = Visibility.Visible;
            }
        }
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
        void Selection_Changed(object sender, EventArgs e)
        {
            if (_calendar.Selection.IsEmpty)
            {
                _schedule.TimetableSettings.Dates.Clear();
                return;
            }

            _schedule.BeginInit();
            _schedule.TimetableSettings.Dates.Clear();
            _schedule.TimetableSettings.Dates.Add((DateTime)_calendar.Selection.Ranges[0]);
            _schedule.EndInit();
        }
        private void AddBusyTimeAppointment(DateTime? datetime, string name)
        {
            if (datetime.HasValue)
            {
                var busyAppointment = new Appointment
                {
                    Subject = name,
                    StartTime = datetime.Value,
                    EndTime = datetime.Value.AddHours(2)
                };
                _schedule.Schedule.Items.Add(busyAppointment);
            }
        }

        private void book_click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            if (NewPatientcheckbox.IsChecked == false)
            {
                AddBusyTimeAppointment(dateTimeEdit.DateTime, "#" + PatientID.Text + " , " + PatientName.Text + " , " + typeOfVisit.Text);
                DateTime? selectedDateTime = dateTimeEdit.DateTime;
                DateTime appdate;
                TimeSpan apptime;
                appdate = selectedDateTime.Value.Date; // Extract date
                apptime = selectedDateTime.Value.TimeOfDay; // Extract time
                ComboBoxItem typeSelectedComboBoxItem = typeOfVisit.SelectedItem as ComboBoxItem;
                string apptype = typeSelectedComboBoxItem.Content?.ToString();
                int patientid = int.Parse(PatientID.Text);
                ComboBoxItem docSelectedComboBoxItem = pickAdoc.SelectedItem as ComboBoxItem;
                string doc = pickAdoc.SelectedItem?.ToString();
                string[] words = doc.Split(' ');
                string docidstring = words[2];
                int docid = int.Parse(docidstring);
                _Appointment app = new _Appointment(appdate, apptime, apptype, 300, patientid, docid);
                
                db.InsertAppointment(app);
            }
            else
            {
                Patient p = new Patient(NATIONALID.Text,PatientName.Text, PhoneNumber.Text);
                DB.CreateTempPatient(p);
                AddBusyTimeAppointment(dateTimeEdit.DateTime,"#"+p.PatientID +" "+PatientName.Text + " , " + typeOfVisit.Text);
                DateTime? selectedDateTime = dateTimeEdit.DateTime;
                DateTime appdate;
                TimeSpan apptime;
                appdate = selectedDateTime.Value.Date; // Extract date
                apptime = selectedDateTime.Value.TimeOfDay; // Extract time
                ComboBoxItem typeSelectedComboBoxItem = typeOfVisit.SelectedItem as ComboBoxItem;
                string apptype = typeSelectedComboBoxItem.Content?.ToString();
                
                ComboBoxItem docSelectedComboBoxItem = pickAdoc.SelectedItem as ComboBoxItem;
                string doc = pickAdoc.SelectedItem?.ToString();
                string[] words = doc.Split(' ');
                string docidstring = words[2];
                int docid = int.Parse(docidstring);
                _Appointment app = new _Appointment(appdate, apptime, apptype, 300, p.PatientID, docid);

                db.InsertAppointment(app);

            }
        }

        private void NewPatientcheckbox_Checked(object sender, RoutedEventArgs e)
        {
            newPatientInfo.Visibility= Visibility.Visible;
            PatientID.IsEnabled = false;
            PatientID.Background = Brushes.LightGray;
        }
        private void NewPatientcheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            newPatientInfo.Visibility = Visibility.Hidden;
            PatientID.IsEnabled = true;
            PatientID.Background= Brushes.White;
        }

        private void PatientID_TextChanged(object sender, TextChangedEventArgs e)
        {
            DB db = new DB();
            List<string> patients = db.GetPatientIdsAndNames();
            if (!string.IsNullOrEmpty(PatientID.Text))
            {
                patientslist.Items.Clear();
                patientslist.Visibility= Visibility.Visible;
                foreach(string str in patients )
                {
                    if(str.StartsWith(PatientID.Text))
                    {
                        patientslist.Items.Add(str);
                    }
                }
            }
            else if(PatientID.Text=="")
            {
                patientslist.Items.Clear();
                foreach (string str in patients)
                {
                    patientslist.Items.Add(str);
                }    
            }
        }

        private void patientListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientslist.SelectedItem != null)
            {
                string selectedPatientInfo = patientslist.SelectedItem.ToString();

                // Extract the first word (patientID) from the selected item
                string[] words = selectedPatientInfo.Split(' ');
                string selectedPatientID = words[0];

                // Perform any action with the extracted patientID, for example:
                PatientID.Text= selectedPatientID;
                // Hide the ListBox
                patientslist.Visibility = Visibility.Hidden;
            }
        }
    }
}

    