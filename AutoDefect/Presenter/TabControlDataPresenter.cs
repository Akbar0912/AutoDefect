using AutoDefect._Repositories;
using AutoDefect.Model;
using AutoDefect.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDefect.Presenter
{
    public class TabControlDataPresenter
    {
        public ITabControlView View { get; }
        public IDefectRepository DefectRepository { get; }
        public IModelNumberRepository ModelNumberRepository { get; }
        public LoginModel User { get; }

        public TabControlDataPresenter(ITabControlView view, IDefectRepository defectRepository, LoginModel user)
        {
            View = view;
            DefectRepository = defectRepository;
            ModelNumberRepository = new ModelNumberRepository();
            User = user;
        }
    }
}
