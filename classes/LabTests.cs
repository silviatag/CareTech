using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareTech.classes
{
    public class Lab
    {
        public int LabID { get; set; }
        public int PatientID { get; set; }
        public string CBCResults { get; set; }
        public string BMPResults { get; set; }
        public string LipidPanelResults { get; set; }
        public string ThyroidTestsResults { get; set; }
        public double HbA1CResult { get; set; }
        public string UrinalysisResults { get; set; }
        public string LFTResults { get; set; }
        public string CoagulationPanelResults { get; set; }
        public string SerumElectrolytesResults { get; set; }
        public double CRPResult { get; set; }
        public double ESRResult { get; set; }
        public string HIVTestResult { get; set; }
        public string HepatitisTestResults { get; set; }
        public double PTResult { get; set; }
        public double INRResult { get; set; }
        public string BloodTypingResults { get; set; }
        public DateTime DateCreated { get; set; }

        // Parameterless constructor
        public Lab() { }

        // Constructor with parameters
        public Lab(int patientID, string cbcResults, string bmpResults, string lipidPanelResults, string thyroidTestsResults,
                   double hbA1CResult, string urinalysisResults, string lftResults, string coagulationPanelResults,
                   string serumElectrolytesResults, double crpResult, double esrResult, string hivTestResult,
                   string hepatitisTestResults, double ptResult, double inrResult, string bloodTypingResults, DateTime dateCreated)
        {
            PatientID = patientID;
            CBCResults = cbcResults;
            BMPResults = bmpResults;
            LipidPanelResults = lipidPanelResults;
            ThyroidTestsResults = thyroidTestsResults;
            HbA1CResult = hbA1CResult;
            UrinalysisResults = urinalysisResults;
            LFTResults = lftResults;
            CoagulationPanelResults = coagulationPanelResults;
            SerumElectrolytesResults = serumElectrolytesResults;
            CRPResult = crpResult;
            ESRResult = esrResult;
            HIVTestResult = hivTestResult;
            HepatitisTestResults = hepatitisTestResults;
            PTResult = ptResult;
            INRResult = inrResult;
            BloodTypingResults = bloodTypingResults;
            DateCreated = dateCreated;
        }
    }
}
