using Android.App;
using Android.OS;
using Android.Widget;
    
namespace UDVAndroidTestApp
{
    [Activity(Label = "@string/app_name")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
    }
}