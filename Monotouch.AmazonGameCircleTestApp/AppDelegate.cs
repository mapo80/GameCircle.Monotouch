using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using AmazonGameCircle;


namespace Monotouch.AmazonGameCircleTestApp
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		Monotouch_AmazonGameCircleTestAppViewController viewController;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			return GameCircle.HandleOpenURL (url, sourceApplication);
		}
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new Monotouch_AmazonGameCircleTestAppViewController ();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();

			GameCircle.BeginWithFeatures (
				new NSObject[2] {
					NSString.FromObject (GameCircleConst.AGFeatureAchievements),
					NSString.FromObject (GameCircleConst.AGFeatureLeaderboards)
				}, 
				new BeginWithFeaturesCallBack (delegate(NSError error) {
					if(error != null) Console.WriteLine("Codice di errore:" + error.Description);
					else{
						//Signed on GameCenter
						AGOverlay.SharedOverlay.ShowGameCircle(true);
					}
				}));
			return true;
		}
	}
}

