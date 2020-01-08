using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Manager.Api.Response;
using Manager.Constant;
using Newtonsoft.Json;
using Square.Picasso;

namespace Manager.Activities
{
    [Activity(Label = "Xác nhận hỗ trợ")]
    public class ConfirmationActivity : AppCompatActivity
    {
        private TextView typeSupport;
        private TextView dateSupport;
        private TextView addressSupport;
        private ImageView billSupport;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_confirmation);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar_main);
            typeSupport = FindViewById<TextView>(Resource.Id.tv_type_support);
            dateSupport= FindViewById<TextView>(Resource.Id.tv_date_support);
            addressSupport = FindViewById<TextView>(Resource.Id.tv_address_support);
            billSupport = FindViewById<ImageView>(Resource.Id.img_bill_support);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            try
            {
                HttpClient client = new HttpClient();
                string supportId = Intent.GetStringExtra("id");
                string url = Url.BASE_URL + "FindSupportById" + "(" + "Id=" + supportId + ")";
                var uri = new Uri(url);
                Task<HttpResponseMessage> message = client.GetAsync(uri);
                if (message.Result.IsSuccessStatusCode)
                {
                    var content = message.Result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Confirms>(content.Result);
                    int count = response.value.Count();
                    for (int i = 0; i < count; i++)
                    {
                        ConfirmResponse confirmResponse = new ConfirmResponse();
                        typeSupport.Text = response.value.ElementAt(0).SupportType;
                        dateSupport.Text = response.value.ElementAt(0).SupportDate;
                        addressSupport.Text = response.value.ElementAt(0).SupportAddress;
                        Picasso.With(this)
                        .Load(response.value.ElementAt(0).SupportImage)
                        .Resize(90, 90)
                        .Into(billSupport);
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



            // Create your application here
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.popup_menu, menu);
            return base.OnCreateOptionsMenu(menu);
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