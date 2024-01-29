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
            LoadPatients();
        }

        public class AppointmentViewModel
        {
            public string PatientInfo { get; set; }
        }
        private ObservableCollection<AppointmentViewModel> appointmentsViewModel = new ObservableCollection<AppointmentViewModel>();

        private void Details_CLick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            PatientFile pf = new PatientFile();
            pf.idtxt.Text = btn.Name.Split('d')[1];
            pf.PatientID = Convert.ToInt32(btn.Name.Split('d')[1]);
            int patientid = int.Parse(btn.Name.Split('d')[1]);
            pf.SetPatientID(patientid);
            pf.Show();
            this.Close();
        }
        private void LoadPatients()
        {
            DB db = new DB();
            List<Patient> patients= db.GetAllPatients();
            foreach (var p in patients)
            {
                StackPanel horizontalStackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Height = 60
                };
                Grid imageGrid = new Grid
                {
                    Width = 116
                };

                Image imageFill = new Image();
                imageFill.Source = new BitmapImage(new Uri("/images/profile.jpg", UriKind.Relative));


                // Add the TextBlock to the Grid
                imageGrid.Children.Add(imageFill);

                // Add the Grid to the StackPanel
                horizontalStackPanel.Children.Add(imageGrid);

                Grid nameGrid = new Grid
                {
                    Width = 233
                };

                TextBlock nametxt = new TextBlock
                {
                    Text = p.Name ,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    FontSize = 20,
                    FontWeight = FontWeights.SemiBold
                };

                // Add the TextBlock to the Grid
                nameGrid.Children.Add(nametxt);

                // Add the Grid to the StackPanel
                horizontalStackPanel.Children.Add(nameGrid);

                Grid idGrid = new Grid
                {
                    Width = 350
                };

                TextBlock idtxt = new TextBlock
                {
                    Text = "#"+p.PatientID.ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    FontSize = 15,
                    FontWeight = FontWeights.Medium
                };

                // Add the TextBlock to the Grid
                idGrid.Children.Add(idtxt);

                // Add the Grid to the StackPanel
                horizontalStackPanel.Children.Add(idGrid);

                Grid phoneGrid = new Grid
                {
                    Width = 350
                };

                TextBlock phonetxt = new TextBlock
                {
                    Text = p.PhoneNumber,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    FontSize = 20,
                    FontWeight = FontWeights.Medium
                };

                // Add the TextBlock to the Grid
                phoneGrid.Children.Add(phonetxt);

                // Add the Grid to the StackPanel
                horizontalStackPanel.Children.Add(phoneGrid);


                Grid DetailsGrid = new Grid
                {
                    Width = 390
                };
                Rectangle rec = new Rectangle
                {
                    Fill = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#7163ba")),
                    RadiusX = 15,
                    RadiusY = 15,
                    StrokeThickness = 0,
                    Width = 100,
                    Height = 30
                };
                DetailsGrid.Children.Add(rec);
                Button detailsBtn = new Button
                {
                    Name = "id" + p.PatientID.ToString(),
                    Content = "Details",
                    FontFamily = new System.Windows.Media.FontFamily("Inter"),
                    FontWeight = FontWeights.Medium,
                    Foreground = System.Windows.Media.Brushes.White,
                    Width = 100,
                    Height = 30,
                    FontSize = 15,
                    Background = System.Windows.Media.Brushes.Transparent,
                    BorderThickness = new Thickness(0),

                };
                detailsBtn.Click += Details_CLick;
                DetailsGrid.Children.Add(detailsBtn);

                // Add the Grid to the StackPanel
                horizontalStackPanel.Children.Add(DetailsGrid);
                patientsStack.Children.Add(horizontalStackPanel);
            }
        }

       /* private void LoadAppointments()
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
        }*/
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
