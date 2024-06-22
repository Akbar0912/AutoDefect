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
        private ITabControlView _tabControl;
        private readonly IDefectRepository repository;
        private readonly PrintModeModel _smodel;

        public DetailDefectPresenter(IDetailDefectView View, IDefectRepository defectRepository, ITabControlView tabControl, dynamic detailDefect)
        {
            this._view = View;
            this.repository = defectRepository;
            this._smodel = new PrintModeModel();
            this._tabControl = tabControl;
            this._view.SaveEvent += SaveEvent;
            SetData(detailDefect);
            this._view.Show();


        }

        private void SaveEvent(object? sender, EventArgs e)
        {
            string mode = _smodel.GetMode();

            if (mode == "off")
            {
                _tabControl.StatusText = "Data berhasil tersimpan, print dalam mode OFF";
                _tabControl.BackColorStatus = Color.Green;
                _tabControl.ForeColorStatus = Color.White;
                var model = new
                {
                    _view.SerialNumber,
                    _view.ModelNumber,
                    _view.ModelCode,
                    _view.DefectId,
                    _view.DefectName,
                    _view.InspectorId,
                    _view.InspectorName,
                    _view.PartId,
                    _view.PartName,
                    _view.Location,
                };
                repository.Add(model);
                _view.OnDataSaved();

                _view.SaveEvent -= SaveEvent;
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
                    _view.PartId,
                    _view.PartName,
                    _view.Location,
                };
                repository.Add(model);

                _tabControl.StatusText = "Data berhasil tersimpan";
                _tabControl.BackColorStatus = Color.Green;
                _tabControl.ForeColorStatus = Color.White;

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
            _view.PartId = detailDefect.PartId;
            _view.PartName = detailDefect.PartName;
        }
    }
}
