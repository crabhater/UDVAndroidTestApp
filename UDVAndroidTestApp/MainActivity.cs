using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
    
namespace UDVAndroidTestApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);

            SetContentView(Resource.Layout.activity_main);
        }
    }
}