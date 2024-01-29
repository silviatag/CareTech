using CareTech.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {
        public Appointments()
        {
            InitializeComponent();
            string today = (DateTime.Today).ToString("dd-MM-yyyy");
            TodayDate.Text = today;
            //dateSelected(selectedDate);

        }

        //DateTime selectedDate;
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                DateTime selectedDateTime = (DateTime)e.AddedItems[0];
                DateTime selectedDate = selectedDateTime.Date;
                calendar.SelectedDate = selectedDate;
                //TodayDate.Text= selectedDate.ToString();
                string formattedDate = selectedDate.ToString("dd-MM-yyyy");
                TodayDate.Text = formattedDate;
            }
        }

        private void ListViewItem_MouseEnter(object sender, System.Windows.Forms.MouseEventArgs e)
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

        private void emr_Click(object sender, RoutedEventArgs e)
        {
            PatientFile ap = new PatientFile();
            ap.Show();
            this.Close();
        }
        System.Timers.Timer stopwatchTimer = new System.Timers.Timer();
        int h, m, s, ms;

        private void initializeStopwatch()
        {
            stopwatchTimer.Interval = 1;
            stopwatchTimer.Elapsed += onTimeEvent;
        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {
            stopwatchTimer.Start();
        }

        private void stop_button_Click(object sender, RoutedEventArgs e)
        {
            stopwatchTimer.Stop();
        }

        private void reset_button_Click(object sender, RoutedEventArgs e)
        {
            stopwatchTimer.Stop();
            h = m = s = ms = 0;
            stopwatch_text.Text = "00:00:00:00";
        }

        private void onTimeEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                ms += 1;

                if (ms == 100)
                {
                    ms = 0;
                    s += 1;
                }

                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }

                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                stopwatch_text.Text = string.Format("{0}:{1}:{2}:{3}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'), ms.ToString().PadLeft(2, '0'));
            }));
        }
    }
}