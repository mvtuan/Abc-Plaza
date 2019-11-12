using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Staff.C_Sharp
{
    class ApartmentAdapter : RecyclerView.Adapter
    {

        public ApartmentList mApartment = new ApartmentList();
        public ApartmentAdapter(ApartmentList apartment)
        {
            mApartment = apartment;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.item_apartment, parent, false);
            ApartmentViewHolder vh = new ApartmentViewHolder(itemView);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ApartmentViewHolder vh = holder as ApartmentViewHolder;
            vh.Image.SetImageResource(mApartment[position].ImageId);
            vh.Name.Text = mApartment[position].Name;
        }

        public override int ItemCount
        {
            get { return mApartment.NumApartments; }
        }

    }
}