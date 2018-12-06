// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace IOSTestApp
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView test { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtFIO { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (test != null) {
                test.Dispose ();
                test = null;
            }

            if (txtFIO != null) {
                txtFIO.Dispose ();
                txtFIO = null;
            }
        }
    }
}