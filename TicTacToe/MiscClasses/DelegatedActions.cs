using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TicTacToe
{
	class DelegatedActions
	{
		public static void btnExit_OnClicked(object sender, EventArgs e)
		{
			Log.Debug("BUTTONCLICKEDEVENT", $"btnExit_OnClicked");
			System.Environment.Exit(0);
		}
		public static void btnStartGameAUTO_OnClicked(TicTacToeView t)
		{
			Log.Debug("BUTTONCLICKEDEVENT", $"btnStartGameAUTO_OnClicked");
	
			t.GAME_TYPE = 3;
			//if (!networkStart)
			//{
			//	AIp1 = new Network(1);
			//	//            AIp0 = new Network(0);
			//	try
			//	{
			//		networkStart = true;
			//		AIp1.initHiddenWeights(this.getApplicationContext());
			//		//                AIp0.initHiddenWeights(this.getApplicationContext());


			//	}
			//	catch (Exception e1)
			//	{
			//		Log.i(TAG, e1.getLocalizedMessage() + e1.getCause() + e1.getMessage());
			//	}
			//}
			//Toast.MakeText(this, "Game type 3, POSTED|  Numgames: " + NUM_GAMES, Toast.LENGTH_SHORT).show();
			Toast.MakeText(t.Context, "Game type 3, POSTED|  Numgames: " + t.NUM_GAMES, ToastLength.Short).Show();
			//myThread = new Thread(r);
			////  myThread.setPriority(Thread.MAX_PRIORITY);
			//myThread.start();
			//return true;
		}
	}
}