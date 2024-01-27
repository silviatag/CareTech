using CareTech.classes;
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
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {
        public Appointments()
        {
            InitializeComponent();
            GenerateDynamicUI(DateTime.Today);
            string today = (DateTime.Today).ToString("dd-MM-yyyy");
            TodayDate.Text = today;
            //dateSelected(selectedDate);
            
        }
        private void GenerateDynamicUI(DateTime sDate)
        {
            appTable.Children.Clear();
            DB db = new DB();
            List<_Appointment> appointments = db.GetAppointmentsForDate(sDate);
            foreach (var app in appointments)
            {
                Patient p = db.GetPatientById(app.PatientID);
                // Create the main grid
                Grid dynamicGrid = new Grid();
                dynamicGrid.Height = 57;

                // Create the rectangle
                Rectangle rectangle = new Rectangle();
                rectangle.Stroke = Brushes.Gray;
                rectangle.RadiusX = 15;
                rectangle.RadiusY = 15;
                dynamicGrid.Children.Add(rectangle);

                // Create the inner grid
                Grid innerGrid = new Grid();

                // Create a stack panel
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                // Create three inner grids
                for (int i = 0; i < 3; i++)
                {
                    Grid textBlockGrid = new Grid();
                    textBlockGrid.Width = 233;

                    TextBlock textBlock = new TextBlock();
                    textBlock.Foreground = Brushes.Black;
                    textBlock.FontSize = 20;
                    textBlock.FontWeight = FontWeights.Medium;
                    textBlock.FontFamily = new FontFamily("Inter");
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.TextAlignment = TextAlignment.Center;

                    // Set different text content for each TextBlock
                    if (i == 0)
                    {
                        textBlock.Text = app.AppointmentTime.ToString();
                    }
                    else if (i == 1)
                    {
                        textBlock.Text = p.Name;

                        // Add a second TextBlock for patient number
                        TextBlock patientNumberTextBlock = new TextBlock();
                        patientNumberTextBlock.Text = "#" + p.PatientID;
                        patientNumberTextBlock.Foreground = Brushes.Gray;
                        patientNumberTextBlock.FontSize = 12;
                        patientNumberTextBlock.FontWeight = FontWeights.Medium;
                        patientNumberTextBlock.FontFamily = new FontFamily("Inter");
                        patientNumberTextBlock.VerticalAlignment = VerticalAlignment.Top;
                        patientNumberTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                        patientNumberTextBlock.TextAlignment = TextAlignment.Center;
                        patientNumberTextBlock.Margin = new Thickness(96, 38, 0, 0);

                        textBlockGrid.Children.Add(patientNumberTextBlock);
                    }
                    else if (i == 2)
                    {
                        textBlock.Text = app.AppointmentType;
                    }

                    textBlockGrid.Children.Add(textBlock);
                    stackPanel.Children.Add(textBlockGrid);
                }

                innerGrid.Children.Add(stackPanel);
                dynamicGrid.Children.Add(innerGrid);

                // Add the dynamically generated UI to the existing XAML structure
                appTable.Children.Add(dynamicGrid);
            }

        }

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
                GenerateDynamicUI(selectedDate);
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
    }
}
