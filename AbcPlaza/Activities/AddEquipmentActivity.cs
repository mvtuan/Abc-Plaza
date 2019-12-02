using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Java.Util;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AbcPlaza.Api.Response;
using Android.Util;
using AbcPlaza.Adapter;

namespace AbcPlaza.Activities
{
    [Activity(Label = "Thêm thiết bị")]
    public class AddEquipmentActivity : AppCompatActivity
    {
        public static  String EXTRA_DATA = "EXTRA_DATA";
        private EditText eText;
        private EditText eText1;
        private Button addEquipment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_equipment);
            eText = (EditText)FindViewById(Resource.Id.edt_add_equip_name);
            eText1 = (EditText)FindViewById(Resource.Id.edt_add_abc);
            addEquipment = (Button)FindViewById(Resource.Id.btn_add_equipment);
            eText.Click += (sender, e) =>
            {
                Calendar cldr = Calendar.Instance;
                int day = cldr.Get(CalendarField.DayOfMonth);
                int month = cldr.Get(CalendarField.Month);
                int year = cldr.Get(CalendarField.Year);
                // date picker dialog
                DatePickerDialog picker = new DatePickerDialog(this, OnDateSet, year, month, day);
                picker.Show();
            };
            eText1.Click += (sender, e) =>
            {
                Calendar cldr = Calendar.Instance;
                int day = cldr.Get(CalendarField.DayOfMonth);
                int month = cldr.Get(CalendarField.Month);
                int year = cldr.Get(CalendarField.Year);
                // date picker dialog
                DatePickerDialog picker = new DatePickerDialog(this, OnDateSet1, year, month, day);
                picker.Show();
            };
            addEquipment.Click += (sender, e) =>
             {
                 try
                 {
                     HttpClient client = new HttpClient();
                     var uri = new Uri("http://192.168.1.233:45455/odata/Equipment");
                     EquipmentResponse equipment = new EquipmentResponse();
                     equipment.Id = "1";               
                     equipment.Name = "demo";
                     equipment.PurchaseDate = "2020-01-01";
                     equipment.ExpirationDate = "2020-01-01";
                     var json = JsonConvert.SerializeObject(equipment);
                     var content = new StringContent(json, Encoding.UTF8, "application/json");
                     Task<HttpResponseMessage> message = client.PostAsync(uri, content);
                     if (message.Result.IsSuccessStatusCode)
                     {
                         Intent data = new Intent();
                         // Truyền data vào intent
                         data.PutExtra(EXTRA_DATA, "Some interesting data!");
                         SetResult(Result.Ok,data);
                         Finish(); 
                     }
                     else
                     {
                         Log.Error("Some errors", " errors");
                     }
                 }
                 catch(Exception ex)
                 {
                     Console.WriteLine(ex.ToString());
                 }
                
             };


            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            //SupportActionBar.SetHomeButtonEnabled(true);
            // Create your application here
        }

        private void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            eText.Text = e.Date.ToShortDateString();
        }

        private void OnDateSet1(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            eText1.Text = e.Date.ToShortDateString();
        }



        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    {
                        Finish();
                        return true;
                    }

            }
            return base.OnOptionsItemSelected(item);
        }

    }
}