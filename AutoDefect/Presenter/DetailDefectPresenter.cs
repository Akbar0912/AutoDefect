using AutoDefect.Model;
using AutoDefect.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace AutoDefect.Presenter
{
    public class DetailDefectPresenter
    {
        private readonly IDetailDefectView _view;
        private readonly IDefectRepository repository;
        private readonly PrintModeModel _smodel;

        public DetailDefectPresenter(IDetailDefectView View, IDefectRepository defectRepository, dynamic detailDefect)
        {
            this._view = View;
            this.repository = defectRepository;
            this._smodel = new PrintModeModel();
            this._view.SaveEvent += SaveEvent;
            SetData(detailDefect);
            this._view.Show();
        }

        private void SaveEvent(object? sender, EventArgs e)
        {
            string mode = _smodel.GetMode();

            if (mode == "off")
            {
                // Jika mode off, tampilkan pesan bahwa save tidak diperlukan
                _view.Message = "Mode is off. No save action needed.";
                MessageBox.Show(_view.Message);
            }
            else
            {
                // Lakukan operasi save jika mode tidak off
                var model = new
                {
                    _view.SerialNumber,
                    _view.ModelNumber,
                    _view.ModelCode,
                    _view.DefectId,
                    _view.DefectName,
                    _view.InspectorId,
                    _view.InspectorName,
                    _view.Location,
                };
                //new Common.ModelDataValidation().Validate(model);
                repository.Add(model);

                _view.OnDataSaved();

                _view.SaveEvent -= SaveEvent;
            }
        }

        private void SetData(dynamic detailDefect)
        {
            _view.SerialNumber = detailDefect.SerialNumber;
            _view.ModelCode = detailDefect.ModelCode;
            _view.ModelNumber = detailDefect.ModelNumber;
            _view.DefectId = detailDefect.DefectId;
            _view.DefectName = detailDefect.DefectName;
            _view.InspectorId = detailDefect.InspectorId;
            _view.InspectorName = detailDefect.Inspector;
            _view.Location = detailDefect.Location;
            //_view.ShowPrintPreviewDialog(detailDefect);
        }
    }
}
