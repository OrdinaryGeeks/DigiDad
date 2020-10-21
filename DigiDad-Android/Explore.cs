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

using Square.Picasso;


namespace DigiDad_Android
{

    [Activity]
    class Explore : 
        AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        String? ActiveView;
        Utils layoutUtils;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Window.SetStatusBarColor(new Android.Graphics.Color(76, 160, 240));

            SetSupportActionBar((Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar1));
            var metrics = Resources.DisplayMetrics;

            int height = metrics.HeightPixels;
            int width = metrics.WidthPixels;

            layoutUtils = new Utils(width, height);



            layoutUtils.setSingularWidth(.3);

   



            SetContentView(Resource.Layout.explore);


            TextView exploreTitleText = (TextView)FindViewById(Resource.Id.exploreTitleText);
            ImageView exploreBackArrow = (ImageView)FindViewById(Resource.Id.exploreBackArrow);

            BottomNavigationView navigationView = (BottomNavigationView)FindViewById(Resource.Id.navigation);

            navigationView.SelectedItemId = Resource.Id.navigation_explore;
            navigationView.SetOnNavigationItemSelectedListener(this);

            String? ActiveView = Intent.GetStringExtra("ActiveView");

            
            if (!String.IsNullOrEmpty(ActiveView))
            {


                if(ActiveView == "Cooking")

                {


                    setSecondaryVisible("Cooking");
                  
                }
                if(ActiveView == "Homework")
                {

                    

                   setSecondaryVisible("Homework");
                }
                if(ActiveView == "Dating")
                {
                    setSecondaryVisible("Dating");
                }
               
                if (ActiveView == "Swimming")
                {

                    setSecondaryVisible("Swimming");

                }
            }


            ImageView cookingImage = (ImageView)FindViewById(Resource.Id.cookingExplore);
            ImageView homeworkImage = (ImageView)FindViewById(Resource.Id.homeworkExplore);
            ImageView swimmingImage = (ImageView)FindViewById(Resource.Id.swimmingExplore);
            ImageView datingImage = (ImageView)FindViewById(Resource.Id.datingExplore);
            cookingImage.Click += delegate
             {

                 setSecondaryVisible("Cooking");

             };
            homeworkImage.Click += delegate
            {

                setSecondaryVisible("Homework");

            };
            swimmingImage.Click += delegate
            {

                setSecondaryVisible("Swimming");

            };
            datingImage.Click += delegate
            {

                setSecondaryVisible("Dating");

            };


        }

        public void setPrimaryVisible(string exploreTitleTextString)
        {
            TextView exploreTitleText = (TextView)FindViewById(Resource.Id.exploreTitleText);
            ImageView exploreBackArrow = (ImageView)FindViewById(Resource.Id.exploreBackArrow);
            LinearLayout exploreHome = (LinearLayout)FindViewById(Resource.Id.explore1);
            LinearLayout exploreSecondary = (LinearLayout)FindViewById(Resource.Id.explore2);
            GridLayout exploreGridLayout = (GridLayout)FindViewById(Resource.Id.exploreGridLayout);

            exploreTitleText.Text = exploreTitleTextString;
            exploreHome.Visibility = ViewStates.Visible;
            exploreSecondary.Visibility = ViewStates.Gone;
            exploreGridLayout.Visibility = ViewStates.Gone;
            exploreBackArrow.Visibility = ViewStates.Gone;
            ActiveView = null;

        }
        public void setSecondaryVisible(string exploreTitleTextString)
        {

            TextView exploreTitleText = (TextView)FindViewById(Resource.Id.exploreTitleText);
            ImageView exploreBackArrow = (ImageView)FindViewById(Resource.Id.exploreBackArrow);
            LinearLayout exploreHome = (LinearLayout)FindViewById(Resource.Id.explore1);
            LinearLayout exploreSecondary = (LinearLayout)FindViewById(Resource.Id.explore2);
            GridLayout exploreGridLayout = (GridLayout)FindViewById(Resource.Id.exploreGridLayout);

            exploreTitleText.Text = exploreTitleTextString;
            exploreHome.Visibility = ViewStates.Gone;
            exploreSecondary.Visibility = ViewStates.Visible;
            exploreGridLayout.Visibility = ViewStates.Visible;
            exploreBackArrow.Visibility = ViewStates.Visible;

            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage1));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage2));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage3));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage4));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage5));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage6));

            Picasso.Get().Load("https://img.youtube.com/vi/FTociictyyE/1.jpg").Into(FindViewById<ImageView>(Resource.Id.exploreGridImage1));
            Picasso.Get().Load("https://img.youtube.com/vi/RFZ_d5CGDJg/1.jpg").Into(FindViewById<ImageView>(Resource.Id.exploreGridImage2));
            Picasso.Get().Load("https://img.youtube.com/vi/NdAganj2Gfo/1.jpg").Into(FindViewById<ImageView>(Resource.Id.exploreGridImage3));
            Picasso.Get().Load("https://img.youtube.com/vi/yLj2vrVh4j0/1.jpg").Into(FindViewById<ImageView>(Resource.Id.exploreGridImage4));
            Picasso.Get().Load("https://img.youtube.com/vi/Pb9C0poeDq0/1.jpg").Into(FindViewById<ImageView>(Resource.Id.exploreGridImage5));
            Picasso.Get().Load("https://img.youtube.com/vi/ex1iFyfLUTM/1.jpg").Into(FindViewById<ImageView>(Resource.Id.exploreGridImage6));





            exploreBackArrow.Click += delegate {
                setPrimaryVisible("DDAT-APP!");
            };
            exploreTitleText.Click += delegate
            {
                setPrimaryVisible("DDAT-APP!");

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