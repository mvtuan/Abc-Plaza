using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbcPlaza.Activities;
using AbcPlaza.Adapter;
using AbcPlaza.Api.Response;
using AbcPlaza.Listener;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace AbcPlaza.Fragments
{
    public class EquipmentFragment : Fragment, IRecycleViewOnItemClickListener
    {

        private FloatingActionButton fabAddAGP;
        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        EquipmentAdapter equipmentAdapter;
        List<Equipment> data = new List<Equipment>();



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.fragment_equipment, container, false);
            mRecycleView = v.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            fabAddAGP = v.FindViewById<FloatingActionButton>(Resource.Id.fab_add_equipment);
            fabAddAGP.Click += (sender, e) =>
            {
                Intent addIntent = new Intent(Context, typeof(AddEquipmentActivity));
                StartActivity(addIntent);
            };


            mLayoutManager = new LinearLayoutManager(Context);
            mRecycleView.SetLayoutManager(mLayoutManager);
            Equipment data1 = new Equipment();
            Equipment data2 = new Equipment();
            Equipment data3 = new Equipment();
            Equipment data4 = new Equipment();
            data1.image = Resource.Drawable.android;
            data1.td_dm = "30-09-2018";
            data1.tv_dm = "Máy quạt";
            data1.tx_dm = "30-09-2018";
            data.Add(data1);
            data2.image = Resource.Drawable.android;
            data2.td_dm = "30-09-2018";
            data2.tv_dm = "Tủ lạnh";
            data2.tx_dm = "30-09-2018";
            data.Add(data2);
            data3.image = Resource.Drawable.android;
            data3.td_dm = "30-09-2018";
            data3.tv_dm = "Điều hòa";
            data3.tx_dm = "30-09-2018";
            data.Add(data3);
            data4.image = Resource.Drawable.android;
            data4.td_dm = "30-09-2018";
            data4.tv_dm = "Bếp điện";
            data4.tx_dm = "30-09-2018";
            data.Add(data4);
            equipmentAdapter = new EquipmentAdapter(data, Context);
            mRecycleView.SetAdapter(equipmentAdapter);
            equipmentAdapter.SetRecycleViewOnItemClickListener(this);
            return v;

        }

        public void OnClick(View view, int position)
        {
            Intent updateIntent = new Intent(Context, typeof(UpdateEquipmentActivity));
            updateIntent.PutExtra("abc", data[position].td_dm);
            updateIntent.PutExtra("cbd", data[position].tv_dm);
            StartActivity(updateIntent);
        }

        public void OnLongClick(View view, int position)
        {

        }

    }
}