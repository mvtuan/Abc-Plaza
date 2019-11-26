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

namespace ManageNotification.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtTitle { get; set; }
        public TextView txtContent { get; set; }
        public TextView txtDate { get; set; }
        public TextView txtId { get; set; }
    }

    public class NotificationAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Notification> notifications;

        public NotificationAdapter(Activity activity, List<Notification>notifications)
        {
            this.activity = activity;
            this.notifications = notifications;
        }

        public override int Count
        {
            get
            {
                return notifications.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return notifications[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
           
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.fragment_notification, parent, false);
            var txtTitle = view.FindViewById<TextView>(Resource.Id.textTitle);
            var txtContent = view.FindViewById<TextView>(Resource.Id.textContent);
            var txtDate = view.FindViewById<TextView>(Resource.Id.textDate);

            txtTitle.Text = notifications[position].title;
            txtContent.Text = notifications[position].content;
            txtDate.Text = notifications[position].date.ToString();

            return view;
        }
    }

}