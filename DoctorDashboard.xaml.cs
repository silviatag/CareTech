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





        private void LoadAppointments()
        {
            DB db = new DB();
            List<_Appointment> appointments = db.GetAppointmentsFromNow();
            foreach (var app in appointments.OrderBy(a => a.AppointmentTime).ToList())
            {
                Patient p = db.GetPatientById(app.PatientID);
                StackPanel horizontalStackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Height = 40
                };
                Grid nameGrid = new Grid
                {
                    Width = 383
                };

                TextBlock nametxt = new TextBlock
                {
                    Text = p.Name+" #"+p.PatientID,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    FontSize=15
                };

                // Add the TextBlock to the Grid
                nameGrid.Children.Add(nametxt);

                // Add the Grid to the StackPanel
                horizontalStackPanel.Children.Add(nameGrid);

                Grid timeGrid = new Grid
                {
                    Width = 383
                };

                TextBlock timetxt = new TextBlock
                {
                    Text = app.AppointmentTime.ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    FontSize =15
                };

                // Add the TextBlock to the Grid
                timeGrid.Children.Add(timetxt);

                // Add the Grid to the StackPanel
                horizontalStackPanel.Children.Add(timeGrid);

                Grid DetailsGrid = new Grid
                {
                    Width = 390
                };
                Rectangle rec = new Rectangle
                {
                    Fill = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#7163ba")),
                    RadiusX =15,
                    RadiusY =15,
                    StrokeThickness = 0,
                    Width = 100,
                    Height = 30
                };
                DetailsGrid.Children.Add(rec);
                Button detailsBtn = new Button
                {
                    Name="id"+ p.PatientID.ToString(),
                    Content = "Details",
                    FontFamily = new System.Windows.Media.FontFamily("Inter"),
                    FontWeight = FontWeights.Medium,
                    Foreground= System.Windows.Media.Brushes.White,
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
                appsPanel.Children.Add(horizontalStackPanel);
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
            Appointments ap = new Appointments();
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

        
        private void OCR_Click(object sender, RoutedEventArgs e)
        {
            AddMember ap = new AddMember();
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
