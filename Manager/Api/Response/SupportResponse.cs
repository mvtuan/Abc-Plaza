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

namespace Manager.Api.Response
{
    public class SupportResponse
    {
        public string TypeSupport { get; set; }
    }

    public class Supports
    {
        public List<SupportResponse> value { get; set; }
    }
}