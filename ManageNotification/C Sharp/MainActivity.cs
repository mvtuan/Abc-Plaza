using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using ManageNotification.Resources;
using Java.Util;
using Android.Icu.Text;

namespace ManageNotification
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var lstData = FindViewById<ListView>(Resource.Id.listView1);
            List<Notification> lstSource = new List<Notification>();
            for (int i = 0; i < 12; i++)
            {
                
                Notification notification = new Notification()
                {
                    id = i,
                    sender = 12 + i,
                    title = "Thông báo đóng tiền điện tháng " + i,
                    content = "Chào ông/bà \nCông ty TTHH Điện lực miền Nam ...",
                    date = new DateTime(2019, i+1, 14, 13, 0, 0),
                };
                lstSource.Add(notification);
            }

            var adapter = new NotificationAdapter(this, lstSource);
            lstData.Adapter = adapter;
        }
    }
}