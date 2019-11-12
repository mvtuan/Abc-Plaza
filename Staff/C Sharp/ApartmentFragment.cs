using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Staff.C_Sharp
{
    public class ApartmentFragment : Fragment
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        ApartmentAdapter mAdapter;
        ApartmentList mApartmentList;
        Context context = Android.App.Application.Context;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here

            

        }

        public static ApartmentFragment NewInstance()
        {
            var frag = new ApartmentFragment { Arguments = new Bundle() };
            return frag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.fragment_apartment, null);
            mApartmentList = new ApartmentList();
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mLayoutManager = new LinearLayoutManager((MainActivity)this.Activity, LinearLayoutManager.Horizontal, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new ApartmentAdapter(mApartmentList);
            mRecyclerView.SetAdapter(mAdapter);
            return view;
        }
    }
}