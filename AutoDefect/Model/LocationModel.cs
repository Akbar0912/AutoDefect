using AutoDefect._Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Model
{
    public class LocationModel
    {
        private SettingRepository _repository;

        public LocationModel()
        {
            _repository = new SettingRepository();
        }

        public List<string> GetLocationNames()
        {
            return _repository.GetData();
        }

        public int GetLocationId(string selectedLocationName)
        {
            return _repository.GetID(selectedLocationName);

        }
    }
}
