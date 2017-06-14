using System;
using Foundation;
using UIKit;

namespace StoryboardTable
{
	public class RootTableSource : UITableViewSource {

		// there is NO database or storage of Tasks in this example, just an in-memory List<>
		Chore[] tableItems;
		string cellIdentifier = "taskcell"; // set in the Storyboard

		public RootTableSource (Chore[] items)
		{
			tableItems = items;
		}
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Length;
		}
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
            var cell = tableView.DequeueReusableCell (cellIdentifier) as TaskTableViewCell;
			if (cell == null)
			{
                IntPtr handle = System.Runtime.InteropServices.Marshal.StringToHGlobalAuto(cellIdentifier);
				cell = new TaskTableViewCell(handle);
			}
            cell.UpdateCell(tableItems[indexPath.Row].Name);
			return cell;
		}
		public Chore GetItem(int id) {
			return tableItems[id];
		}
	}
}

