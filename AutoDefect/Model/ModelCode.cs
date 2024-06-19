using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Model
{
    public class ModelCode
    {
        private string serialNumber;
        private string modelCode;
        private string modelNumber;

        //properties
        public string SerialNumber
        {
            get => serialNumber;
            set => serialNumber = value;
        }


        [DisplayName("modelCode")]
        public string modelCode1
        {
            get => modelCode;
            set => modelCode = value;
        }

        [DisplayName("ModelNumber")]
        public string ModelNumber
        {
            get => modelNumber;
            set => modelNumber = value;
        }
    }
}
