using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace ViewModelConnectors.iOS
{
    internal class ListUITableViewSource<T> : UITableViewSource
    {
        public ListUITableViewSource(UITableViewCellStyle cellStyle, nfloat? rowHeight, Action<T, UITableViewCell> setupAction)
        {
            _cellStyle = cellStyle;
            _rowHeight = rowHeight;
            _setupAction = setupAction;
        }

        public void SetItems(List<T> items)
        {
            _items = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            T item = _items[indexPath.Row];

            if (cell == null)
                cell = new UITableViewCell(_cellStyle, cellIdentifier);

            _setupAction(item, cell);

            return cell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if (_rowHeight.HasValue)
                return _rowHeight.Value;
            return UITableView.AutomaticDimension;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items?.Count ?? 0;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            RowTapped?.Invoke(this, new RowSelectedEventArgs(_items[indexPath.Row]));
        }

        public event RowSelectedEventHandler RowTapped;

        private const string cellIdentifier = "CellIdentifier";

        private readonly UITableViewCellStyle _cellStyle;
        private readonly nfloat? _rowHeight;
        private readonly Action<T, UITableViewCell> _setupAction;
        private List<T> _items;
    }
}
