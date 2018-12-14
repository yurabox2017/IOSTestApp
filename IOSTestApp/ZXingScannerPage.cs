using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using ZXing.Mobile;
using CoreGraphics;

namespace IOSTestApp
{

    [Register("ZXingScannerPage")]
    public class ZXingScannerPage : UIViewController
    {
        public ZXingScannerPage()
        {
        }
        protected ZXingScannerPage(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        UIImageView imageBarcode;

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {

            base.ViewDidLoad();
            NavigationItem.Title = "Generate Barcode";
            View.BackgroundColor = UIColor.White;

            imageBarcode = new UIImageView(new CGRect(20, 80, View.Frame.Width - 40, View.Frame.Height - 120));

            View.AddSubview(imageBarcode);

            var barcodeWriter = new BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 300,
                    Height = 300,
                    Margin = 30
                }
            };

            var barcode = barcodeWriter.Write("ZXing.Net.Mobile");

            imageBarcode.Image = barcode;

            // Perform any additional setup after loading the view
        }
        public ZXing.Net.Mobile.Forms.ZXingScannerView scanner = new ZXing.Net.Mobile.Forms.ZXingScannerView();


        public void Scan()
        {
            try
            {
                scanner.Options = new MobileBarcodeScanningOptions()
                {
                    UseFrontCameraIfAvailable = false, //update later to come from settings
                    PossibleFormats = new List<BarcodeFormat>(),
                    TryHarder = true,
                    AutoRotate = false,
                    TryInverted = true,
                    DelayBetweenContinuousScans = 2000
                };

                scanner.IsVisible = false;
                scanner.Options.PossibleFormats.Add(BarcodeFormat.QR_CODE);
                scanner.Options.PossibleFormats.Add(BarcodeFormat.DATA_MATRIX);
                scanner.Options.PossibleFormats.Add(BarcodeFormat.EAN_13);


                scanner.OnScanResult += (result) => {

                    // Stop scanning
                    scanner.IsAnalyzing = false;
                    if (scanner.IsScanning)
                    {
                        scanner.AutoFocus();
                    }

                    // Pop the page and show the result
                    Device.BeginInvokeOnMainThread(async () => {
                        if (result != null)
                        {
                            await DisplayAlert("Scan Value", result.Text, "OK");
                        }
                    });
                };

                mainGrid.Children.Add(scanner, 1, 0);

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}