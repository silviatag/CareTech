using CareTech.classes;
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
using System.Windows.Shapes;

namespace CareTech
{
    /// <summary>
    /// Interaction logic for NewPrescription.xaml
    /// </summary>
    public partial class NewPrescription : Window
    {
        public int PatientID { get; set; }

        DB db =new DB();
        Doctor d = DB.GetDoctorById(5);
        public ObservableCollection<PrescriptionItem> PrescriptionItems { get; set; }


        public NewPrescription()
        {
            InitializeComponent();
            prescDate.Text = DateTime.Today.ToString().Split()[0];
            docNametxt.Text = d.DoctorName;
            PrescriptionItems = new ObservableCollection<PrescriptionItem>();
            listView.ItemsSource = PrescriptionItems;
        }
        private void AddRow(string drug, string dose, string frequency)
        {
            PrescriptionItems.Add(new PrescriptionItem { Drug = drug, Dose = dose, Frequency = frequency });
        }


        // Call this method when you want to add a new row, e.g., on a button click
        private void AddRowButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem medSelectedComboBoxItem = med.SelectedItem as ComboBoxItem;
            string drug = medSelectedComboBoxItem.Content?.ToString();
            string dose = dosetxt.Text;
            ComboBoxItem freqSelectedComboBoxItem = freqcbx.SelectedItem as ComboBoxItem;
            string frequency = freqSelectedComboBoxItem.Content?.ToString();


            
            AddRow(drug, dose, frequency);
        }
        public class PrescriptionItem
        {
            public string Drug { get; set; }
            public string Dose { get; set; }
            public string Frequency { get; set; }
        }
        public void SetPatientID(int patientId)
        {
            PatientID = patientId;
            // You can use the PatientID value as needed in the PatientFile window
        }



        private void save_Click(object sender, RoutedEventArgs e)
        {
            int weight = int.Parse(weighttxt.Text);
            int height = int.Parse(heighttxt.Text);
            bool headache;
            bool nausea;
            bool vomiting;
            bool coughign;
            bool chestpain;
            if(headacheyes.IsChecked == true) headache = true;
            else headache = false;
            if(nauseayes.IsChecked == true) nausea = true;
            else nausea= false;
            if(vomitingyes.IsChecked == true) vomiting = true;
            else vomiting = false;
            if(coughingyes.IsChecked == true) coughign = true;
            else coughign = false;
            if(chestpainyes.IsChecked == true) chestpain = true;
            else chestpain = false;
            ComboBoxItem DiagnosisSelectedComboBoxItem = diagnosis.SelectedItem as ComboBoxItem;
            string Diagnosis = DiagnosisSelectedComboBoxItem.Content?.ToString();
            ComboBoxItem medSelectedComboBoxItem = med.SelectedItem as ComboBoxItem;
            string Medication = medSelectedComboBoxItem.Content?.ToString();
            int dosage = int.Parse(dosetxt.Text);
            ComboBoxItem freqSelectedComboBoxItem = freqcbx.SelectedItem as ComboBoxItem;
            string frequency = freqSelectedComboBoxItem.Content?.ToString();

            Prescription presc = new Prescription(PatientID, 5, weight, height, headache, nausea, vomiting, coughign, Diagnosis, Medication, dosage, frequency, addnotetxt.Text);

            DB db = new DB();
            db.AddPrescription(presc);


        }


    }
}
