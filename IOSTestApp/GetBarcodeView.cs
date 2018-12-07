using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using AVFoundation;

namespace IOSTestApp
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }

    [Register("GetBarcodeView")]
    public class GetBarcodeView : UIViewController
    {
        AVCaptureSession captureSession = new AVCaptureSession();
        AVCaptureVideoPreviewLayer previewLayer = new AVCaptureVideoPreviewLayer();

        public GetBarcodeView()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

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