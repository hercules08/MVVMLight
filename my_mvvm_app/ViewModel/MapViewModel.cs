using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_mvvm_app.ViewModel
{
    public class MapViewModel : ViewModelBase
    {
        INavigationService navigationService;
        RelayCommand buttonHome;

        public MapViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public RelayCommand ButtonHome
        {
            get
            {
                if(buttonHome == null)
                {
                    buttonHome = new RelayCommand(() =>
                    {
                        navigationService.NavigateTo(ViewModelLocator.MainPageKey);
                    });
                }

                return buttonHome;
            }
        }

        private double latitude;
        public double Latitude
        {
            get

            {
                return latitude;
            }
            set
            {
                Set(() => Latitude, ref latitude, value, true);
            }
        }

        private double longitude;
        public double Longitude
        {
            get

            {
                return longitude;
            }
            set
            {
                Set(() => Longitude, ref longitude, value, true);
            }
        }
    }
}
