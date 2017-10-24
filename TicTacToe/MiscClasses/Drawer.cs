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
	public static class Drawer
	{
		public static void DrawButtons(Context context, Canvas canvas ,List<MyButton> ButtonList)
		{
			Paint DrawButtonPaint = new Paint();

			Paint DrawButtonText = new Paint() { Color = DrawColors.BUTTON_TEXT };
			DrawButtonText.TextAlign = Paint.Align.Center;
			// Get the screen's density scale
			var scale = context.Resources.DisplayMetrics.Density;
			// Convert the dps to pixels, based on density scale
			//draw button
			foreach (var b in ButtonList)
			{
				DrawButtonPaint.SetStyle(Paint.Style.Fill);
				//DrawButtonPaint.SetShadowLayer(b.Rectangle.Width()/2,10,10,Color.DarkSlateBlue);
				DrawButtonPaint.Color = b.BColor;
				//canvas.DrawRoundRect(b.Rectangle, b.Rectangle.Width()/2, b.Rectangle.Height()/2,DrawButtonPaint);
				canvas.DrawRect(b.Rectangle,  DrawButtonPaint);

				
				//DrawButtonPaint.ClearShadowLayer();
				DrawButtonPaint.SetStyle(Paint.Style.Stroke);
				DrawButtonPaint.Color = DrawColors.BUTTON_BORDER;
				canvas.DrawRect(b.Rectangle, DrawButtonPaint);

				DrawButtonText.TextSize = (int)(b.TextSize * scale);
				canvas.DrawText(b.Text, b.Rectangle.CenterX() , b.Rectangle.CenterY() , DrawButtonText);
			}
			//draw border
			foreach (var b in ButtonList)
			{
				DrawButtonPaint.SetStyle(Paint.Style.Stroke);
				DrawButtonPaint.Color = DrawColors.BUTTON_BORDER;
				canvas.DrawRect(b.Rectangle, DrawButtonPaint);
			}
		}
		public static void DrawButtons(Canvas canvas, int X0, int Y0, int BUTTON_SIZE, int WIDTH_OVER_3)
		{


			#region orig

			//Paint DrawPaint = new Paint();
			//DrawPaint.StrokeWidth = (4);
			//float top, bottom, right, left, top2, bottom2;
			////wingmae button
			//top = Y0 * 2 + BUTTON_SIZE * 2;
			//bottom = Y0 * 2 + BUTTON_SIZE * 3;
			////new game button
			//top2 = Y0 * 2 + BUTTON_SIZE;
			//bottom2 = Y0 * 2 + BUTTON_SIZE * 2;

			//DrawPaint.TextSize = (30/*HEIGHT / 100 + 10*/);
			////start network button  buttone 1
			//DrawPaint.Color = DrawColors.BUTTON_ONE;
			//DrawPaint.SetStyle(Paint.Style.FillAndStroke);
			//DrawPaint.Color = DrawColors.BUTTON_TEXT;
			//canvas.DrawText("Game type 3 & Start Network", 50, top2 + BUTTON_SIZE / 2, DrawPaint);

			////type 2 button
			//right = WIDTH_OVER_3 * 2;
			//left = WIDTH_OVER_3;
			//DrawPaint.Color = DrawColors.BUTTON_TWO;
			//DrawPaint.SetStyle(Paint.Style.FillAndStroke);
			//canvas.DrawRect(left, top2, right, bottom2, DrawPaint);
			//DrawPaint.Color = DrawColors.BUTTON_TEXT;
			//canvas.DrawText("Game type 2 or 1", left + 50, top2 + BUTTON_SIZE / 2, DrawPaint);

			////button 5 display gamnes button

			//right = WIDTH_OVER_3 * 2;
			//left = WIDTH_OVER_3;
			//DrawPaint.Color = DrawColors.BUTTON_FIVE;
			//DrawPaint.SetStyle(Paint.Style.FillAndStroke);
			//canvas.DrawRect(left, top, right, bottom, DrawPaint);
			//DrawPaint.Color = DrawColors.BUTTON_TEXT;
			//canvas.DrawText("DisplayGames", left + 50, top + BUTTON_SIZE / 2, DrawPaint);


			////game type button timer 3
			//float rightgt = WIDTH_OVER_3 * 3;
			//float leftgt = WIDTH_OVER_3 * 2;
			//DrawPaint.Color = DrawColors.BUTTON_THREE;
			//DrawPaint.SetStyle(Paint.Style.FillAndStroke);
			//canvas.DrawRect(leftgt, top2, rightgt, bottom2, DrawPaint);
			//DrawPaint.Color = DrawColors.BUTTON_TEXT;
			//canvas.DrawText("Timer", leftgt + 50, top2 + BUTTON_SIZE / 2, DrawPaint);

			////win game button 4
			//DrawPaint.Color = DrawColors.BUTTON_FOUR;
			//DrawPaint.SetStyle(Paint.Style.FillAndStroke);
			//canvas.DrawRect(0, top, WIDTH_OVER_3, bottom, DrawPaint);
			//DrawPaint.Color = DrawColors.BUTTON_TEXT;
			//canvas.DrawText("NUM_GAMES/Exit", 50, top + BUTTON_SIZE / 2, DrawPaint);

			#endregion



			//float top, bottom, right, left, top2, bottom2;
			////wingmae button
			//top = y0 * 2 + buttonSize * 2;
			//bottom = y0 * 2 + buttonSize * 3;
			////new game button
			//top2 = y0 * 2 + buttonSize;
			//bottom2 = y0 * 2 + buttonSize * 2;

			//DrawPaint.SetTextSize(30/*HEIGHT / 100 + 10*/);
			////start network button  buttone 1
			//DrawPaint.SetColor(BUTTON_ONE);
			//DrawPaint.SetStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(0, top2, fourFifty, bottom2, DrawPaint);
			//DrawPaint.SetColor(BUTTON_TEXT);
			//canvas.drawText("Game type 3 & Start Network", 50, top2 + buttonSize / 2, DrawPaint);

			////type 2 button
			//right = fourFifty * 2;
			//left = fourFifty;
			//DrawPaint.SetColor(BUTTON_TWO);
			//DrawPaint.SetStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(left, top2, right, bottom2, DrawPaint);
			//DrawPaint.SetColor(BUTTON_TEXT);
			//canvas.drawText("Game type 2 or 1", left + 50, top2 + buttonSize / 2, DrawPaint);

			////button 5 display gamnes button

			//right = fourFifty * 2;
			//left = fourFifty;
			//DrawPaint.SetColor(BUTTON_FIVE);
			//DrawPaint.SetStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(left, top, right, bottom, DrawPaint);
			//DrawPaint.SetColor(BUTTON_TEXT);
			//canvas.drawText("DisplayGames", left + 50, top + buttonSize / 2, DrawPaint);


			////game type button timer 3
			//float rightgt = fourFifty * 3;
			//float leftgt = fourFifty * 2;
			//DrawPaint.SetColor(BUTTON_THREE);
			//DrawPaint.SetStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(leftgt, top2, rightgt, bottom2, DrawPaint);
			//DrawPaint.SetColor(BUTTON_TEXT);
			//canvas.drawText("Timer", leftgt + 50, top2 + buttonSize / 2, DrawPaint);

			////win game button 4
			//DrawPaint.SetColor(BUTTON_FOUR);
			//DrawPaint.SetStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(0, top, fourFifty, bottom, DrawPaint);
			//DrawPaint.SetColor(BUTTON_TEXT);
			//canvas.drawText("NUM_GAMES/Exit", 50, top + buttonSize / 2, DrawPaint);


			/////draw text
			//DrawPaint.SetColor(TXT_COLOR);
			//DrawPaint.SetTextSize(40);
			//if (txt.length() > 60)
			//{
			//	canvas.drawText(txt.subSequence(0, (txt.length()) / 2).toString(), 40, top - (buttonSize * 2) + buttonSize / 2, DrawPaint);
			//	canvas.drawText(txt.subSequence((txt.length()) / 2, txt.length()).toString(), 43, top - (buttonSize * 2) + buttonSize / 2 + DrawPaint.getTextSize() + 5, DrawPaint);
			//}
			//else canvas.drawText(txt, 50, top - (buttonSize * 2) + buttonSize / 2, DrawPaint);

		}

		internal static void DrawGameNodes(Context mContext, Canvas canvas, TicTacToeView ticTacToeView)
		{

			var drawPaint = new Paint() { Color = DrawColors.line_unPlayed };
			drawPaint.SetStyle(Paint.Style.Stroke);
			drawPaint.StrokeWidth=5;
			
			for (int i = 1; i <= TicTacToeView.ROWS; i++)
			{
				canvas.DrawCircle(ticTacToeView.Width / 2, ticTacToeView.Y0_w, ticTacToeView.ROW_SPACING + ticTacToeView.ROW_SPACING * i, drawPaint);
			}


			var paintText = new Paint() { Color = Color.Black };
			// Get the screen's density scale
			var scale = mContext.Resources.DisplayMetrics.Density;
			// Convert the dps to pixels, based on density scale
			var textSizePx = (int)(10f * scale);
			paintText.TextSize = textSizePx;
			paintText.TextAlign = Paint.Align.Center;
			//}ticTacToeView.
			foreach (Pair p in ticTacToeView.GameNodeXYs)// .ActiveGameNodesDictionary)
			{
				var paintCircle = new Paint() { Color = DrawColors.line_unPlayed };
				int x = (int)p.First;
				int y = (int)p.Second;
				canvas.DrawCircle(x, y, ticTacToeView.radius, paintCircle);
				if (ticTacToeView.HasMoved)
				{
					paintText.Color = Color.Yellow;
					canvas.DrawText($"{ticTacToeView.GameNodeXYs.IndexOf(p)}|{MainActivity.ActiveGameNodesDictionary[p].number}", x, y + ticTacToeView.radius / 2, paintText);
				}
				else
				{
					canvas.DrawText("" + ticTacToeView.GameNodeXYs.IndexOf(p), x, y + ticTacToeView.radius / 2, paintText);
				}

			}
			/*foreach (Pair p in GameNodeXYs)
			{
				var paintCircle = new Paint() { Color = DrawColors.line_unPlayed };
				int x = (int)p.First;
				int y = (int)p.Second;
				canvas.DrawCircle(x, y, radius, paintCircle);
				if (HasMoved)
				{
					paintText.Color = Color.Yellow;
					canvas.DrawText($"{GameNodeXYs.IndexOf(p)}|{MainActivity.ActiveGameNodesDictionary[p].number}", x, y + radius / 2, paintText);
				}
				else
				{
					canvas.DrawText("" + GameNodeXYs.IndexOf(p), x, y + radius / 2, paintText);
				}
			}*/
		}
	}
}