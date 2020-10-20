using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;


namespace DigiDad_Android
{
    public class Config
    {

        public Config()
        {

            try
            {

                Task.Run(async () => await SecureStorage.SetAsync("digidad-ooowee", "mjYkn6xXg4mGoF5wm7Fdv6CObFB0HXRRn8VqhucjLNemeqyqLaGHTJYUiajMX2jWf5p+pjM4mFtGxrOxInkgSQ=="));
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }


        }
    }
}