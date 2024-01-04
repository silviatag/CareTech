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
using CareTech.classes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace CareTech
{
    /// <summary>
    /// Interaction logic for PatientFile.xaml
    /// </summary>
    public partial class PatientFile : Window
    {
        public int PatientID { get; set; }
        public PatientFile()
        {
            
            InitializeComponent();
            Chart_Loaded(Chart, new RoutedEventArgs());
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "progress: ",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },

            };
            idtxt.Text = PatientID.ToString();
            string[] Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            //YFormatter = value => value.ToString("%");

            //modifying the series collection will animate and update the chart


            DataContext = this;
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

        private void AddPrescriptionBtn_Click(object sender, RoutedEventArgs e)
        {
            NewPrescription ap = new NewPrescription();
            ap.Show();
        }





        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

       

       

        private void Chart_Loaded(object sender, RoutedEventArgs e)
        {

            // Assuming you have a PieChart named "Chart" in your XAML
            PieChart chart = (PieChart)sender;

            // Create a collection of PieSeries for your chart
            SeriesCollection seriesCollection = new SeriesCollection
    {
        new PieSeries
        {
            Title = "No improvement",
            Values = new ChartValues<double> { 10 }
        },
        new PieSeries
        {
            Title = "Recoverd",
            Values = new ChartValues<double> { 20 }
        },
        // Add more series as needed
    };

            // Set the SeriesCollection for the chart
            chart.Series = seriesCollection;

            // Configure other properties of the chart
            chart.LegendLocation = LegendLocation.Right;
            chart.InnerRadius = 80;

            // Refresh the chart (optional, as some changes may automatically trigger a refresh)
            chart.Update(true, true);
        }

        private Button previousButton;
        private SolidColorBrush originalColor;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Prescriptions.Visibility = Visibility.Collapsed;
            Analysis.Visibility = Visibility.Collapsed;
            Labs.Visibility = Visibility.Collapsed;
            ECG_Imaging.Visibility = Visibility.Collapsed;
            HistoryAssessment.Visibility = Visibility.Collapsed;
            Appointments_Fees.Visibility = Visibility.Collapsed;
            Comments.Visibility = Visibility.Collapsed;

            if (previousButton != null && previousButton != clickedButton)
            {
                // Revert previous button content color
                previousButton.Foreground = originalColor;

            }

            previousButton = clickedButton;
            originalColor = (SolidColorBrush)clickedButton.Foreground;

            // Change button content color to black
            clickedButton.Foreground = Brushes.Black;
            if (clickedButton.Content.Equals("History"))
            {
                HistoryAssessment.Visibility = Visibility.Visible;
            }
            else if (clickedButton.Content.Equals("Analysis"))
            {
                Analysis.Visibility = Visibility.Visible;
            }
            else if (clickedButton.Content.Equals("Prescriptions"))
            {
                Prescriptions.Visibility = Visibility.Visible;
            }
            else if (clickedButton.Content.Equals("Appointments and Fees"))
            {
                Appointments_Fees.Visibility = Visibility.Visible;
            }
            else if(clickedButton.Content.Equals("Labs"))
            {
                Labs.Visibility= Visibility.Visible;
            }
            else if(clickedButton.Content.Equals("ECG/Imaging"))
            {
                ECG_Imaging.Visibility = Visibility.Visible;
            }
            else if (clickedButton.Content.Equals("Comments"))
            {
                Comments.Visibility = Visibility.Visible;
            }

            // Create a line with the width of the button and color black
            Line line = new Line
            {
                X1 = 0,
                Y1 = clickedButton.ActualHeight / 2,
                X2 = clickedButton.ActualWidth,
                Y2 = clickedButton.ActualHeight / 2,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            // Find the parent grid of the button and add the line to it
            if (clickedButton.Parent is Grid grid)
            {
                grid.Children.Add(line);
                Grid.SetRow(line, Grid.GetRow(clickedButton)); // Set the line in the same row as the button
            }
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
    }
}
