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

namespace AbcPlaza.Activities
{
    [Activity(Label = "Cập nhật thiết bị")]
    public class UpdateEquipmentActivity : AppCompatActivity
    {
        //private Button btnImage;
        //private CircleImageView imgAGP;

        private Button updateEquipment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_update_equipment);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            updateEquipment = FindViewById<Button>(Resource.Id.btn_update_equipment);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);

            //btnImage = (Button)FindViewById(Resource.Id.btn_update_agp_image);

            // Create your application here

            updateEquipment.Click += (sender, e) =>
            {
                try
                {
                    HttpClient client = new HttpClient();
                    var uri = new Uri("http://192.168.1.233:45455/odata/Equipment/65");
                    EquipmentResponse equipment = new EquipmentResponse();
                    equipment.Id = "65";
                    equipment.Name = "abcd";
                    equipment.PurchaseDate = "2021-01-01";
                    equipment.ExpirationDate = "2021-01-01";
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