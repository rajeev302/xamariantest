﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace NotesApp.Droid
{
    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public TextView text { get; private set; }

        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            text = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }
}