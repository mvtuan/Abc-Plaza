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
using System.Net.Http;
using AbcPlaza.Api;
using Newtonsoft.Json;
using Android.Util;
using AbcPlaza.Api.Request;

namespace AbcPlaza.Fragments
{
    public class EquipmentFragment : Fragment, IRecycleViewOnItemClickListener
    {

        private FloatingActionButton fabAddAGP;
        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        EquipmentAdapter equipmentAdapter;
        List<EquipmentResponse> data = new List<EquipmentResponse>();



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
            var model = new RestApi();
            try
            {
                HttpResponseMessage message = model.GetAsync("http://172.19.200.72:45461/odata/Equipment").Result;
                if (message.IsSuccessStatusCode)
                {
                    var content = message.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<ValueResponse>(content.Result);
                    int count = response.value.Count();
                    for (int i = 0; i < count; i++)
                    {
                        EquipmentResponse equipment = new EquipmentResponse();
                        equipment.Name = response.value.ElementAt(i).Name;
                        equipment.PurchaseDate = response.value.ElementAt(i).PurchaseDate;
                        equipment.ExpirationDate = response.value.ElementAt(i).ExpirationDate;
                        data.Add(equipment);

                    }
                }
                else
                {
                    Log.Error("Some errors", " errors");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            equipmentAdapter = new EquipmentAdapter(data, Context);
            mRecycleView.SetAdapter(equipmentAdapter);
            equipmentAdapter.SetRecycleViewOnItemClickListener(this);
            return v;

        }

        public void OnClick(View view, int position)
        {
            Intent updateIntent = new Intent(Context, typeof(UpdateEquipmentActivity));
            updateIntent.PutExtra("abc", data[position].PurchaseDate);
            updateIntent.PutExtra("cbd", data[position].Id);
            StartActivity(updateIntent);
        }

        public void OnLongClick(View view, int position)
        {

        }

    }
}