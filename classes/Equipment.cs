using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareTech.classes
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentType { get; set; }
        public string Vendor { get; set; }
        public decimal AcquisitionCost { get; set; }
        public int ExpectedLifespan { get; set; }
        public DateTime MaintenanceDate { get; set; }

        // Constructor
        public Equipment()
        {
            // Default constructor
        }

        // Parameterized constructor
        public Equipment(string name, string type, string vendor, decimal cost, int lifespan, DateTime maintenanceDate)
        {
            EquipmentName = name;
            EquipmentType = type;
            Vendor = vendor;
            AcquisitionCost = cost;
            ExpectedLifespan = lifespan;
            MaintenanceDate = maintenanceDate;
        }

    }
}

