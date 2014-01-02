using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Monotouch.AmazonGameCircleTestApp
{
	public partial class Monotouch_AmazonGameCircleTestAppViewController : UIViewController
	{
		public Monotouch_AmazonGameCircleTestAppViewController () : base ("Monotouch_AmazonGameCircleTestAppViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

