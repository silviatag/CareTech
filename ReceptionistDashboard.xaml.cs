﻿using CareTech.classes;
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

namespace CareTech
{
    /// <summary>
    /// Interaction logic for ReceptionistDashboard.xaml
    /// </summary>
    public partial class ReceptionistDashboard : Window
    {
        public ReceptionistDashboard()
        { 

            InitializeComponent();
            LoadAppointments();
            DB db = new DB();
            List<_Appointment> appointments = db.GetAppointmentsFromNow().OrderBy(appointment => appointment.AppointmentTime).ToList();
            _Appointment nextApp = appointments[0];
            nextAppointment.Text = nextApp.AppointmentTime.ToString();
            TotalAppointment.Text = (db.CountConsultationAppointmentsForToday() + db.CountFollowUpAppointmentsForToday()).ToString();
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
                    Text = p.Name + " #" + p.PatientID,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    FontSize = 15
                };

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
                tt_ocr.Visibility = Visibility.Visible;
                tt_equip.Visibility = Visibility.Visible;
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
            ReceptionistDashboard eq = new ReceptionistDashboard();
            eq.Show();
            this.Close();
        }





    }

}



