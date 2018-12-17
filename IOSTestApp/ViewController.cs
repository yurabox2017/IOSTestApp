using CoreGraphics;
using Foundation;
//using IOSTestApp.localhost;
using System;
using UIKit;
using Xamarin.Forms;
using System.Threading.Tasks;
//using ZXing.Net.Mobile.Forms;

namespace IOSTestApp
{
    public partial class ViewController : UIViewController
    {

        public ViewController(IntPtr handle) : base(handle)
        {
        }
        public ViewController() : base()
        {

        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var submitButton = UIButton.FromType(UIButtonType.RoundedRect);
            nfloat h = 31.0f;
            nfloat w = View.Bounds.Width;
            submitButton.Frame = new CGRect(10, 170, w - 20, 44);
            submitButton.SetTitle("Сканировать QRCOde", UIControlState.Normal);

            submitButton.TouchUpInside += async (sender, e) =>
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner(this);
                //scanner.TopText = "Hold camera up to barcode to scan";
                //scanner.BottomText = "Barcode will automatically scan";
                //scanner.UseCustomOverlay = false;
                scanner.FlashButtonText = "Подсветка";
                scanner.CancelButtonText = "Выход";
                scanner.Torch(true);
                scanner.AutoFocus();
                //scanner.opt

                var result = await scanner.Scan(true);
                HandleScanResult(result);
                //var customScanPage = new ScannerBarcodeView();
                //var page = new NavigationPage();


                ////this.NavigationController.PushViewController(customScanPage, true);
                //await  NavigationPage.PushAsync(customScanPage);
                ////   Console.WriteLine("Submit button pressed");
            };

            View.AddSubview(submitButton);
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
        void HandleScanResult(ZXing.Result result)
        {
            if (result != null && !string.IsNullOrEmpty(result.Text))

                txtFIO.Text = result.Text;
            UIAlertView alert = new UIAlertView()
            {
                Title = "alert title",
                Message = result.Text
            };
            alert.AddButton("OK");
            alert.Show();
        }
    }
}