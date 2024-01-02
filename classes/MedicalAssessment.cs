using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace CareTech.classes
{
    public class MedicalAssessment
    {
        public int PatientID;
        public bool Hypertension;
        public bool HeartAttack;
        public bool HighCholestrol;
        public bool Stroke;
        public bool Cancer;
        public bool HeartFailure;
        public bool ClottingDisorder;
        public bool Diabetes;
        public bool KidneyDisease;
        public bool ThyroidDisease;
        public string AlcoholConsumption;
        public bool PencillinAllergy;
        public bool AspirinAllergy;
        public bool SulfaDrugsAllergy;
        public bool IbuprofenAllergy;
        public bool ColdHeatIntolerance;
        public bool DrugResistantInfection;
        public bool AbdominalPain;
        public bool Nausea;
        public bool bloodyVomit;
        public bool UlcerDisease;
        public bool LossOfApetite_HeartBurn;
        public bool Fatigue_NightSweats;
        public bool Fever_Chills;
        public bool CartoidSurgery;
        public DateTime? CartoidSurgeryDate;
        public bool HeartStent;
        public DateTime? HeartStentDate;
        public bool laparoscopy;
        public DateTime? laparoscopyDate;
        public bool Pacemaker;
        public DateTime? PacemakerDate;
        public string OtherSurgeries;

        public MedicalAssessment(int patientID, bool hypertension, bool heartAttack, bool highCholestrol, bool stroke, bool cancer, bool heartFailure, bool clottingDisorder, bool diabetes, bool kidneyDisease, bool thyroidDisease, string alcoholConsumption, bool pencillinAllergy, bool aspirinAllergy, bool sulfaDrugsAllergy, bool ibuprofenAllergy, bool coldHeatIntolerance, bool drugResistantInfection, bool abdominalPain, bool nausea, bool bloodyVomit, bool ulcerDisease, bool lossOfApetite_HeartBurn, bool fatigue_NightSweats, bool fever_Chills, bool cartoidSurgery, DateTime? cartoidSurgeryDate, bool heartStent, DateTime? heartStentDate, bool laparoscopy, DateTime? laparoscopyDate, bool pacemaker, DateTime? pacemakerDate, string otherSurgeries)
        {
            PatientID = patientID;
            Hypertension = hypertension;
            HeartAttack = heartAttack;
            HighCholestrol = highCholestrol;
            Stroke = stroke;
            Cancer = cancer;
            HeartFailure = heartFailure;
            ClottingDisorder = clottingDisorder;
            Diabetes = diabetes;
            KidneyDisease = kidneyDisease;
            ThyroidDisease = thyroidDisease;
            AlcoholConsumption = alcoholConsumption;
            PencillinAllergy = pencillinAllergy;
            AspirinAllergy = aspirinAllergy;
            SulfaDrugsAllergy = sulfaDrugsAllergy;
            IbuprofenAllergy = ibuprofenAllergy;
            ColdHeatIntolerance = coldHeatIntolerance;
            DrugResistantInfection = drugResistantInfection;
            AbdominalPain = abdominalPain;
            Nausea = nausea;
            this.bloodyVomit = bloodyVomit;
            UlcerDisease = ulcerDisease;
            LossOfApetite_HeartBurn = lossOfApetite_HeartBurn;
            Fatigue_NightSweats = fatigue_NightSweats;
            Fever_Chills = fever_Chills;
            CartoidSurgery = cartoidSurgery;
            CartoidSurgeryDate = cartoidSurgeryDate;
            HeartStent = heartStent;
            HeartStentDate = heartStentDate;
            this.laparoscopy = laparoscopy;
            this.laparoscopyDate = laparoscopyDate;
            Pacemaker = pacemaker;
            PacemakerDate = pacemakerDate;
            OtherSurgeries = otherSurgeries;
        }
    }
}
