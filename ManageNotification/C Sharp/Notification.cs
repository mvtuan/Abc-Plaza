using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ManageNotification
{
    public class Notification
    {
        public string content { get; set; }
        public DateTime date { get; set; }
        public int id { get; set; }
        public int sender { get; set; }
        public string title { get; set; }

    }
}