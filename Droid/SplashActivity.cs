using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace PuzzlersJordan.Droid
{
	[Activity(Label = "Puzzlers Jordan", Icon = "@drawable/icon", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			this.StartActivity(typeof(MainActivity));
		}

	}
}