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
            // Sua .activity_main để 
            //SetContentView(Resource.Layout.activity_main);

            //var lstData = FindViewById<ListView>(Resource.Id.listView1);
            //List<Notification> lstSource = new List<Notification>();
            //for (int i = 0; i < 12; i++)
            //{

            //    Notification notification = new Notification()
            //    {
            //        id = i,
            //        sender = 12 + i,
            //        title = "Thông báo đóng tiền điện tháng " + i,
            //        content = "Chào ông/bà \nCông ty TTHH Điện lực miền Nam ...",
            //        date = new DateTime(2019, i+1, 14, 13, 0, 0),
            //    };
            //    lstSource.Add(notification);
            //}

            //var adapter = new NotificationAdapter(this, lstSource);
            //lstData.Adapter = adapter;




            //Màn hình Chi tiết thông báo
            SetContentView(Resource.Layout.fragment_detail_notification);

            //var lstData = FindViewById<ListView>(Resource.Id.listView1);

            var txtTitle1 = FindViewById<TextView>(Resource.Id.textTitle1);
            var txtContent1 = FindViewById<TextView>(Resource.Id.textContent1);
            var txtDate1 = FindViewById<TextView>(Resource.Id.textDate1);
            var date = new DateTime(2019, 1, 14, 13, 0, 0);

            txtTitle1.Text = "Thông báo thu tiền điện tháng 1/2019";
            txtContent1.Text = "Chào ông/bà \n\nCông ty TTHH Điện lực miền Nam xin trân trọng thông báo đã đến kỳ hạn đóng tiền điện tháng 1. Thời gian thu tiền điện diễn ra từ ngày 28/1/2019 đến ngày 31/1/2019. \n\nKính mong quý khách hàng hợp tác. Nếu phí điện không được thanh toán theo quy định chúng tôi sẽ tạm ngừng dịch vụ cho đến khi quý khách thanh toán.\n Chúc quý khách an khang thịnh vượng. \n\n Thay mặt Điện lực Miền Nam,\n Lê Xuân Mạnh";
            txtDate1.Text = date.ToString();

        }
    }
}