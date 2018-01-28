using Android.App;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;
using my_mvvm_app.ViewModel;

namespace my_mvvm_app.Droid
{
    [Activity(Label = "my_mvvm_app.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public partial class MainActivity : ActivityBase
    {
        Binding<string, string> _teamNameBinding;
        Binding<string, string> _txtStadiumBinding;
        Binding<int, string> _txtCapacityBinding;
        public MainViewModel ViewModel = App.Locator.Main;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            CreateTextBindings();
            CreateButtonBinding();
        }

        void CreateTextBindings()
        {
            _teamNameBinding = this.SetBinding(
                   () => ViewModel.TeamName,
                   () => TxtTeamName.Text);

            _txtStadiumBinding = this.SetBinding(
                () => ViewModel.StadiumName,
                () => TxtStadium.Text);

            _txtCapacityBinding = this.SetBinding(
                () => ViewModel.Capacity,
                () => TxtCapacity.Text);

            this.SetBinding(
                () => ViewModel.NumberOfShuffles,
                () => EditShuffles.Text,
                BindingMode.TwoWay);
        }

        void CreateButtonBinding()
        {
            BtnShuffle.SetCommand(
                Events.Click,
                ViewModel.ButtonClicked);

            BtnMapView.SetCommand(
                Events.Click,
                ViewModel.MapViewButtonClicked);
        }
    }

    public partial class MainActivity
    {
        // create the private references to the objects
        Button btnShuffle, btnMapView;
        TextView txtTeamName, txtStadium, txtCapacity;
        EditText editShuffles;

        // create the public properties for the objects
        public Button BtnShuffle => 
            btnShuffle ?? (btnShuffle = FindViewById<Button>(Resource.Id.btnShuffle));

        public Button BtnMapView =>
            btnMapView ?? (btnMapView = FindViewById<Button>(Resource.Id.btnMapView));

        public TextView TxtTeamName =>
            txtTeamName ?? (txtTeamName = FindViewById<TextView>(Resource.Id.txtTeamName));
        public TextView TxtStadium =>
            txtStadium ?? (txtStadium = FindViewById<TextView>(Resource.Id.txtStadium));
        public TextView TxtCapacity =>
            txtCapacity ?? (txtCapacity = FindViewById<TextView>(Resource.Id.txtCapacity));

        public EditText EditShuffles =>
            editShuffles ?? (editShuffles = FindViewById<EditText>(Resource.Id.editShuffles));
    }

}

