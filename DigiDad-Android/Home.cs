using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
//using Android.Support.V7.Textview;
using Android.Views;
using Android.Widget;
using System;

namespace DigiDad_Android
{
    [Activity]
    public class Home : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);


            SetSupportActionBar((Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar1));


            var metrics = Resources.DisplayMetrics;

            float height = metrics.HeightPixels;
            float width = metrics.WidthPixels;
            //Activity.WindowService..Sc
            SetContentView(Resource.Layout.home);

           BottomNavigationView navigationView = (BottomNavigationView)FindViewById(Resource.Id.navigation);
            navigationView.SetOnNavigationItemSelectedListener(this);

            TextView[] topRowText = new TextView[5];

            ImageView[] topRow = new ImageView[4];


            topRow[0] = (ImageView) FindViewById(Resource.Id.imageView1);
            topRow[1] = (ImageView)FindViewById(Resource.Id.imageView2);
            topRow[2] = (ImageView)FindViewById(Resource.Id.imageView3);
            topRow[3] = (ImageView)FindViewById(Resource.Id.imageView4);
            foreach (View view in topRow)
            {

                view.LayoutParameters.Height = int.Parse(Math.Ceiling(height / 10 * 2.5).ToString());
                view.LayoutParameters.Width = view.LayoutParameters.Height;

            }

            ImageView[] secondRow = new ImageView[5];

            secondRow[0] = (ImageView)FindViewById(Resource.Id.imageView6);
            secondRow[1] = (ImageView)FindViewById(Resource.Id.imageView7);
            secondRow[2] = (ImageView)FindViewById(Resource.Id.imageView8);
            secondRow[3] = (ImageView)FindViewById(Resource.Id.imageView9);
            secondRow[4] = (ImageView)FindViewById(Resource.Id.imageView10);

            foreach (View view in secondRow)
            {

                view.LayoutParameters.Height = int.Parse(Math.Ceiling(height / 10 * 2.5).ToString());
                view.LayoutParameters.Width = view.LayoutParameters.Height;

            }


            ImageView[] thirdRow = new ImageView[4];

            thirdRow[0] = (ImageView)FindViewById(Resource.Id.imageView11);
            thirdRow[1] = (ImageView)FindViewById(Resource.Id.imageView12);
            thirdRow[2] = (ImageView)FindViewById(Resource.Id.imageView13);
            thirdRow[3] = (ImageView)FindViewById(Resource.Id.imageView14);

            foreach (View view in thirdRow)
            {

                view.LayoutParameters.Height = int.Parse(Math.Ceiling(height / 10 * 2.0).ToString());
               view.LayoutParameters.Width = view.LayoutParameters.Height;

            }


            //  textMessage = FindViewById<TextView>(Resource.Id.message);
            //  BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);


            //navigation.SetOnNavigationItemSelectedListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {

            Intent intent;
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:

                  //  intent = new Intent(this, typeof(Login));


                   // StartActivity(intent);
                    return true;
                case Resource.Id.navigation_explore:

                    intent = new Intent(this, typeof(Explore));


                    StartActivity(intent);
                    return true;
                case Resource.Id.navigation_inbox:

                    intent = new Intent(this, typeof(Inbox));
                    StartActivity(intent);

                    return true;
                case Resource.Id.navigation_library:

                     intent = new Intent(this, typeof(Library));
                    StartActivity(intent);
                    return true;
            }
            return false;
        }
    }
}

