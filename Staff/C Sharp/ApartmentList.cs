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

namespace Staff.C_Sharp
{
    public class Apartment
    {
        public int mImageId;
        public int ImageId
        {
            get { return mImageId; }
        }

        public string mName;
        public string Name
        {
            get { return Name; }
        }
    }
    public class ApartmentList
    {
        static Apartment[] mBuiltInApartments = {
            new Apartment { mImageId = Resource.Drawable.sala,
                        mName = "Sala" },
            new Apartment { mImageId = Resource.Drawable.sun_avenue,
                        mName = "The Sun Avenue" }
        };

        private Apartment[] mApartment;

        public ApartmentList()
        {
            mApartment = mBuiltInApartments;
        }

        public Apartment this[int i]
        {
            get { return mApartment[i]; }
        }

        public int NumApartments
        {
            get { return mApartment.Length; }
        }
    }
}