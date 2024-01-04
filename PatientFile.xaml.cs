using System;
using System.Collections.Generic;
using System.Globalization;
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
using MindFusion.Excel.Wpf;

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
            string[] Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            //YFormatter = value => value.ToString("%");

            //modifying the series collection will animate and update the chart
           

            DataContext = this;
            settingdict();
            //MessageBox.Show(PatientID.ToString());
           


        }
       
        public void SetPatientID(int patientId)
        {
            PatientID = patientId;
            // You can use the PatientID value as needed in the PatientFile window
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
            DB db = new DB();
            NewPrescription ap = new NewPrescription();
            ap.Show();
            ap.name_agetxt.Text = db.GetPatientById(PatientID).Name + ", " + db.GetPatientById(PatientID).Age.ToString();
            ap.SetPatientID(PatientID);
        }
        private Grid GenerateDateGrid(int day, string month)
        {
            // Create the main Grid
            Grid dateGrid = new Grid
            {
                Width = 120,
                Height = 100,
                VerticalAlignment = System.Windows.VerticalAlignment.Top
            };

            // Add Rectangle to dateGrid
            dateGrid.Children.Add(new Rectangle
            {
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(242, 154, 52)),
                Opacity = 0.4,
                RadiusX = 20,
                RadiusY = 20,
                Height = 90,
                Width = 90
            });

            // Create a StackPanel for text blocks in dateGrid
            StackPanel textStackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Height = 85,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom
            };

            // Add TextBlocks to textStackPanel
            textStackPanel.Children.Add(new TextBlock
            {
                Text = day.ToString(),
                FontSize = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Inter"),
                Height = 30,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom
            });

            textStackPanel.Children.Add(new TextBlock
            {
                Text = month,
                FontSize = 26,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Inter"),
                Height = 35,
                TextAlignment = TextAlignment.Center
            });

            // Add textStackPanel to dateGrid
            dateGrid.Children.Add(textStackPanel);

            return dateGrid;
        }
        private Grid GeneratePrescriptionHeaderGrid(string prescriptionNumber)
        {
            // Create the main Grid
            Grid prescriptionHeaderGrid = new Grid
            {
                Height = 60,
                Width = 860,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right
            };

            // Add TextBlock to prescriptionHeaderGrid
            prescriptionHeaderGrid.Children.Add(new TextBlock
            {
                Text = $"Prescription {prescriptionNumber}",
                FontSize = 20,
                Foreground = Brushes.Gray,
                FontWeight = FontWeights.Medium,
                FontFamily = new FontFamily("Inter"),
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            });

            return prescriptionHeaderGrid;
        }
        private Grid GenerateVitalSignsGrid()
        {
            // Create the main Grid
            Grid vitalSignsGrid = new Grid
            {
                Height = 40
            };

            // Add Rectangle to vitalSignsGrid
            vitalSignsGrid.Children.Add(new Rectangle
            {
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(231, 231, 231)),
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(212, 212, 212))
            });

            // Add inner Grid to vitalSignsGrid
            Grid innerGrid = new Grid
            {
                Width = 850,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right
            };

            // Add TextBlock to innerGrid
            innerGrid.Children.Add(new TextBlock
            {
                Text = "Clinical Notes",
                FontSize = 20,
                FontWeight = FontWeights.Medium,
                FontFamily = new FontFamily("Inter"),
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            });

            // Add inner Grid to vitalSignsGrid
            vitalSignsGrid.Children.Add(innerGrid);

            return vitalSignsGrid;
        }
        public UIElement GenerateSymptomsGrid(string name)
        {
            var symptomsGrid = new Grid
            {
                Height = 40
            };

            var rectangle = new Rectangle
            {
                Fill = Brushes.Transparent,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(212, 212, 212))
            };

            var innerGrid = new Grid
            {
                Width = 850
            };

            var textBlock = new TextBlock
            {
                Text = name,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                FontSize = 17,
                FontWeight = FontWeights.Medium,
                FontFamily = new FontFamily("Inter"),
                Foreground = Brushes.Gray
            };

            // Add controls to innerGrid
            innerGrid.Children.Add(textBlock);

            // Add controls to symptomsGrid
            symptomsGrid.Children.Add(rectangle);
            symptomsGrid.Children.Add(innerGrid);

            return symptomsGrid;
        }
        public UIElement GenerateTextBlockGrid(string text)
        {
            var textBlockGrid = new Grid
            {
                Height = 80
            };

            var textBlock = new TextBlock
            {
                Text = text,
                FontSize = 15,
                FontFamily = new System.Windows.Media.FontFamily("Inter"),
                Width = 800,
                Height = 50
            };

            // Add controls to textBlockGrid
            textBlockGrid.Children.Add(textBlock);

            return textBlockGrid;
        }

        Dictionary<int, string> monthAbbreviations = new Dictionary<int, string>();

        // Populate the dictionary
        void settingdict()
        {
            for (int monthNumber = 1; monthNumber <= 12; monthNumber++)
            {
                string abbreviation = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(monthNumber);
                monthAbbreviations.Add(monthNumber, abbreviation);
            }
        }
        // this is how we use it:    monthAbbreviations.TryGetValue(targetMonth(int), out string abbreviation)
        void generateALLPresc(int pid)
        {
            prescmain.Children.Clear();
            Console.WriteLine(pid.ToString());
            DB db = new DB();
            List<Prescription> prescriptions = db.GetPrescriptionsByPatientID(pid);
            foreach (Prescription prescription in prescriptions)
            {
                generatePresc(prescription);
            }

        }

        
        
    void generatePresc(Prescription p)
        {
            StackPanel s = new StackPanel();
            s.Orientation=Orientation.Horizontal;
            s.Height= 500;
            
            Grid grid = new Grid();
            grid.Width = 870;
            Rectangle r= new Rectangle();
            r.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(240, 240, 240));
            r.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(212, 212, 212));
            grid.Children.Add(r);
            StackPanel sv = new StackPanel();
            sv.Orientation=Orientation.Vertical;
            sv.Children.Add(GeneratePrescriptionHeaderGrid("#"+p.PrescriptionID.ToString()));
            sv.Children.Add(GenerateVitalSignsGrid());
            sv.Children.Add(GenerateSymptomsGrid("Symptoms"));
            sv.Children.Add(GenerateTextBlockGrid((p.Coughing?"coughing":"")+", "+ (p.Nausea? "nausea" : "")+", "+ (p.Vomiting? "vomiting" : "")+", "+ (p.Headache ? "headache" : "")));
            sv.Children.Add(GenerateSymptomsGrid("Observations"));
            sv.Children.Add(GenerateTextBlockGrid(p.Diagnosis+",  additional note: "+p.AdditionalNotes));
            sv.Children.Add(GenerateSymptomsGrid("Medications"));
            sv.Children.Add(GenerateTextBlockGrid(p.MedicineName));



            grid.Children.Add(sv);
            string abbreviation = monthAbbreviations.TryGetValue(p.dateCreated.Month, out var result) ? result : null;

            s.Children.Add(GenerateDateGrid(p.dateCreated.Day, result)); //monthAbbreviations.TryGetValue(targetMonth(int), out string abbreviation)
            s.Children.Add(grid);
            prescmain.Children.Add(s);
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
                generateALLPresc(PatientID);
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

        private void zeft_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
