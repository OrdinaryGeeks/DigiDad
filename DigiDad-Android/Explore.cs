using Android.App;
using Android.Content;
using Android.Opengl;
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
    class Explore : 
        AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
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
            SetContentView(Resource.Layout.explore);


            BottomNavigationView navigationView = (BottomNavigationView)FindViewById(Resource.Id.navigation);
            navigationView.SetOnNavigationItemSelectedListener(this);



            ImageView cooking = (ImageView)FindViewById(Resource.Id.cookingExplore);

            cooking.Click += delegate
             {
                 TextView exploreTitleText = (TextView)FindViewById(Resource.Id.exploreTitleText);

                 exploreTitleText.Text = "Cooking";

                 LinearLayout exploreHome = (LinearLayout)FindViewById(Resource.Id.explore1);
                 LinearLayout exploreSecondary = (LinearLayout)FindViewById(Resource.Id.explore2);
                 GridLayout exploreGridLayout = (GridLayout)FindViewById(Resource.Id.exploreGridLayout);
                 exploreHome.Visibility = ViewStates.Gone;
                 exploreSecondary.Visibility = ViewStates.Visible;
                 exploreGridLayout.Visibility = ViewStates.Visible;

             };

        }


        public bool OnNavigationItemSelected(IMenuItem item)
        {

            Intent intent;
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:

                    intent = new Intent(this, typeof(Home));


                    StartActivity(intent);
                    return true;
                case Resource.Id.navigation_explore:

                    //intent = new Intent(this, typeof(Explore));


                  //  StartActivity(intent);
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