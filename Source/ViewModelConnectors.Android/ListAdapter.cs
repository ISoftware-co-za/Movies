using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;

namespace ViewModelConnectors.Android
{
    internal class ListAdapter<T> : BaseAdapter
    {
        public ListAdapter(Context context, Func<T, int> viewTypeFunction, Func<Context, T, View, ViewGroup, View> setupViewFunc)
        {
            _context = context;
            _viewTypeFunction = viewTypeFunction;
            _setupViewFunc = setupViewFunc;
        }

        public void SetItems(IList<T> items)
        {
            _items = items;
            NotifyDataSetChanged();
        }

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int GetItemViewType(int position)
        {
            // ToDo: Does not work correctly for a ListView with multiple templates.
            return _viewTypeFunction(_items[position]);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return _setupViewFunc(_context, _items[position], convertView, parent);
        }

        public override int Count
        {
            get
            {
                if (_items != null)
                    return _items.Count;
                return 0;
            }
        }

        private readonly Context _context;
        private IList<T> _items;
        private readonly Func<T, int> _viewTypeFunction;
        private readonly Func<Context, T, View, ViewGroup, View> _setupViewFunc;
    }
}