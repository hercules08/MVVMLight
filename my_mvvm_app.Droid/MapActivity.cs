using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using my_mvvm_app.ViewModel;

namespace my_mvvm_app.Droid
{
    [Activity(Label = "MapActivity")]
    public partial class MapActivity : ActivityBase, IOnMapReadyCallback
    {
        public MapViewModel ViewModel = App.Locator.Map;

        private MapFragment _mapFragment;
        private GoogleMap _map;

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;

            if (_map != null)
            {
                MarkerOptions markerOpt1 = new MarkerOptions();
                markerOpt1.SetPosition(new LatLng(ViewModel.Latitude, ViewModel.Longitude));
                markerOpt1.SetTitle("Stadium");
                markerOpt1.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
                _map.AddMarker(markerOpt1);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Map);

            var NavService = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            var data = NavService.GetAndRemoveParameter<List<double>>(Intent);

            if (data != null)
            {
                _mapFragment = FragmentManager.FindFragmentByTag("mapView") as MapFragment;
                if (_mapFragment == null)
                {
                    GoogleMapOptions mapOptions = new GoogleMapOptions()
                        .InvokeMapType(GoogleMap.MapTypeSatellite)
                        .InvokeZoomControlsEnabled(false)
                        .InvokeCompassEnabled(true);

                    FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                    _mapFragment = MapFragment.NewInstance(mapOptions);
                    fragTx.Add(Resource.Id.mapView, _mapFragment, "mapView");
                    fragTx.Commit();
                }
                _mapFragment.GetMapAsync(this);


                ViewModel.Latitude = data[0];
                ViewModel.Longitude = data[1];
            }

            CreateButtonBinding();
        }

        void CreateButtonBinding()
        {
            BtnHome.SetCommand(
                Events.Click,
                ViewModel.ButtonHome);
        }
    }

    public partial class MapActivity : ActivityBase
    {
        //create the private references to the objects
        Button btnHome;

        public Button BtnHome =>
            btnHome ?? (btnHome = FindViewById<Button>(Resource.Id.btnHome));
    }
}