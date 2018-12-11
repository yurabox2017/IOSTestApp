using Foundation;
//using IOSTestApp.localhost;
using System;
using UIKit;

namespace IOSTestApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //try
            //{


            //var l_srv = new IOSTestApp.WebReference.Service1();
            //bool val = true;
            //this.txtFIO.Text = l_srv.GetData(10, val);
            //    // Perform any additional setup after loading the view, typically from a nib.
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message);
            //}
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}