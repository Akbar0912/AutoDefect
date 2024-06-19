using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoDefect.Presenter.TabControlPresenter;

namespace AutoDefect.View
{
    public interface ITabControlView
    {
        //properties - fields
        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }
        string InspectorId { get; set; }
        string Inspector { get; set; }
        string StatusText { get; set; }
        bool IsKeyboardEnabled { get; set; }
        Color BackColorStatus { get; set; }
        Color ForeColorStatus { get; set; }
        DateTime SelectedDate { get; }

        //event
        event EventHandler<ModelEventArgs> SearchModelNumber;
        event EventHandler ClearEvent;
        event TopDefectEventHandler DefectFilterEvent;
        event EventHandler EditButtonClicked;
        event EventHandler CellClicked;
        event KeyEventHandler KeyDownEvent;
        event EventHandler SearchFilter;
        event EventHandler CheckProperties;

        void SelectTabPageByIndex(int data);
        void AddNoData();
        void RemoveNoData(BindingSource defectList);
        void SetDefectListBindingSource(BindingSource defectList);
        void SetDefectListBindingSource2(BindingSource resultList);
        void ShowPopupForm();
        void Show();

        public class ModelEventArgs : EventArgs
        {
            public string Message { get; set; }

            public ModelEventArgs(string message)
            {
                Message = message;
            }
        }
    }
}
