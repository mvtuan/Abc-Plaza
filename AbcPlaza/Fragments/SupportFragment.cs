using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using AbcPlaza.Api.Request;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Android.Util;

namespace AbcPlaza.Fragments
{
    public class SupportFragment : Fragment
    {
        private EditText messageSupport;
        private Button register;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var v = inflater.Inflate(Resource.Layout.fragment_support, container, false);
            messageSupport = v.FindViewById<EditText>(Resource.Id.edt_msg_support);
            register = v.FindViewById<Button>(Resource.Id.btn_register);

            register.Click += (sender, e) =>
            {
                try
                {
                    HttpClient client = new HttpClient();
                    var uri = new Uri("http://172.16.0.139:45455/Support");
                    SupportRequest supportRequest = new SupportRequest();
                    supportRequest.SupportType = "lap rap";
                    supportRequest.SupportDate = "2020-02-02";
                    supportRequest.SupportImage = "http://192.168.1.118:45457/Static/Equipment/washing_machine.png";
                    supportRequest.ResidentId = 3;
                    var json = JsonConvert.SerializeObject(supportRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Task<HttpResponseMessage> message = client.PostAsync(uri, content);
                    if (message.Result.IsSuccessStatusCode)
                    {
                        Console.WriteLine("di an trua");
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
            return v;
        }
        public static SupportFragment NewInstance()
        {
            var frag = new SupportFragment { Arguments = new Bundle() };
            return frag;
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The Language is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(Context, toast, ToastLength.Long).Show();
        }
    }
}