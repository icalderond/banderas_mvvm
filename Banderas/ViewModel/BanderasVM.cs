using Banderas.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banderas.ViewModel
{
   public  class BanderasVM:NotificationEnabledObject
    {
        ServiceBanderas service = new ServiceBanderas();
        public BanderasVM()
        {
            service.ObtenerBanderas_Completed += (_, a) =>
            {
                ListaBanderas = new ObservableCollection<Pais>(a.Result);
            };
            service.ObtenerBanderas();
        }
        private ObservableCollection<Pais> listaBanderas;

        public ObservableCollection<Pais> ListaBanderas
        {
            get { return listaBanderas; }
            set { listaBanderas = value;
                OnPropertyChanged();
            }
        }
        private ActionCommand<string> filtratBanderasCommand;

        public ActionCommand<string> FiltrarBanderasCommand
        {
            get
           {
                if (filtratBanderasCommand == null)
                {
                    filtratBanderasCommand = new ActionCommand<string>((pa) =>
                    {
                        service.ObtenerBanderas(pa);
                    });
                }
                return filtratBanderasCommand; }
            set { filtratBanderasCommand = value;
                OnPropertyChanged();
            }
        }

    }
}
