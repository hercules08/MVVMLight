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
            this.SetBinding(
                () => ViewModel.TeamName,
                () => TxtTeamName.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.StadiumName,
                () => TxtStadium.Text,
                BindingMode.TwoWay);

            this.SetBinding(
                () => ViewModel.Capacity,
                () => TxtCapacity.Text,
                BindingMode.TwoWay);

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
        }
    }

    public partial class MainActivity
    {
        // create the private references to the objects
        Button btnShuffle;
        TextView txtTeamName, txtStadium, txtCapacity;
        EditText editShuffles;

        // create the public properties for the objects
        public Button BtnShuffle => 
            btnShuffle ?? (btnShuffle = FindViewById<Button>(Resource.Id.btnShuffle));

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

