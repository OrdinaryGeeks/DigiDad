using Android.App;
using Android.Content;
using Android.Content.PM;
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

    [Activity(MainLauncher = true)]
    class Login : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
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
            SetContentView(Resource.Layout.login);


        Button signIn = (Button)FindViewById(Resource.Id.signIn);

        signIn.Click += delegate {
                Intent intent;
        intent = new Intent(this, typeof(Home));
            StartActivity(intent);
        };


        }


    public void SignIn(View v) //CALLBACK FUNCTION
        {
         
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

                    intent = new Intent(this, typeof(Explore));


                    StartActivity(intent);
                    return true;
                case Resource.Id.navigation_inbox:

                    intent = new Intent(this, typeof(Inbox));
                    StartActivity(intent);

                    return true;
                case Resource.Id.navigation_library:

                    // intent = new Intent(this, typeof(Library));
                    // StartActivity(intent);
                    return true;
            }
            return false;
        }
    }
}