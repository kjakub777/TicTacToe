using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using System.Collections.Generic;
using System;

namespace TicTacToe
{
	[Activity(Label = "TicTacToe", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		public static TicTacToeView ticTacToeView = null;
		public static List<Node> ActiveGameNodesList = null;
		public static Dictionary<Pair, Node> ActiveGameNodesDictionary = null;
		protected override void OnCreate(Bundle bundle)
		{

			base.OnCreate(bundle);
			try
			{
				ticTacToeView = FindViewById<TicTacToeView>(Resource.Id.awesomeview_main);
				SetContentView(Resource.Layout.Main);
			}
			catch (System.Exception e)
			{
				Log.Error("XXXXXXXXX", e.ToString());
			}
			//ticTacToeView

		}
		public static void CreateAndNormalizeGameNodes(int CurrentActiveIndex, List<Pair> GameNodeXYs)
		{
			ActiveGameNodesList = new List<Node>();
			ActiveGameNodesDictionary = new Dictionary<Pair, Node>();
			//FindColumnOfFirstMove
			int Column = (int)Math.Ceiling(Convert.ToDouble(CurrentActiveIndex) / Convert.ToDouble(TicTacToeView.ROWS));
			int InRow = CurrentActiveIndex % TicTacToeView.ROWS == 0 ? 4 : CurrentActiveIndex % TicTacToeView.ROWS;

			int StartIndex = CurrentActiveIndex - InRow + 1;

			//add bias Node
			Node bias = new Node()
			{
				number = 0,
				player = 0,
				row = 0,
				col = 0,
				value = -1,
				XY = GameNodeXYs[0]
			};
			ActiveGameNodesList.Add(bias);
			ActiveGameNodesDictionary.Add(GameNodeXYs[0], bias);
			int count = 0;
			for (int i = Column; i < TicTacToeView.VERTICES + Column; i++)
			{
				for (int j = 1; j < TicTacToeView.ROWS + 1; j++)
				{
					int indexOfCurrentPair;
					if ((StartIndex + count) <= (TicTacToeView.ROWS * TicTacToeView.VERTICES))
					{
						indexOfCurrentPair = (StartIndex + count);
					}
					else
					{
						indexOfCurrentPair = (StartIndex + count) % ((TicTacToeView.ROWS * TicTacToeView.VERTICES) + 1) + 1;
					}
					count++;
					Node newNode = new Node()
					{
						number = count,
						player = 0,
						value = 0,
						row = j,
						col = i - Column + 1,
						XY = GameNodeXYs[indexOfCurrentPair]
					};
					ActiveGameNodesList.Add(newNode);
					ActiveGameNodesDictionary.Add(GameNodeXYs[indexOfCurrentPair], newNode);

				}
			}
		}
		
		//private static double FindColumnOfMove(int activeIndex)
		//{
		//	/*
		//	1   5   9   13  17  21  25  29  33  37  41  45
		//	2   6   10  14  18  22  26  30  34  38  42  46
		//	3   7   11  15  19  23  27  31  35  39  43  47
		//	4   8   12  16  20  24  28  32  36  40  44  48

		//	.3	.6
		//	*/

		//	return Math.Ceiling(Convert.ToDouble(activeIndex) /Convert.ToDouble(TicTacToeView.ROWS));

		//}
	}
}

