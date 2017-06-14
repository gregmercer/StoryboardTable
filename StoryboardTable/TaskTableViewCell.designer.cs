// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace StoryboardTable
{
    [Register ("TaskTableViewCell")]
    partial class TaskTableViewCell
    {
        [Outlet]
        UIKit.UILabel TitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView TagsCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TagsCollectionView != null) {
                TagsCollectionView.Dispose ();
                TagsCollectionView = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}