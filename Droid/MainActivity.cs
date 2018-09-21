using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;

namespace NotesApp.Droid
{
    [Activity(Label = "NotesApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        List<RecyclerViewItem> dataset = new List<RecyclerViewItem>();

        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerViewAdapter mAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            //plug in the linear layout manager
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //plug in the adapter:
            mAdapter = new RecyclerViewAdapter(this.dataset);
            mRecyclerView.SetAdapter(mAdapter);
            mAdapter.ItemClick += OnItemClick;
            CallApi();
        }

        void OnItemClick(object sender, int position)
        {
            int photoNum = position + 1;
            Android.Util.Log.Info("cardClicked", "on item click function called");
            Android.Widget.Toast.MakeText(this, "This is photo number " + photoNum, Android.Widget.ToastLength.Short).Show();
        }

        public async void CallApi()
        {
            Api api = new Api();
            List<RecyclerViewItem> response = await api.GetData();
            foreach (RecyclerViewItem element in response)
            {
                this.dataset.Add(element);
            }
            this.mAdapter.NotifyDataSetChanged();
        }
    }
}

