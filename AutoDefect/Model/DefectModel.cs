using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Model
{
    public class DefectModel
    {
        //Fields
        private int Id;
        private string DefectName;

        //properties
        [DisplayName("No")]
        [Browsable(false)] // Untuk visible tampilan
        public int Id1
        {
            get => Id;
            set => Id = value;
        }

        [DisplayName("Defect Name")]
        public string DefectName1
        {
            get => DefectName;
            set => DefectName = value;
        }
        
    }
}
