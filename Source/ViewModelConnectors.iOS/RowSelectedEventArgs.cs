using System;

namespace ViewModelConnectors.iOS
{
    public delegate void RowSelectedEventHandler(object sender, RowSelectedEventArgs args);

    public class RowSelectedEventArgs : EventArgs
    {
        public object SelectedItem { get; }

        public RowSelectedEventArgs(object selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
