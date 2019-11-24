using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;

namespace AbcPlaza.Activities
{
    [Activity(Label = "Cập nhật thiết bị")]
    public class UpdateEquipmentActivity : AppCompatActivity
    {
        //private Button btnImage;
        //private CircleImageView imgAGP;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_update_equipment);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);

            //btnImage = (Button)FindViewById(Resource.Id.btn_update_agp_image);

            // Create your application here

            //btnImage.Click += (sender, e) =>
            //{
            //    openFileChooser();
            //};
        }
        private void openFileChooser()
        {
            //ImagePicker.Create(this)
            //        .returnMode(ReturnMode.ALL) // set whether pick and / or camera action should return immediate result or not.
            //        .folderMode(true) // folder mode (false by default)
            //        .toolbarFolderTitle("Thư mục hình ảnh") // folder selection title
            //        .toolbarImageTitle("Chọn hình ảnh") // image selection title
            //        .toolbarArrowColor(Color.WHITE) // Toolbar 'up' arrow color
            //        .theme(Resource.Style.ImagePickerTheme) //Theme
            //        .single() // single mode
            //        .showCamera(true) // show camera or not (true by default)
            //        .imageDirectory("Camera") // directory name for captured image  ("Camera" folder by default)
            //        .start(); // start image picker activity with request code
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    {
                        Finish();
                        return true;
                    }

            }
            return base.OnOptionsItemSelected(item);
        }
    }
}