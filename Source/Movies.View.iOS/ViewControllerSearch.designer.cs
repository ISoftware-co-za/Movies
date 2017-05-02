// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Movies.View.iOS
{
    [Register ("ViewControllerSearch")]
    partial class ViewControllerSearch
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView SearchResults { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar SearchTerm { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (SearchResults != null) {
                SearchResults.Dispose ();
                SearchResults = null;
            }

            if (SearchTerm != null) {
                SearchTerm.Dispose ();
                SearchTerm = null;
            }
        }
    }
}