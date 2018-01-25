using GalaSoft.MvvmLight.Helpers;
using my_mvvm_app.ViewModel;
using System;

using UIKit;

namespace my_mvvm_app.iOS
{
    public partial class ViewController : UIViewController
    {
        public MainViewModel ViewModel => AppDelegate.Locator.Main;
        
        //Define the bindings in the view controller
        //so that it is not garbage collected
        //when the code leaves ths scope
        //and since ViewDidLoad will only be called once
        //https://stackoverflow.com/questions/28151572/binding-a-property-to-a-viewmodel-with-mvvmlight-and-xamarin-ios
        Binding<string, string> _teamNameBinding;
        Binding<string, string> _txtStadiumBinding;
        Binding<int, string> _txtCapacityBinding;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            CreateTextBindings();
            CreateButtonBinding();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
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

            this.SetBinding(() => editShuffles.Text)
                .UpdateSourceTrigger(Events.EditingChanged)
                .WhenSourceChanges(() => ViewModel.TextNumberOfShuffles = editShuffles.Text);
        }

        void CreateButtonBinding()
        {
            BtnShuffle.SetCommand(Events.Click,
                ViewModel.ButtonClicked);
        }
    }

    public partial class ViewController:UIViewController
    {
        // create the public properties for the objects

        public UIButton BtnShuffle =>
            btnShuffle;

        public UILabel TxtTeamName =>
            txtTeamName;

        public UILabel TxtStadium =>
            txtStadium;

        public UILabel TxtCapacity =>
            txtCapacity;
    }

}