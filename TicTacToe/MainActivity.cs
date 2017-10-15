using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace TicTacToe
{
	[Activity(Label = "TicTacToe", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle bundle)
		{


			base.OnCreate(bundle);
			try
			{
				SetContentView(Resource.Layout.Main);
			}
			catch (System.Exception e)
			{
				Log.Error("XXXXXXXXX", e.ToString());
			}
		}

	}
}

