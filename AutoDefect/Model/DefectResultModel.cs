using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Model
{
    public class DefectResultModel
    {
        //Fields
        public string id;
        public string defect;
        public string partName;
        public string modelNumber;
        public string modelCode;
        public string serialNumber;
        public string date;
        public string time;
        public string inspectorId;
        public string inspectorName;
        public string locationId;

        //properties
        [DisplayName("No")]
        [Browsable(false)] // Tambahkan atribut ini
        public string Id
        {
            get => id;
            set => id = value;
        }

        [DisplayName("Defect Name")]
        public string Defect
        {
            get => defect;
            set => defect = value;
        }
        [DisplayName("Part Name")]
        public string PartName 
        { 
            get => partName; 
            set => partName = value; 
        }

        [DisplayName("Model Number")]
        public string ModelNumber
        {
            get => modelNumber;
            set => modelNumber = value;
        }

        [DisplayName("Model Code")]
        public string ModelCode
        {
            get => modelCode;
            set => modelCode = value;
        }

        [DisplayName("Serial Number")]
        public string SerialNumber
        {
            get => serialNumber;
            set => serialNumber = value;
        }

        [DisplayName("Date")]
        public string Date
        {
            get => date;
            set => date = value;
        }

        [DisplayName("Time")]
        public string Time
        {
            get => time;
            set => time = value;
        }

        [DisplayName("Inspector")]
        public string Inspector
        {
            get => inspectorId;
            set => inspectorId = value;
        }

        [DisplayName("Location")]
        public string LocationId
        {
            get => locationId;
            set => locationId = value;
        }

        [Browsable(false)]
        public string InspectorName 
        { 
            get => inspectorName; 
            set => inspectorName = value; 
        }
    }
}
