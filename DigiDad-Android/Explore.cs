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
        Utils mainLayoutUtils;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);


            Window.SetStatusBarColor(new Android.Graphics.Color(76, 160, 240));


            // clear FLAG_TRANSLUCENT_STATUS flag:
           //Window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
           // Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            // finally change the color
          //  Window.setStatusBarColor(ContextCompat.getColor(activity, R.color.my_statusbar_color));

            var metrics = Resources.DisplayMetrics;

            int height = metrics.HeightPixels;
            int width = metrics.WidthPixels;

            mainLayoutUtils = new Utils(width, height);
            layoutUtils = new Utils(width, height);



            mainLayoutUtils.setHeightClasses(1);

            mainLayoutUtils.setHeight(0, .25);

            layoutUtils.setSingularWidth(.3);

   



            SetContentView(Resource.Layout.explore);



            TextView exploreTitleText = (TextView)FindViewById(Resource.Id.explore2TitleText);
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

            ThumbnailedView cookingImage = FindViewById<ThumbnailedView>(Resource.Id.cookingExplore);
          //  int[] location = new int[2];
           // cookingImage.GetLocationOnScreen(location);

           // cookingImage.setTextLocation
         //   ImageView cookingImage = (ImageView)FindViewById(Resource.Id.cookingExplore);
            ImageView homeworkImage = (ImageView)FindViewById(Resource.Id.homeworkExplore);
            ImageView swimmingImage = (ImageView)FindViewById(Resource.Id.swimmingExplore);
            ImageView datingImage = (ImageView)FindViewById(Resource.Id.datingExplore);




            Picasso.Get().Load("https://img.youtube.com/vi/pMAG1fWuK2Q/1.jpg").Into(FindViewById<ImageView>(Resource.Id.cookingExplore));
            Picasso.Get().Load("https://img.youtube.com/vi/VPNQQPjFsns/1.jpg").Into(FindViewById<ImageView>(Resource.Id.homeworkExplore));
            Picasso.Get().Load("https://img.youtube.com/vi/IlzFBJGSC7w/1.jpg").Into(FindViewById<ImageView>(Resource.Id.swimmingExplore));
            Picasso.Get().Load("https://img.youtube.com/vi/EvDdQmCNWUc/1.jpg").Into(FindViewById<ImageView>(Resource.Id.datingExplore));



            mainLayoutUtils.setImageViewDimensionsHeight(cookingImage, 0);
            mainLayoutUtils.setImageViewDimensionsHeight(homeworkImage, 0);
            mainLayoutUtils.setImageViewDimensionsHeight(swimmingImage, 0);
            mainLayoutUtils.setImageViewDimensionsHeight(datingImage, 0);


            prepareThumbnailedView(FindViewById<ThumbnailedView>(Resource.Id.cookingExplore), "Cooking");

            prepareThumbnailedView(FindViewById<ThumbnailedView>(Resource.Id.homeworkExplore), "Homework");

            prepareThumbnailedView(FindViewById<ThumbnailedView>(Resource.Id.swimmingExplore), "Swimming");

            prepareThumbnailedView(FindViewById<ThumbnailedView>(Resource.Id.datingExplore), "Dating");

            // mainLayoutUtils.setViewTextLocation(cookingImage);
            //  cookingImage.setText("Cooking");
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

        public void prepareThumbnailedView(ThumbnailedView tnv, string ThumbnailText)
        {

          

           // layoutUtils.setThumbnailTextLocation(tnv);

            tnv.setText(ThumbnailText);

        }


        public void setPrimaryVisible(string exploreTitleTextString)
        {
            TextView exploreTitleText = (TextView)FindViewById(Resource.Id.explore2TitleText);
            ImageView exploreBackArrow = (ImageView)FindViewById(Resource.Id.exploreBackArrow);
            LinearLayout exploreHome = (LinearLayout)FindViewById(Resource.Id.explore1);
            LinearLayout exploreSecondary = (LinearLayout)FindViewById(Resource.Id.explore2);
            GridLayout exploreGridLayout = (GridLayout)FindViewById(Resource.Id.exploreGridLayout);


            layoutUtils.setGoneViewMarginsToZero(exploreSecondary);
            layoutUtils.setGoneViewMarginsToZero(exploreGridLayout);
            layoutUtils.setGoneViewMarginsToZero(exploreBackArrow);
            exploreTitleText.Text = exploreTitleTextString;
           
            exploreSecondary.Visibility = ViewStates.Gone;
            exploreGridLayout.Visibility = ViewStates.Gone;
            exploreBackArrow.Visibility = ViewStates.Gone;
            exploreHome.Visibility = ViewStates.Visible;


            ActiveView = null;

        }

        public void prepareVideoThumbnailedView(VideoThumbnailedView vtnv)
        {

            vtnv.setText("7:05");

            layoutUtils.setVideoThumbnailTextLocation(vtnv);


        }
        public void setSecondaryVisible(string exploreTitleTextString)
        {

            TextView exploreTitleText = (TextView)FindViewById(Resource.Id.explore2TitleText);
            ImageView exploreBackArrow = (ImageView)FindViewById(Resource.Id.exploreBackArrow);
            LinearLayout exploreHome = (LinearLayout)FindViewById(Resource.Id.explore1);
            LinearLayout exploreSecondary = (LinearLayout)FindViewById(Resource.Id.explore2);
            GridLayout exploreGridLayout = (GridLayout)FindViewById(Resource.Id.exploreGridLayout);

            exploreTitleText.Text = exploreTitleTextString;
            exploreHome.Visibility = ViewStates.Gone;
            exploreSecondary.Visibility = ViewStates.Visible;
            exploreGridLayout.Visibility = ViewStates.Visible;
            exploreBackArrow.Visibility = ViewStates.Visible;


            VideoThumbnailedView grid1 = FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage1);
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage1));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage2));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage3));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage4));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage5));
            layoutUtils.setGalleryItemViewDimensions(FindViewById(Resource.Id.exploreGridImage6));

            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage1));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage2));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage3));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage4));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage5));

            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage6));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage7));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage8));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage9));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage10));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage11));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage12));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage13));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage14));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage15));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage16));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage17));
            prepareVideoThumbnailedView(FindViewById<VideoThumbnailedView>(Resource.Id.exploreGridImage18));
            //   grid1.setText("7:05");

            //  layoutUtils.setVideoThumbnailTextLocation(grid1);


            Picasso.Get().Load("https://img.youtube.com/vi/FTociictyyE/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage1));
            Picasso.Get().Load("https://img.youtube.com/vi/RFZ_d5CGDJg/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage2));
            Picasso.Get().Load("https://img.youtube.com/vi/NdAganj2Gfo/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage3));
            Picasso.Get().Load("https://img.youtube.com/vi/yLj2vrVh4j0/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage4));
            Picasso.Get().Load("https://img.youtube.com/vi/Pb9C0poeDq0/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage5));
            Picasso.Get().Load("https://img.youtube.com/vi/ex1iFyfLUTM/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage6));

            Picasso.Get().Load("https://img.youtube.com/vi/FTociictyyE/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage7));
            Picasso.Get().Load("https://img.youtube.com/vi/RFZ_d5CGDJg/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage8));
            Picasso.Get().Load("https://img.youtube.com/vi/NdAganj2Gfo/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage9));
            Picasso.Get().Load("https://img.youtube.com/vi/yLj2vrVh4j0/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage10));
            Picasso.Get().Load("https://img.youtube.com/vi/Pb9C0poeDq0/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage11));
            Picasso.Get().Load("https://img.youtube.com/vi/ex1iFyfLUTM/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage12));

            Picasso.Get().Load("https://img.youtube.com/vi/FTociictyyE/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage13));
            Picasso.Get().Load("https://img.youtube.com/vi/RFZ_d5CGDJg/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage14));
            Picasso.Get().Load("https://img.youtube.com/vi/NdAganj2Gfo/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage15));
            Picasso.Get().Load("https://img.youtube.com/vi/yLj2vrVh4j0/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage16));
            Picasso.Get().Load("https://img.youtube.com/vi/Pb9C0poeDq0/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage17));
            Picasso.Get().Load("https://img.youtube.com/vi/ex1iFyfLUTM/1.jpg").Into(FindViewById<ImageView >(Resource.Id.exploreGridImage18));





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