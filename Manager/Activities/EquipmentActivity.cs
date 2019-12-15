using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Manager.Adapter;
using Manager.Api.Response;

namespace Manager.Activities
{
    [Activity(Label = "EquipmentActivity")]
    public class EquipmentActivity : AppCompatActivity
    {
        RecyclerView equipmentRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        EquipmentAdapter equipmentAdapter;
        List<EquipmentResponse> equipments = new List<EquipmentResponse>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_equipment);
            equipmentRecyclerView = FindViewById<RecyclerView>(Resource.Id.rc_equipment);
            mLayoutManager = new LinearLayoutManager(this);
            //mLayoutManager = new LinearLayoutManager(this);

            equipmentRecyclerView.SetLayoutManager(mLayoutManager);
            EquipmentResponse r1 = new EquipmentResponse();
            EquipmentResponse r2 = new EquipmentResponse();
            EquipmentResponse r3 = new EquipmentResponse();
            r1.EquipmentName = "Máy quạt";
            r2.EquipmentName = "Bếp điện";
            r3.EquipmentName = "Tủ lạnh";
            equipments.Add(r1);
            equipments.Add(r2);
            equipments.Add(r3);
            equipmentAdapter = new EquipmentAdapter(equipments, this);
            equipmentRecyclerView.SetAdapter(equipmentAdapter);
            //equipmentAdapter.SetRecycleViewOnItemClickListener(this);

            // Create your application here
        }
    }
}