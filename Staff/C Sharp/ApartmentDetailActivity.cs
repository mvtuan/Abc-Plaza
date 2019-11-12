using Android.App;
using Android.OS;
using Android.Util;

namespace Staff.C_Sharp
{
    [Activity(Label = "ApartmentDetailActivity")]
    public class ApartmentDetailActivity : Activity
    {
        Fragment[] fragments;

        void AddTabToActionBar(int labelResourceId, int iconResourceId)
        {
            ActionBar.Tab tab = ActionBar.NewTab()
                                         .SetText(labelResourceId)
                                         .SetIcon(iconResourceId);
            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab)sender;
            
            Fragment frag = fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.top_navigation, frag);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_apartment_detail);
            // Create your application here

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            fragments = new Fragment[]
                         {
                             new InfrastructureFragment(),
                             new PropertyFragment()
                         };

            AddTabToActionBar(Resource.String.title_infrastructure, Resource.Drawable.ic_infrastructure_18dp);
            AddTabToActionBar(Resource.String.title_property, Resource.Drawable.ic_property_18dp);
        }
    }
}