using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace NotesApp.Droid
{
    class RecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<RecyclerViewItem> dataset;
        public RecyclerViewAdapter(List<RecyclerViewItem> dataset)
        {
            this.dataset = dataset;
        }

        public override int ItemCount
        {
            get { return this.dataset.Count;  }
        }

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder vh = holder as RecyclerViewHolder;
            vh.text.Text = dataset[position].title;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RecyclerCardView, parent, false);
            RecyclerViewHolder vh = new RecyclerViewHolder(itemView, OnClick);
            return vh;
        }
    }
}