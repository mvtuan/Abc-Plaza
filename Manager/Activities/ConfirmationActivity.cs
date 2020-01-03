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
using Manager.Api.Request;
using Newtonsoft.Json;

namespace Manager.Activities
{
    [Activity(Label = "ConfirmationActivity")]
    public class ConfirmationActivity : AppCompatActivity
    {
        private Button confirm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_confirmation);
            confirm = FindViewById<Button>(Resource.Id.btn_confirm);
            confirm.Click += (sender, e) =>
            {
                try
                {
                    HttpClient client = new HttpClient();
                    var uri = new Uri("http://localhost:56881/api/Confirmation");
                    ConfirmationRequest request = new ConfirmationRequest();
                    request.titile = "1";
                    request.body = "2";
                    var json = JsonConvert.SerializeObject(request);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Task<HttpResponseMessage> message = client.PostAsync(uri, content);
                    if (message.Result.IsSuccessStatusCode)
                    {
                        //Intent data = new Intent();
                        //data.PutExtra(EXTRA_DATA, "Some interesting data!");
                        //SetResult(Result.Ok, data);
                        //Finish();
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

            // Create your application here
        }
    }
}