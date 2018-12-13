using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using AVFoundation;
using ZXing;

namespace IOSTestApp
{
    [Register("GetBarcodeView")]
    public class GetBarcodeView : UIViewController
    {
        AVCaptureSession captureSession = new AVCaptureSession();
        AVCaptureVideoPreviewLayer previewLayer = new AVCaptureVideoPreviewLayer();
        UIButton buttonScan = new UIButton();


        public GetBarcodeView()
        {
            buttonScan.TouchDown += (sender, e) =>
            {

                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();

                if (result != null)
                    Console.WriteLine("Scanned Barcode: " + result.Text);
            };
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
            //  initCameraView();

            // Perform any additional setup after loading the view
        }
        public void initCameraView()
        {
            captureSession.SessionPreset = AVCaptureSession.PresetHigh;
            var camera = AVCaptureDevice.GetDefaultDevice(AVMediaType.Video);
            if (camera == null)
            {
                throw new Exception("Can't find devices");
            }

            var cameraInput = AVCaptureDeviceInput.FromDevice(camera);

            if (captureSession.CanAddInput(cameraInput))
            {
                captureSession.AddInput(cameraInput);
            }
            View.BackgroundColor = UIColor.GroupTableViewBackgroundColor.ColorWithAlpha((float)0.7);

        }

    }
}