using System;
using Android.App;
using Android.Runtime;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using my_mvvm_app.ViewModel;

namespace my_mvvm_app.Droid
{
    [Application(Icon = "@mipmap/icon")]
    public class App : Application
    {
        private static ViewModelLocator locator;

        public App(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public static ViewModelLocator Locator
        {
            get
            {
                if (locator == null)
                {
                    //First time initialization
                    var nav = new NavigationService();

                    // configure the navigation service
                    nav.Configure(ViewModelLocator.MainPageKey, typeof(MainActivity));
                    nav.Configure(ViewModelLocator.MapPageKey, typeof(MapActivity));

                    // register with the Navigation Service
                    SimpleIoc.Default.Register<INavigationService>(() => nav);

                    locator = new ViewModelLocator();
                }
                return locator;
            }
        }
    }
}