using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TicTacToe
{
	public static class DrawColors
	{ 
		public static Color line_unPlayed = Color.DarkSeaGreen;
		public static Color BOARD_COLOR = Color.Rgb(9, 160, 219);
		public static Color P1_COLOR = Color.MediumPurple;
		public static Color P2_COLOR = Color.DarkOrange;
		public static Color TXT_COLOR = Color.Rgb(20, 190, 247);
		public static Color NEXT_TURN_COLOR = Color.WhiteSmoke;
		public static Color BUTTON_TWO = Color.LightSteelBlue;
		public static Color BUTTON_ONE = Color.LightSteelBlue;
		public static Color BUTTON_THREE = Color.LightSteelBlue;
		public static Color BUTTON_FIVE = Color.LightSteelBlue;
		public static Color BUTTON_FOUR = Color.LightCoral;
		public static Color BUTTON_BORDER = Color.Black;
		public static Color BUTTON_TEXT = Color.Black;
	}//, Color.LightBlue /*unplayed node*/, Color.Green /*p1*/, Color.Yellow/*p2*/, Color.Orange };/*line clor*//*unplayed node*/};
}