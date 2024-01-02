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
using System.Xml.Linq;
using CareTech.classes;
using Org.BouncyCastle.Asn1.Cmp;

namespace CareTech
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        public AddPatient()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            //patient
            string nationalid = nationalID.Text;
            string Pname = name.Text;
            DateTime? DOB = dob.SelectedDate;
            string Address = address.Text;
            string PatientPhoneNumber = phoneNumber.Text;
            ComboBoxItem GenderSelectedComboBoxItem = gender.SelectedItem as ComboBoxItem;
            string Gender= GenderSelectedComboBoxItem.Content?.ToString();
            ComboBoxItem MStatusSelectedComboBoxItem = maritalStatus.SelectedItem as ComboBoxItem;
            string MaritalStatus = MStatusSelectedComboBoxItem.Content?.ToString();
            int Height = int.Parse(height.Text);
            int Weight = int.Parse(weight.Text);
            ComboBoxItem bGroupSelectedComboBoxItem = bloodGroup.SelectedItem as ComboBoxItem;
            string BloodGroup= bGroupSelectedComboBoxItem.Content?.ToString();
            Patient p = new Patient(nationalid, Pname, DOB, Address, PatientPhoneNumber, Gender, MaritalStatus, Height, Weight, BloodGroup);


            //emergency contact
            string Ename = emrgName.Text;
            string EphoneNumber = emrgNum.Text;
            ComboBoxItem RelationSelectedComboBoxItem = relationship.SelectedItem as ComboBoxItem;
            string Relation = RelationSelectedComboBoxItem.Content?.ToString();
            EmergencyContact contact = new EmergencyContact(p.PatientID, Ename, EphoneNumber,Relation);

            //medical assessment
            bool Hypertension = HypertensionYes.IsChecked??false;
            bool HeartAttack= HeartAttackYes.IsChecked??false;
            bool HighCholestrol = HighCholestrolYes.IsChecked??false;
            bool Stroke= StrokeYes.IsChecked?? false;
            bool Cancer= CancerYes.IsChecked ?? false;
            bool HeartFailure= HeartFailureYes.IsChecked ?? false;
            bool ClottingDisorder= ClottingDisorderYes.IsChecked ?? false;
            bool Diabetes= DiabetesYes.IsChecked ?? false;
            bool KidneyDisease= KidneyDiseaseYes.IsChecked ?? false;
            bool ThyroidDisease= ThyroidDiseaseYes.IsChecked ?? false;
            ComboBoxItem AlcoholSelectedComboBoxItem = AlcoholConsumptionCombo.SelectedItem as ComboBoxItem;
            string alcoholconsumption= AlcoholSelectedComboBoxItem.Content?.ToString();
            bool PencillinAllergy= PencillinAllergyYes.IsChecked ?? false;
            bool AspirinAllergy= AspirinAllergyYes.IsChecked ?? false;
            bool SulfaDrugsAllergy = SulfaDrugAllergyYes.IsChecked ?? false;
            bool IbuprofenAllergy= IbuprofenAllergyYes.IsChecked ?? false;
            bool ColdHeatIntolerance = ColdHeatIntoleranceYes.IsChecked ?? false;
            bool DrugResistantInfection= DrugResistantInfYes.IsChecked ?? false;
            bool AbdominalPain = AbdominalpainYes.IsChecked ?? false;
            bool Nausea= NauseaYes.IsChecked ?? false;
            bool bloodyVomit= BloodyVomitYes.IsChecked ?? false;
            bool UlcerDisease= UlcerDiseaseYes.IsChecked ?? false;
            bool LossOfApetite_HeartBurn= ApetiteLossYes.IsChecked ?? false;
            bool Fatigue_NightSweats= FatigueYes.IsChecked ?? false;
            bool Fever_Chills= FeverYes.IsChecked ?? false;
            bool CartoidSurgery= CartoidSurgeryYes.IsChecked ?? false;
            DateTime? CartoidSurgeryDate= CartoidSurgeryDatepicker.SelectedDate;
            bool HeartStent= HeartStentYes.IsChecked ?? false;
            DateTime? HeartStentDate=HeartStentDatepicker.SelectedDate;
            bool laparoscopy= LaparoscopyYes.IsChecked ?? false;
            DateTime? laparoscopyDate= LaparoscopyDatepicker.SelectedDate;
            bool Pacemaker= PacemakerYes.IsChecked ?? false;
            DateTime? PacemakerDate= PacemakerDatepicker.SelectedDate;
            string OtherSurgeries= OtherSurgeriesTxtbx.Text;
            MedicalAssessment m = new MedicalAssessment(p.PatientID, Hypertension, HeartAttack, HighCholestrol, Stroke, Cancer, HeartFailure, ClottingDisorder, Diabetes, KidneyDisease, ThyroidDisease, alcoholconsumption, PencillinAllergy, AspirinAllergy, SulfaDrugsAllergy, IbuprofenAllergy, ColdHeatIntolerance, DrugResistantInfection, AbdominalPain, Nausea, bloodyVomit, UlcerDisease, LossOfApetite_HeartBurn, Fatigue_NightSweats, Fever_Chills, CartoidSurgery, CartoidSurgeryDate, HeartStent, HeartStentDate, laparoscopy, laparoscopyDate, Pacemaker, PacemakerDate, OtherSurgeries);

            Console.WriteLine(p.Gender);
            DB.CreatePatient(p);
            DB.CreateEmergencyContact(contact);
            DB.CreateMedicalAssessment(m);




        }

        private void switchTabs(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if (clickedButton.Name == "HistoryTab")
                {
                    main.Visibility = Visibility.Collapsed;
                    History.Visibility = Visibility.Visible;
                }
                else if(clickedButton.Name == "OverviewTab")
                {
                    History.Visibility = Visibility.Collapsed;
                    main.Visibility = Visibility.Visible;
                }
            }
        }

        private void HypertensionYes_Checked(object sender, RoutedEventArgs e)
        {
            HypertensionNo.IsChecked = false;
        }
        private void HypertensionNo_Checked(object sender, RoutedEventArgs e)
        {
            HypertensionYes.IsChecked = false;
        }

        private void HeartAttackYes_Checked(object sender, RoutedEventArgs e)
        {
            HeartAttackNo.IsChecked = false;
        }

        private void HeartAttackNo_Checked(object sender, RoutedEventArgs e)
        {
            HeartAttackYes.IsChecked = false;
        }

        private void HighCholestrolYes_Checked(object sender, RoutedEventArgs e)
        {
            HighCholestrolNo.IsChecked = false;
        }

        private void HighCholestrolNo_Checked(object sender, RoutedEventArgs e)
        {
            HighCholestrolYes.IsChecked = false;
        }

        private void StrokeYes_Checked(object sender, RoutedEventArgs e)
        {
            StrokeNo.IsChecked = false;
        }

        private void StrokeNo_Checked(object sender, RoutedEventArgs e)
        {
            StrokeYes.IsChecked = false;
        }

        private void CancerYes_Checked(object sender, RoutedEventArgs e)
        {
            CancerNo.IsChecked = false;
        }

        private void CancerNo_Checked(object sender, RoutedEventArgs e)
        {
            CancerYes.IsChecked = false;
        }

        private void HeartFailureYes_Checked(object sender, RoutedEventArgs e)
        {
            HeartFailureNo.IsChecked = false;
        }

        private void HeartFailureNo_Checked(object sender, RoutedEventArgs e)
        {
            HeartFailureYes.IsChecked = false;
        }

        private void ClottingDisorderYes_Checked(object sender, RoutedEventArgs e)
        {
            ClottingDisorderNo.IsChecked = false;
        }

        private void ClottingDisorderNo_Checked(object sender, RoutedEventArgs e)
        {
            ClottingDisorderYes.IsChecked = false;
        }

        private void DiabetesYes_Checked(object sender, RoutedEventArgs e)
        {
            DiabetesNo.IsChecked = false;
        }

        private void DiabetesNo_Checked(object sender, RoutedEventArgs e)
        {
            DiabetesYes.IsChecked = false;
        }

        private void KidneyDiseaseYes_Checked(object sender, RoutedEventArgs e)
        {
            KidneyDiseaseNo.IsChecked = false; 
        }

        private void KidneyDiseaseNo_Checked(object sender, RoutedEventArgs e)
        {
            KidneyDiseaseYes.IsChecked = false;
        }

        private void ThyroidDiseaseYes_Checked(object sender, RoutedEventArgs e)
        {
            ThyroidDiseaseNo.IsChecked=false;
        }

        private void ThyroidDiseaseNo_Checked(object sender, RoutedEventArgs e)
        {
            ThyroidDiseaseYes.IsChecked=false;
        }

        private void PencillinAllergyYes_Checked(object sender, RoutedEventArgs e)
        {
            PencillinAllergyNo.IsChecked=false;
        }

        private void PencillinAllergyNo_Checked(object sender, RoutedEventArgs e)
        {
            PencillinAllergyYes.IsChecked=false;
        }

        private void AspirinAllergyYes_Checked(object sender, RoutedEventArgs e)
        {
            AspirinAllergyNo.IsChecked=false;
        }

        private void AspirinAllergyNo_Checked(object sender, RoutedEventArgs e)
        {
            AspirinAllergyYes.IsChecked=false;
        }

        private void SulfaDrugAllergyYes_Checked(object sender, RoutedEventArgs e)
        {
            SulfaDrugAllergyNo.IsChecked=false;
        }

        private void SulfaDrugAllergyNo_Checked(object sender, RoutedEventArgs e)
        {
            SulfaDrugAllergyYes.IsChecked=false;
        }

        private void IbuprofenAllergyYes_Checked(object sender, RoutedEventArgs e)
        {
            IbuprofenAllergyNo.IsChecked=false;
        }

        private void IbuprofenAllergyNo_Checked(object sender, RoutedEventArgs e)
        {
            IbuprofenAllergyYes.IsChecked=false;
        }

        private void ColdHeatIntoleranceYes_Checked(object sender, RoutedEventArgs e)
        {
            ColdHeatIntoleranceNo.IsChecked=false;
        }

        private void ColdHeatIntoleranceNo_Checked(object sender, RoutedEventArgs e)
        {
            ColdHeatIntoleranceYes.IsChecked=false;
        }

        private void DrugResistantInfYes_Checked(object sender, RoutedEventArgs e)
        {
            DrugResistantInfNo.IsChecked=false;
        }

        private void DrugResistantInfNo_Checked(object sender, RoutedEventArgs e)
        {
            DrugResistantInfYes.IsChecked=false;
        }

        private void AbdominalpainYes_Checked(object sender, RoutedEventArgs e)
        {
            AbdominalpainNo.IsChecked=false;
        }

        private void AbdominalpainNo_Checked(object sender, RoutedEventArgs e)
        {
            AbdominalpainYes.IsChecked=false;   
        }

        private void NauseaYes_Checked(object sender, RoutedEventArgs e)
        {
            NauseaNo.IsChecked=false;
        }

        private void NauseaNo_Checked(object sender, RoutedEventArgs e)
        {
            NauseaYes.IsChecked=false;
        }
        private void BloodyVomitYes_Checked(object sender, RoutedEventArgs e)
        {
            BloodyVomitNo.IsChecked=false;
        }
        private void BloodyVomitNo_Checked(object sender, RoutedEventArgs e)
        {
            BloodyVomitYes.IsChecked=false;
        }
        private void UlcerDiseaseYes_Checked(object sender, RoutedEventArgs e)
        {
            UlcerDiseaseNo.IsChecked = false;
        }
        private void UlcerDiseaseNo_Checked(object sender, RoutedEventArgs e)
        {
            UlcerDiseaseYes.IsChecked = false;
        }
        private void ApetiteLossYes_Checked(object sender, RoutedEventArgs e)
        {
            ApetiteLossNo.IsChecked = false;
        }
        private void ApetiteLossNo_Checked(object sender, RoutedEventArgs e)
        {
            ApetiteLossYes.IsChecked = false;
        }
        private void FatigueYes_Checked(object sender, RoutedEventArgs e)
        {
            FatigueNo.IsChecked = false;
        }
        private void FatigueNo_Checked(object sender, RoutedEventArgs e)
        {
            FatigueYes.IsChecked = false;
        }
        private void FeverYes_Checked(Object sender, RoutedEventArgs e)
        {
            FeverNo.IsChecked = false;
        } 
        private void FeverNo_Checked(Object sender, RoutedEventArgs e)
        {  FeverYes.IsChecked = false;}
        private void WeightGainLossYes_Checked(object sender,RoutedEventArgs e)
        {
            WeightGainLossNo.IsChecked = false;
        }
        private void WeightGainLossNo_Checked (object sender,RoutedEventArgs e)
        {
            WeightGainLossYes.IsChecked = false;
        }
        private void CartoidSurgeryYes_Checked (object sender,RoutedEventArgs e)
        {
            CartoidSurgeryNo.IsChecked = false;
        }
        private void CartoidSurgeryNo_Checked (object sender,RoutedEventArgs e)
        {
            CartoidSurgeryYes.IsChecked = false;
        }
        private void HeartStentYes_Checked (object sender,RoutedEventArgs e)
        {
            HeartStentNo.IsChecked = false;
        }
        private void HeartStentNo_Checked (Object sender,RoutedEventArgs e)
        {
            HeartStentYes.IsChecked = false;
        }
        private void LaparoscopyYes_Checked (object sender,RoutedEventArgs e)
        {
            LaparoscopyNo.IsChecked = false;
        }
        private void LaparoscopyNo_Checked (object sender,RoutedEventArgs e)
        {
            LaparoscopyYes.IsChecked = false;
        }
        private void PacemakerYes_Checked(object sender,RoutedEventArgs e)
        {
            PacemakerNo.IsChecked = false;
        }
        private void PacemakerNo_Checked (object sender,RoutedEventArgs e)
        {
            PacemakerYes.IsChecked = false;
        }
    }
}
