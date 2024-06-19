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
        private string id;
        private string defect;
        private string modelNumber;
        private string modelCode;
        private string serialNumber;
        private string date;
        private string time;
        private string inspector;
        private string locationId;

        //properties
        [DisplayName("No")]
        [Browsable(false)] // Tambahkan atribut ini
        public string Id
        {
            get => id;
            set => id = value;
        }

        [DisplayName("Defect")]
        public string Defect
        {
            get => defect;
            set => defect = value;
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
            get => inspector;
            set => inspector = value;
        }

        [DisplayName("Location")]
        public string LocationId
        {
            get => locationId;
            set => locationId = value;
        }
    }
}
