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
        public static String EXTRA_DATA = "EXTRA_DATA";

        private EditText addEquipmentName;
        private EditText addPurchaseDate;
        private EditText addWarrantyPeriod;
        private Button addEquipment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_equipment);


            //ActionBar.SetTitle(Resource.String.title_add_equipment);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_main);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            //SupportActionBar.SetHomeButtonEnabled(true);
            // Create your application here

            //SupportActionBar.SetTitle(Resource.String.title_add_equipment);
            //SupportActionBar.Title = "123";
            //SupportActionBar
            addEquipmentName = (EditText)FindViewById(Resource.Id.edt_add_equipment_name);
            addPurchaseDate = (EditText)FindViewById(Resource.Id.edt_add_purchase_date);
            addWarrantyPeriod = (EditText)FindViewById(Resource.Id.edt_add_warranty_period);
            addEquipment = (Button)FindViewById(Resource.Id.btn_add_equipment);
            addPurchaseDate.Click += (sender, e) =>
            {
                Calendar cldr = Calendar.Instance;
                int day = cldr.Get(CalendarField.DayOfMonth);
                int month = cldr.Get(CalendarField.Month);
                int year = cldr.Get(CalendarField.Year);
                // date picker dialog
                DatePickerDialog picker = new DatePickerDialog(this, OnDateSet, year, month, day);
                picker.Show();
            };
            addEquipment.Click += (sender, e) =>
             {
                 try
                 {
                     HttpClient client = new HttpClient();
                     var uri = new Uri("http://172.19.200.228:45457/odata/Equipment");
                     EquipmentResponse equipment = new EquipmentResponse();
                     equipment.Id = "1";
                     equipment.EquipmentName = addEquipmentName.Text.ToString();
                     string add = addPurchaseDate.Text.ToString();      
                     DateTime dt = DateTime.ParseExact(add, "dd/MM/yyyy", null);
                     equipment.PurchaseDate = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
                     string warrantyPeriod = addWarrantyPeriod.Text.ToString();
                     equipment.WarrantyPeriod = Int32.Parse(warrantyPeriod);
                     var json = JsonConvert.SerializeObject(equipment);
                     var content = new StringContent(json, Encoding.UTF8, "application/json");
                     Task<HttpResponseMessage> message = client.PostAsync(uri, content);
                     if (message.Result.IsSuccessStatusCode)
                     {
                         Intent data = new Intent();
                         data.PutExtra(EXTRA_DATA, "Some interesting data!");
                         SetResult(Result.Ok, data);
                         Finish();
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

             };


        }

        private void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            if (e.Date.Day.ToString().Length < 2 && e.Date.Month.ToString().Length < 2)
            {
                addPurchaseDate.Text = "0" + e.Date.Day.ToString() + "/" + "0" + e.Date.Month.ToString() + "/" + e.Date.Year.ToString();
            }
            else
            {
                if (e.Date.Day.ToString().Length < 2)
                {
                    addPurchaseDate.Text = "0" + e.Date.Day.ToString() + "/" + e.Date.Month.ToString() + "/" + e.Date.Year.ToString();
                }
                else if (e.Date.Month.ToString().Length < 2)
                {
                    addPurchaseDate.Text = e.Date.Day.ToString() + "/" + "0" + e.Date.Month.ToString() + "/" + e.Date.Year.ToString();
                }
                else
                {
                    addPurchaseDate.Text = e.Date.Day.ToString() + "/" + e.Date.Month.ToString() + "/" + e.Date.Year.ToString();
                }
            }
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