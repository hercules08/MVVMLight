// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace my_mvvm_app.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnShuffle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField editShuffles { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtCapacity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtStadium { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel txtTeamName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnMapView != null) {
                btnMapView.Dispose ();
                btnMapView = null;
            }

            if (btnShuffle != null) {
                btnShuffle.Dispose ();
                btnShuffle = null;
            }

            if (editShuffles != null) {
                editShuffles.Dispose ();
                editShuffles = null;
            }

            if (txtCapacity != null) {
                txtCapacity.Dispose ();
                txtCapacity = null;
            }

            if (txtStadium != null) {
                txtStadium.Dispose ();
                txtStadium = null;
            }

            if (txtTeamName != null) {
                txtTeamName.Dispose ();
                txtTeamName = null;
            }
        }
    }
}