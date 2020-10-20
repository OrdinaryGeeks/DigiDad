using Android.App;
using Android.Content;
using Android.Content.PM;
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

    [Activity(MainLauncher = true)]
    class Login : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        Utils layoutUtils;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);


            SetSupportActionBar((Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar1));


        
            var metrics = Resources.DisplayMetrics;

            int height = metrics.HeightPixels;
            int width = metrics.WidthPixels;

            layoutUtils = new Utils(width, height);
            //Activity.WindowService..Sc
            SetContentView(Resource.Layout.login);


            LinearLayout title = (LinearLayout)FindViewById(Resource.Id.loginTitleLayout);
            EditText userId = (EditText)FindViewById(Resource.Id.loginUserId);
            EditText password = (EditText)FindViewById(Resource.Id.loginPassword);
            ConstraintLayout rememberMeRow = (ConstraintLayout)FindViewById(Resource.Id.loginRememberMeRow);
            Button signIn = (Button)FindViewById(Resource.Id.loginSignIn);
            TextView signInRow = (TextView)FindViewById(Resource.Id.loginSignInUsing);
            LinearLayout loginButtonRow = (LinearLayout)FindViewById(Resource.Id.loginButtonRow);
            LinearLayout signUpRow = (LinearLayout)FindViewById(Resource.Id.loginSignUpRow);
            layoutUtils.setHeightClasses(8);

            //title, userid, password, rememberme row, signin, login buttons row,sign in using row,  signup row
            layoutUtils.setHeight(0, .4);
            layoutUtils.setHeight(1, .6 / 9.0);
            layoutUtils.setHeight(2, .6 / 9.0);
            layoutUtils.setHeight(4, .6 / 9.0);
            layoutUtils.setHeight(6, .6 / 9.0);
            layoutUtils.setHeight(7, .6 / 9.0);
            layoutUtils.setHeight(3, .6 / 9.0);
            layoutUtils.setHeight(5, .6 / 9.0);

            viewSetDimensions(title, 0);
            viewSetDimensions(userId, 1);
            viewSetDimensions(password, 2);
            viewSetDimensions(rememberMeRow, 3);
            viewSetDimensions(signIn, 4);
            viewSetDimensions(signInRow, 5);
            viewSetDimensions(loginButtonRow, 6);
            viewSetDimensions(signUpRow, 7);





          

        signIn.Click += delegate {
                Intent intent;
        intent = new Intent(this, typeof(Home));
            StartActivity(intent);
        };


        }

        public void viewSetDimensions(View v, int heightIndex)
        {


            v.LayoutParameters.Height = layoutUtils.getHeightSize(heightIndex);
          
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