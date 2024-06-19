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
        private string PartId;
        private string DefectName;

        //properties
        [DisplayName("No")]
        [Browsable(false)] // Tambahkan atribut ini
        public int Id1
        {
            get => Id;
            set => Id = value;
        }

        [DisplayName("Part Name")]
        public string PartId1
        {
            get => PartId;
            set => PartId = value;
        }

        [DisplayName("Defect Name")]
        public string DefectName1
        {
            get => DefectName;
            set => DefectName = value;
        }
    }
}
