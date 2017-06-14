using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Drawing;

namespace StoryboardTable
{
    public partial class TaskTableViewCell : UITableViewCell
    {
		CollectionViewSource source;
        CollectionViewFlowDelegate flowDelegate;

        public TaskTableViewCell (IntPtr handle) : base (handle)
        {
        }

        public TaskTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
        }

		public void UpdateCell(string title)
		{
            TitleLabel.Text = title;

			// Create the Collection View Source

			source = new CollectionViewSource();
			TagsCollectionView.Source = source;

			flowDelegate = new CollectionViewFlowDelegate(source);
            TagsCollectionView.Delegate = flowDelegate;

            //TagsCollectionView.LayoutMargins = new UIEdgeInsets(20.0f, 20.0f, 20.0f, 20.0f);

			// Register the TextCell class for the Cells in the Collection View

			TagsCollectionView.RegisterClassForCell(typeof(ImageCell), ImageCell.CellId);

            TagsCollectionView.Frame = new RectangleF(16, 40, 260, 120);

			ContentView.AddConstraint(
			  NSLayoutConstraint.Create(
                TagsCollectionView, NSLayoutAttribute.Leading,
				NSLayoutRelation.Equal,
                ContentView, NSLayoutAttribute.LeadingMargin,
				1, 10
			  )
			);

			ContentView.AddConstraint(
			  NSLayoutConstraint.Create(
				TitleLabel, NSLayoutAttribute.Top,
				NSLayoutRelation.Equal,
				ContentView, NSLayoutAttribute.TopMargin,
				1, 3
			  )
			);

			ContentView.AddConstraint(
			  NSLayoutConstraint.Create(
				TitleLabel, NSLayoutAttribute.Bottom,
				NSLayoutRelation.Equal,
				TagsCollectionView, NSLayoutAttribute.Top,
				1, 0
			  )
			);

			ContentView.AddConstraint(
			  NSLayoutConstraint.Create(
				TagsCollectionView, NSLayoutAttribute.Bottom,
				NSLayoutRelation.Equal,
				ContentView, NSLayoutAttribute.BottomMargin,
				1, 3
			  )
			);
		}

		// CollectionViewFlowDelegate - the Collection View's Flow Delegate

		class CollectionViewFlowDelegate : UICollectionViewDelegateFlowLayout
		{
			CollectionViewSource source;
			string[] data = null;

			public CollectionViewFlowDelegate(CollectionViewSource inSource)
			{
                //minimumLineSpacing

				source = inSource;
				data = source.Data;
			}

			public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
			{
				UIImage image = UIImage.FromBundle(data[indexPath.Row]);

				var imageWidth  = image.CurrentScale * image.Size.Width;
				var imageHeight = image.CurrentScale * image.Size.Height;

				return new CGSize(imageWidth, imageHeight);
			}
		}

		// CollectionViewSource - the Collection View's Source

		class CollectionViewSource : UICollectionViewSource
		{
			private string[] data = { "Group_Image_AllElse", "Group_Image_StudentOrg", "Group_Image_AllElse", "Group_Image_AllElse", "Group_Image_StudentOrg" };
			//private string[] data = { "Group_Image_AllElse", "Group_Image_StudentOrg" };
            private int row = 0;

			public int Row
			{
				get
				{
					return row;
				}

				set
				{
					row = value;
				}
			}

			public string[] Data
			{
				get
				{
					return data;
				}
			}

			public override nint GetItemsCount(UICollectionView collectionView, nint section)
			{
				return data.Length;
			}

			public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
			{
				ImageCell imageCell = (ImageCell)collectionView.DequeueReusableCell(ImageCell.CellId, indexPath);

				UIImage image = UIImage.FromBundle(data[indexPath.Row]);

				var imageWidth = image.CurrentScale * image.Size.Width;
				var imageHeight = image.CurrentScale * image.Size.Height;

				imageCell.imageView.Frame = new RectangleF(
					(float)imageCell.imageView.Frame.Left, (float)imageCell.imageView.Frame.Top,
					(float)imageWidth, (float)imageHeight
				);

				imageCell.imageView.Image = image;

				return imageCell;
			}

			public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
			{
				Console.WriteLine("Row {0} selected", indexPath.Row);
			}

			public override bool ShouldSelectItem(UICollectionView collectionView, NSIndexPath indexPath)
			{
				return true;
			}
		}

		// ImageCell - the Collection View Cells

		class ImageCell : UICollectionViewCell
		{
			public UIImageView imageView;

			public static readonly NSString CellId = new NSString("ImageCell");

			[Export("initWithFrame:")]
			ImageCell(RectangleF frame) : base(frame)
			{
				imageView = new UIImageView();
                //imageView.LayoutMargins = new UIEdgeInsets(20.0f, 20.0f, 20.0f, 20.0f);
				ContentView.AddSubview(imageView);
			}
		}
    }
}