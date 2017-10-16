using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TicTacToe
{
	public class MyButton
	{
		//public Pair LeftBottom { get; set; }
		//public Pair TopRight { get; set; }
		public RectF Rectangle { get; set; }
		public string Text { get; set; }

		public float TextSize
		{
			get
			{
				return 10f;
			}
		}
		public Color BColor { get; set; }


		public delegate void ClickActionEventHandler(Object sender, EventArgs e);

		public event ClickActionEventHandler OnClicked;

		internal void CheckIfClicked(float x, float y)
		{
			if ((x >= this.Rectangle.Left) && (x <= this.Rectangle.Right) && (y >= this.Rectangle.Top) && (y <= this.Rectangle.Bottom))
			{
				Log.Debug("CHECKIFBUTTONCLICKED", $"(x >= this.Rectangle.Left){(x >= this.Rectangle.Left)} (x <= this.Rectangle.Right){(x <= this.Rectangle.Right)} (y >= this.Rectangle.Top) {y >= this.Rectangle.Top}  (y <= this.Rectangle.Bottom) { (y <= this.Rectangle.Bottom)}");
				var handler = OnClicked;
				if (handler != null)
				{
					handler(this, new EventArgs());
				}
			}
		}
	}
}