// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Movies.View.iOS
{
    [Register ("ViewControllerMovieDetails")]
    partial class ViewControllerMovieDetails
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton IMDBWebsite { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView MovieAttributes { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Plot { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Poster { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (IMDBWebsite != null) {
                IMDBWebsite.Dispose ();
                IMDBWebsite = null;
            }

            if (MovieAttributes != null) {
                MovieAttributes.Dispose ();
                MovieAttributes = null;
            }

            if (Plot != null) {
                Plot.Dispose ();
                Plot = null;
            }

            if (Poster != null) {
                Poster.Dispose ();
                Poster = null;
            }

            if (Poster != null) {
                Poster.Dispose ();
                Poster = null;
            }
        }
    }
}