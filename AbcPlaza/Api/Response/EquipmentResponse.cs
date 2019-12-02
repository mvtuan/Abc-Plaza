﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AbcPlaza.Api.Response
{
    public class EquipmentResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PurchaseDate { get; set; }

        public string ExpirationDate { get; set; }

        //public int image { get; set; }


    }
}