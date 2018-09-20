using Android.App;
using Android.Widget;
using Android.OS;
using NotesApp;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;

namespace NotesApp.Droid
{
    [Activity(Label = "NotesApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        List<String> dataset = new List<String>();

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
            this.dataset.Add("first");
            this.dataset.Add("second");
            this.dataset.Add("third");
            this.dataset.Add("fourth");
            mAdapter = new RecyclerViewAdapter(this.dataset);
            mRecyclerView.SetAdapter(mAdapter);
            CallApi();
        }
        public async void CallApi()
        {
            Api api = new Api();
            List<RecyclerViewItem> response = await api.GetData();
            this.dataset.Add("fifth");
            this.dataset.Add("sixth");
            foreach (RecyclerViewItem element in response)
            {
                this.dataset.Add(element.title);
            }
            this.mAdapter.NotifyDataSetChanged();
        }
    }
}

