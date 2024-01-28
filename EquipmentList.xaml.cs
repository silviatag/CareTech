using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Interaction logic for EquipmentList.xaml
    /// </summary>
    public partial class EquipmentList : Window
    {

            public readonly string connectionString;

            private ObservableCollection<EquipmentItem> equipmentList;

            public EquipmentList()
            {
                InitializeComponent();

            connectionString = "server=localhost;database=caretech;user=root;password=caretech;"; ;

                equipmentList = new ObservableCollection<EquipmentItem>();
                EquipmentDataGrid.ItemsSource = equipmentList;

                LoadEquipmentData();
            }

            private void LoadEquipmentData()
            {
                try
                {
                    equipmentList.Clear();
                String connectionString = "server=localhost;database=caretech;user=root;password=caretech;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT EquipmentName, EquipmentType, Vendor, AcquisitionCost, ExpectedLifespan, MaintenanceDate FROM Equipment";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    EquipmentItem item = new EquipmentItem
                                    {
                                        EquipmentName = reader["EquipmentName"].ToString(),
                                        EquipmentType = reader["EquipmentType"].ToString(),
                                        Vendor = reader["Vendor"].ToString(),
                                        AcquisitionCost = Convert.ToDecimal(reader["AcquisitionCost"]),
                                        ExpectedLifespan = Convert.ToInt32(reader["ExpectedLifespan"]),
                                        MaintenanceDate = Convert.ToDateTime(reader["MaintenanceDate"])
                                    };

                                    equipmentList.Add(item);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
            AddEquipment eq = new AddEquipment();
            eq.Show();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddEquipment eq= new AddEquipment();
            eq.Show();
        }



        public class EquipmentItem
        {
            public string EquipmentName { get; set; }
            public string EquipmentType { get; set; }
            public string Vendor { get; set; }
            public decimal AcquisitionCost { get; set; }
            public int ExpectedLifespan { get; set; }
            public DateTime MaintenanceDate { get; set; }
        }


    }


}
