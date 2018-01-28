using Foundation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using my_mvvm_app.ViewModel;
using System;
using UIKit;

namespace my_mvvm_app.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {

        private static ViewModelLocator locator;

        public static ViewModelLocator Locator =>
            locator ?? (locator = new ViewModelLocator());

        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create the instance of the navigation service
            var nav = new NavigationService();

            // iOS uses the UINavigationController to move between pages, so will we
            nav.Initialize((UINavigationController)Window.RootViewController);

            ////we configure the navigation service to take the key, with the
            //// second page being the storyboard ID
            //nav.Configure(ViewModelLocator.MainPageKey, (arg) =>
            //{
            //    var storyboard = this.Window.RootViewController.Storyboard;// UIStoryboard.FromName(storyBoardName, null);
            //    return storyboard.InstantiateViewController("FirstPage")
            //    as ViewController;
            //});

            //nav.Configure(ViewModelLocator.MapPageKey, (arg) =>
            //{
            //    var storyboard = this.Window.RootViewController.Storyboard;//UIStoryboard.FromName(ViewModelLocator.MapPageKey, null);
            //    return storyboard.InstantiateViewController("MapPage") as MapViewController;
            //});

            try
            {
                nav.Configure(ViewModelLocator.MainPageKey, "ViewController");
            }
            catch (Exception ex)
            {

            }

            try
            {
                nav.Configure(ViewModelLocator.MapPageKey, "MapViewController");
            }
            catch (Exception ex)
            {

            }

            // finally register the service with SimpleIoc
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}