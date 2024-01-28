using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    public partial class AddEquipment : Window
    {
        // Use the correct connection string name
        private readonly string connectionString;

        public AddEquipment()
        {
            InitializeComponent();

            // Initialize the connection string in the constructor
            connectionString = ConfigurationManager.ConnectionStrings["server=localhost;database=caretech;user=root;password=caretech;"]?.ConnectionString;
        }

        public void SaveEquipment(string equipmentName, string equipmentType, string vendor, decimal acquisitionCost, int expectedLifespan, DateTime maintenanceDate)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["server=localhost;database=caretech;user=root;password=caretech;"]?.ConnectionString;

            try
            {
                // Create a new SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a SqlCommand to execute the INSERT statement
                    string query = "INSERT INTO Equipment (EquipmentName, EquipmentType, Vendor, AcquisitionCost, ExpectedLifespan, MaintenanceDate) " +
                                   "VALUES (@Name, @Type, @Vendor, @Cost, @Lifespan, @Date)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Name", equipmentName);
                        command.Parameters.AddWithValue("@Type", equipmentType);
                        command.Parameters.AddWithValue("@Vendor", vendor);
                        command.Parameters.AddWithValue("@Cost", acquisitionCost);
                        command.Parameters.AddWithValue("@Lifespan", expectedLifespan);
                        command.Parameters.AddWithValue("@Date", maintenanceDate);

                        // Open the connection
                        connection.Open();

                        // Execute the command
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, show error message, etc.)
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the values from the textboxes and datepicker
            string equipmentName = NameTextBox.Text;
            string equipmentType = EquipmentTypeTextBox.Text;
            string vendor = VendorTextBox.Text;
            decimal acquisitionCost = Convert.ToDecimal(AcquisitionCostTextBox.Text);
            int expectedLifespan = Convert.ToInt32(ExpectedLifespanTextBox.Text);
            DateTime maintenanceDate = MaintenanceDatePicker.SelectedDate.GetValueOrDefault();

            // Call the SaveEquipment method to save the data
            SaveEquipment(equipmentName, equipmentType, vendor, acquisitionCost, expectedLifespan, maintenanceDate);

            // Optionally, you can display a success message or perform other actions after saving the data
            MessageBox.Show("Equipment saved successfully.");
        }
    }
}