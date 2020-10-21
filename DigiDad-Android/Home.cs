using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Constraints;
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
        Utils layoutUtils;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Intent intent;


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);


            SetSupportActionBar((Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar1));

            Window.SetStatusBarColor(new Android.Graphics.Color(76, 160, 240));
            

            // clear FLAG_TRANSLUCENT_STATUS flag:
         //   window.clearFlags(WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
          //  window.addFlags(WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS);

            // finally change the color
            //window.setStatusBarColor(ContextCompat.getColor(activity, R.color.my_statusbar_color));

            var metrics = Resources.DisplayMetrics;

            int height = metrics.HeightPixels;
            int width = metrics.WidthPixels;

            layoutUtils = new Utils(width, height);
            //Activity.WindowService..Sc
            SetContentView(Resource.Layout.home);

           BottomNavigationView navigationView = (BottomNavigationView)FindViewById(Resource.Id.navigation);
            navigationView.SetOnNavigationItemSelectedListener(this);

            ConstraintLayout titleAndIcon = (ConstraintLayout)FindViewById(Resource.Id.homeTitleAndIcons);
            HorizontalScrollView categorybar = (HorizontalScrollView)FindViewById(Resource.Id.homeCategorybar);
            HorizontalScrollView main = (HorizontalScrollView)FindViewById(Resource.Id.homeMain);
            ConstraintLayout justArrivedRow = (ConstraintLayout)FindViewById(Resource.Id.homeJustArrivedRow);
            HorizontalScrollView justArrivedThumbs = (HorizontalScrollView)FindViewById(Resource.Id.homeJustArrivedThumbsRow);
            ConstraintLayout trendingRow = (ConstraintLayout)FindViewById(Resource.Id.homeTrendingRow);
            HorizontalScrollView trendingThumbsRow = (HorizontalScrollView)FindViewById(Resource.Id.homeTrendingThumbsRow);
            LinearLayout mainLL = (LinearLayout)FindViewById(Resource.Id.homeMainLL);
            LinearLayout justArrivedLL = (LinearLayout)FindViewById(Resource.Id.homeJustArrivedRowLL);
            LinearLayout justArrivedThumbsLL = (LinearLayout)FindViewById(Resource.Id.homeJustArrivedThumbsRowLL);
            LinearLayout trendingLL = (LinearLayout)FindViewById(Resource.Id.homeTrendingRowLL);
            LinearLayout trendingThumbsLL = (LinearLayout)FindViewById(Resource.Id.homeTrendingThumbsRowLL);
            TextView justArrivedText = (TextView)FindViewById(Resource.Id.homeJustArrivedText);
            layoutUtils.setHeightClasses(7);
      // https://img.youtube.com/vi/<insert-youtube-video-id-here>/1.jpg
            layoutUtils.setHeight(0, .07);
            layoutUtils.setHeight(1, .07);
            layoutUtils.setHeight(2, .20);
            layoutUtils.setHeight(3, .03);
            layoutUtils.setHeight(4, .15);
            layoutUtils.setHeight(5, .03);
            layoutUtils.setHeight(6, .15);

            layoutUtils.setTopMargin(0, .02);
            layoutUtils.setTopMargin(1, .02);
            layoutUtils.setTopMargin(2, .02);
            layoutUtils.setTopMargin(3, .02);
            layoutUtils.setTopMargin(4, .01);
            layoutUtils.setTopMargin(5, .02);
            layoutUtils.setTopMargin(6, .01);

            layoutUtils.setViewDimensionsHeight(titleAndIcon, 0);
            layoutUtils.setViewDimensionsHeight(categorybar, 1);
            layoutUtils.setViewDimensionsHeight(main, 2);
            layoutUtils.setViewDimensionsHeight(justArrivedRow, 3);
            layoutUtils.setTextViewDimensions(justArrivedLL, 3);
          //  layoutUtils.setViewDimensionsHeight(justArrivedLL, 3);
            layoutUtils.setViewDimensionsHeight(justArrivedThumbs, 4);
            layoutUtils.setViewTopMargins(trendingRow, 5);
            //  layoutUtils.setViewDimensionsHeight(trendingRow, 5);
            layoutUtils.setViewDimensionsHeight(trendingThumbsRow, 6);

            layoutUtils.setViewDimensionsHeight(mainLL, 2);
         //   layoutUtils.setViewDimensionsHeight(justArrivedLL, 3);
            layoutUtils.setViewDimensionsHeight(justArrivedThumbsLL, 4);
          //  layoutUtils.setViewDimensionsHeight(trendingLL, 5);
            layoutUtils.setViewDimensionsHeight(trendingThumbsLL, 6);
               

            TextView[] topRowText = new TextView[5];

            ImageView[] topRow = new ImageView[4];


            topRow[0] = (ImageView) FindViewById(Resource.Id.homeCookingImage1);

            topRow[0].Click += delegate
            {

                intent = new Intent(this, typeof(Explore));

                intent.PutExtra("ActiveView", "Cooking");
                StartActivity(intent);
                return;
                

            };
            topRow[1] = (ImageView)FindViewById(Resource.Id.homeHomeworkImage1);
            topRow[1].Click += delegate
            {

                intent = new Intent(this, typeof(Explore));

                intent.PutExtra("ActiveView", "Homework");
                StartActivity(intent);
                return;


            };
            topRow[2] = (ImageView)FindViewById(Resource.Id.homeSwimmingImage1);
            topRow[2].Click += delegate
            {

                intent = new Intent(this, typeof(Explore));

                intent.PutExtra("ActiveView", "Swimming");
                StartActivity(intent);
                return;


            };
            topRow[3] = (ImageView)FindViewById(Resource.Id.homeDatingImage1);
            topRow[3].Click += delegate
            {

                intent = new Intent(this, typeof(Explore));

                intent.PutExtra("ActiveView", "Dating");
                StartActivity(intent);
                return;


            };
            foreach (View view in topRow)
            {

                layoutUtils.setViewDimensions(view, 2);
                
            }
            

            ImageView[] secondRow = new ImageView[5];

            secondRow[0] = (ImageView)FindViewById(Resource.Id.imageView6);
            secondRow[1] = (ImageView)FindViewById(Resource.Id.imageView7);
            secondRow[2] = (ImageView)FindViewById(Resource.Id.imageView8);
            secondRow[3] = (ImageView)FindViewById(Resource.Id.imageView9);
            secondRow[4] = (ImageView)FindViewById(Resource.Id.imageView10);

            foreach (View view in secondRow)
            {

                layoutUtils.setViewDimensions(view, 4);

            }


            ImageView[] thirdRow = new ImageView[4];

            thirdRow[0] = (ImageView)FindViewById(Resource.Id.imageView11);
            thirdRow[1] = (ImageView)FindViewById(Resource.Id.imageView12);
            thirdRow[2] = (ImageView)FindViewById(Resource.Id.imageView13);
            thirdRow[3] = (ImageView)FindViewById(Resource.Id.imageView14);

            foreach (View view in thirdRow)
            {

                layoutUtils.setViewDimensions(view, 6);

            }


            //  textMessage = FindViewById<TextView>(Resource.Id.message);
            //  BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);


            //navigation.SetOnNavigationItemSelectedListener(this);*/
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

