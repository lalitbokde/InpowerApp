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

namespace InPowerIOS.Registration
{
    [Register ("PleaseComplateYourProfileViewController")]
    partial class PleaseComplateYourProfileViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem BBIContinue { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivUserProfilePic { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAboutMe { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCountry { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtState { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtZipCode { get; set; }

        [Action ("BBIContinue_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BBIContinue_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (BBIContinue != null) {
                BBIContinue.Dispose ();
                BBIContinue = null;
            }

            if (ivUserProfilePic != null) {
                ivUserProfilePic.Dispose ();
                ivUserProfilePic = null;
            }

            if (txtAboutMe != null) {
                txtAboutMe.Dispose ();
                txtAboutMe = null;
            }

            if (txtCity != null) {
                txtCity.Dispose ();
                txtCity = null;
            }

            if (txtCountry != null) {
                txtCountry.Dispose ();
                txtCountry = null;
            }

            if (txtState != null) {
                txtState.Dispose ();
                txtState = null;
            }

            if (txtZipCode != null) {
                txtZipCode.Dispose ();
                txtZipCode = null;
            }
        }
    }
}