using CoreLocation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MapKit;
using my_mvvm_app.ViewModel;
using System;
using System.Collections.Generic;
using UIKit;


namespace my_mvvm_app.iOS
{
    public partial class MapViewController : UIViewController
    {
        MapViewModel ViewModel = AppDelegate.Locator.Map;

        public MapViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        void CreateButtonBindings()
        {
            BtnHome.SetCommand(Events.Click, ViewModel.ButtonHome);
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            var NavService = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            var data = NavService.GetAndRemoveParameter(this) as List<double>;

            if (data != null)
            {
                ViewModel.Latitude = double.Parse(data[0].ToString());
                ViewModel.Longitude = double.Parse(data[1].ToString());

                mapView.ZoomEnabled = mapView.ScrollEnabled = mapView.UserInteractionEnabled = true;
                mapView.MapType = MKMapType.Standard;
                mapView.Region = new MKCoordinateRegion(
                new CLLocationCoordinate2D(ViewModel.Latitude, ViewModel.Longitude),
                new MKCoordinateSpan(.5, .5));
            }

            CreateButtonBindings();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }

    public partial class MapViewController : UIViewController
    {
        public UIButton BtnHome => btnHome;
    }
}