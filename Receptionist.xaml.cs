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
    /// Interaction logic for Receptionist.xaml
    /// </summary>
    public partial class Receptionist : Window
    {
        public Receptionist()
        {
            InitializeComponent();
            LoadAppointments();
            DB db = new DB();
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
    }

}

