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
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Android.Util;
using AbcPlaza.Api.Response;
using Java.Util;

namespace AbcPlaza.Activities
{
    [Activity(Label = "Cập nhật thiết bị")]
    public class UpdateEquipmentActivity : AppCompatActivity
    {
        //private Button btnImage;
        //private CircleImageView imgAGP;

       
        private EditText updateEquipmentName;
        private EditText updatePurchaseDate;
        private EditText updateWarrantyPeriod;
        private Button updateEquipment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_update_equipment);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            updateEquipmentName = FindViewById<EditText>(Resource.Id.edt_update_equipment_name);
            updatePurchaseDate = FindViewById<EditText>(Resource.Id.edt_update_purchase_date);
            updateWarrantyPeriod = FindViewById<EditText>(Resource.Id.edt_update_warranty_period);
            updateEquipment = FindViewById<Button>(Resource.Id.btn_update_equipment);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);

            //btnImage = (Button)FindViewById(Resource.Id.btn_update_agp_image);

            // Create your application here

            updatePurchaseDate.Click += (sender, e) =>
            {
                Calendar cldr = Calendar.Instance;
                int day = cldr.Get(CalendarField.DayOfMonth);
                int month = cldr.Get(CalendarField.Month);
                int year = cldr.Get(CalendarField.Year);
                // date picker dialog
                DatePickerDialog picker = new DatePickerDialog(this, OnDateSet, year, month, day);
                picker.Show();
            };

            updateEquipment.Click += (sender, e) =>
            {
                try
                {
                    
                    EquipmentResponse equipment = new EquipmentResponse();
                    equipment.Id = Intent.GetStringExtra("id");
                    equipment.EquipmentName = updateEquipmentName.Text.ToString();
                    string update = updatePurchaseDate.Text.ToString();
                    DateTime dt = DateTime.ParseExact(update, "dd/MM/yyyy", null);
                    equipment.PurchaseDate = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
                    string warrantyPeriod = updateWarrantyPeriod.Text.ToString();
                    equipment.WarrantyPeriod = Int32.Parse(warrantyPeriod);
                    string url = "http://192.168.1.233:45455/odata/Equipment/" + equipment.Id;
                    HttpClient client = new HttpClient();
                    var uri = new Uri(url);
                    var json = JsonConvert.SerializeObject(equipment);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Task<HttpResponseMessage> message = client.PutAsync(uri, content);
                    if (message.Result.IsSuccessStatusCode)
                    {
                        Intent data = new Intent();
                        // Truyền data vào intent
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
                updatePurchaseDate.Text = "0" + e.Date.Day.ToString() + "/" + "0" + e.Date.Month.ToString() + "/" + e.Date.Year.ToString();
            }
            else
            {
                if (e.Date.Day.ToString().Length < 2)
                {
                    updatePurchaseDate.Text = "0" + e.Date.Day.ToString() + "/" + e.Date.Month.ToString() + "/" + e.Date.Year.ToString();
                }
                else if (e.Date.Month.ToString().Length < 2)
                {
                    updatePurchaseDate.Text = e.Date.Day.ToString() + "/" + "0" + e.Date.Month.ToString() + "/" + e.Date.Year.ToString();
                }
                else
                {
                    updatePurchaseDate.Text = e.Date.Day.ToString() + "/" + e.Date.Month.ToString() + "/" + e.Date.Year.ToString();
                }
            }
        }
        private void openFileChooser()
        {
            //ImagePicker.Create(this)
            //        .returnMode(ReturnMode.ALL) // set whether pick and / or camera action should return immediate result or not.
            //        .folderMode(true) // folder mode (false by default)
            //        .toolbarFolderTitle("Thư mục hình ảnh") // folder selection title
            //        .toolbarImageTitle("Chọn hình ảnh") // image selection title
            //        .toolbarArrowColor(Color.WHITE) // Toolbar 'up' arrow color
            //        .theme(Resource.Style.ImagePickerTheme) //Theme
            //        .single() // single mode
            //        .showCamera(true) // show camera or not (true by default)
            //        .imageDirectory("Camera") // directory name for captured image  ("Camera" folder by default)
            //        .start(); // start image picker activity with request code
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