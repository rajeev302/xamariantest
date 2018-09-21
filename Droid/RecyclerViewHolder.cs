using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace NotesApp.Droid
{
    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public TextView text { get; private set; }

        public RecyclerViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            text = itemView.FindViewById<TextView>(Resource.Id.textView);
            itemView.Click += (sender, e) => listener(LayoutPosition);
        }
    }
}