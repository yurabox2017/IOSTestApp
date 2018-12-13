using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace IOSTestApp
{

    [Register("ZXingScannerPage")]
    public class ZXingScannerPage : UIViewController
    {
        public ZXingScannerPage()
        {
        }
        protected GetBarcodeView(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
        }
    }
}