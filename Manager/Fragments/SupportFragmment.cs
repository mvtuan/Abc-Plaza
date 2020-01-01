using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Manager.Activities;
using Manager.Adapter;
using Manager.Api.Response;
using Manager.Listener;

namespace Manager.Fragments
{
    public class SupportFragmment : Fragment, IRecycleViewOnItemClickListener
    {
        private RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        SupportAdapter supportAdapter;
        List<SupportResponse> supports = new List<SupportResponse>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static SupportFragmment NewInstance()
        {
            var frag = new SupportFragmment { Arguments = new Bundle() };
            return frag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.fragment_support, container, false);
            mRecycleView = v.FindViewById<RecyclerView>(Resource.Id.rc_support);
            mLayoutManager = new LinearLayoutManager(Context);
            mRecycleView.SetLayoutManager(mLayoutManager);
            SupportResponse support = new SupportResponse();
            support.TypeSupport = "123";
            SupportResponse support1 = new SupportResponse();
            support1.TypeSupport = "456";
            SupportResponse support2 = new SupportResponse();
            support2.TypeSupport = "789";
            supports.Add(support);
            supports.Add(support1);
            supports.Add(support2);

            supportAdapter = new SupportAdapter(supports, Context);
            mRecycleView.SetAdapter(supportAdapter);
            supportAdapter.SetRecycleViewOnItemClickListener(this);
            //GetListResident();
            return v;

        }
        public void OnClick(View view, int position)
        {
            Intent updateIntent = new Intent(Context, typeof(ConfirmationActivity));
            updateIntent.PutExtra("type", supports[position].TypeSupport);
            StartActivityForResult(updateIntent, 100);
        }

        public void OnLongClick(View view, int position)
        {

        }
    }
}