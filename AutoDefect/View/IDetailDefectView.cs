using AutoDefect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.View
{
    public interface IDetailDefectView
    {
        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }
        int DefectId { get; set; }
        string DefectName { get; set; }
        string InspectorId { get; set; }
        string InspectorName { get; set; }
        int Location { get; set; }
        string Message { get; set; }

        event EventHandler SaveEvent;
        event EventHandler DataSaved;

        void ShowPrintPreviewDialog(DefectResultModel model);
        void Show();
        void OnDataSaved();
    }
}
