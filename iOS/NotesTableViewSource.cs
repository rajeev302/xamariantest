using System;
using Foundation;
using UIKit;

namespace NotesApp.iOS
{
    public class NotesTableViewSource : UITableViewSource
    {
        private const string CELL_IDENTIFIER = "CellIdentifier";
        string[] list;
        public NotesTableViewSource()
        {
        }

        public NotesTableViewSource(string[] list)
        {
            this.list = list;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CELL_IDENTIFIER);

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CELL_IDENTIFIER);
            }

            string item = list[indexPath.Row];
            cell.TextLabel.Text = item;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return list.Length;
        }
    }
}
