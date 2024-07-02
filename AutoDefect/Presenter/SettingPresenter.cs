using AutoDefect.Model;
using AutoDefect.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Presenter
{
    public class SettingPresenter
    {
        private readonly ISettingView _view;
        private readonly SettingModel _model;
        private readonly LocationModel _smodel;
        private readonly PrintModeModel _printMode;
        private readonly PrinterTypeModel _printerType;

        public SettingPresenter(ISettingView view, SettingModel model)
        {
            _view = view;
            _model = model;
            _smodel = new LocationModel();
            _printMode = new PrintModeModel();
            _printerType = new PrinterTypeModel();

            _view.SelectedIndexChanged += View_SelectedIndexChanged;
            _view.SaveIPSettings += SaveIPSettings;
            _view.SavePortSettings += SavePortSettings;
            _view.LoadIP += View_LoadIP;
            _view.LoadPort += View_LoadPort;
            _view.LoadLocation += View_LoadSettings;
            _view.HandleRadioButton += HandleRadioButton;
            _view.SelectedPrinterType += SelectedPrinterType;
            _view.LoadPrinterType += LoadPrinterType;
        }

        private void LoadPrinterType(object? sender, EventArgs e)
        {
            string loadedPrinter = _printerType.GetPrinterType();
            _view.DsiplayPrinterType(loadedPrinter);
        }

        private void SelectedPrinterType(object? sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string location = comboBox?.SelectedItem as string;

            if (comboBox?.SelectedItem != null)
            {
                string selectedPrinter = comboBox.SelectedItem.ToString();
                _printerType.SaveData(selectedPrinter);
            }
        }

        private void HandleRadioButton(object? sender, EventArgs e)
        {
            if (_view.mode == "on")
                onRadio_Checked();
            else if (_view.mode == "off")
                offRadio_Checked();
            else if ( _view.mode == "preview")
                previewRadio_Checked();
        }

        private void previewRadio_Checked()
        {
            _printMode.SaveData(_view.mode);
        }

        private void offRadio_Checked()
        {
            _printMode.SaveData(_view.mode);
        }

        private void onRadio_Checked()
        {
            _printMode.SaveData(_view.mode);
           
        }

        private void View_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            //string location = comboBox?.SelectedItem as string;

            if (comboBox?.SelectedItem != null)
            {
                string selectedLocationName = comboBox.SelectedItem.ToString();
                _model.SaveLocationName(selectedLocationName);

                // Memeriksa apakah selectedLocationName memiliki nilai sebelum memanggil repo
                if (!string.IsNullOrEmpty(selectedLocationName))
                {
                    // Panggil metode repo di sini dengan selectedLocationName sebagai parameter
                    int locationId = _smodel.GetLocationId(selectedLocationName);
                    _model.SaveLocationID(locationId);
                }
            }
        }

        private void View_LoadSettings(object sender, EventArgs e)
        {
            LoadLocationNames();
        }
        private void View_LoadIP(object sender, EventArgs e)
        {
            string loadedIP = _model.LoadIP();
            _view.DisplayIP(loadedIP);
        }

        private void View_LoadPort(object sender, EventArgs e)  
        {
            int loadedPort = _model.LoadPort();
            _view.DisplayPort(loadedPort);
        }

        private void SaveIPSettings(object sender, EventArgs e)
        {
            _model.SaveSettingIP(_view.ipaddress);
        }

        private void SavePortSettings(object sender, EventArgs e)
        {
            _model.SaveSettingPort(_view.portaddress);
        }
        private void LoadLocationNames()
        {
            List<string> locationNames = _smodel.GetLocationNames();
            _view.LocationNames = locationNames;
            string loadedSetting = _model.LoadLocation();
            _view.DisplaySetting(loadedSetting);
        }
    }
}
