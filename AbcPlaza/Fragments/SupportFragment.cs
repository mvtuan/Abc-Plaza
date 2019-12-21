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