using CareTech.classes;
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
        public readonly string connectionString;

        public AddEquipment()
        {
            InitializeComponent();

            // Initialize the connection string in the constructor
            connectionString = "server=localhost;database=caretech;user=root;password=caretech;";
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
            Equipment eq = new Equipment(equipmentName,equipmentType,vendor,acquisitionCost,expectedLifespan,maintenanceDate);
            DB db = new DB();
            db.InsertEquipment(eq);
            MessageBox.Show("Equipment saved successfully.");
        }
    }
}