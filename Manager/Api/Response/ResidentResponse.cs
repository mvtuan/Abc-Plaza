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

namespace Manager.Api.Response
{
    public class ResidentResponse
    {
        public string Id { get; set; }

        public string ResidentName { get; set; }

        public string Room { get; set; }

        public string Floor { get; set; }

        public string ResidentImage { get; set; }
    }
}