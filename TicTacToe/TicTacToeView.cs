using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views;
using Android.Content;
using Android.Util;
using Android.Graphics;
using Android.Widget;
using Android.Animation;
using Android.Views.Animations;
using Android.App;
using Android.OS;
using Android.Runtime;

namespace TicTacToe
{
	public class TicTacToeView : View
	{

		Context mContext;
		public bool Initialized = false;
		public bool HasMoved = false;
		//Important properties for the large bubble
		public int activeIndex = -1;
		public float activeX = 0;
		public float activeY = 0;
		public float activeRadius = 60;
		ValueAnimator animatorX;
		ValueAnimator animatorY;
		ValueAnimator animatorRadius;
		const int NUM_BUBBLES = 5;
		public int radius = 26;

		public int radius_big = 180;
		public const int VERTICES = 12;
		public const int ROWS = 4;
		public int GAME_TYPE = 0;
		public int NUM_GAMES = 1;
		public const int Y0offSet_w = 50;
		public double ANGLE = 2 * Math.PI / (double)VERTICES;
		public List<Pair> GameNodeXYs = new List<Pair>();

		public List<MyButton> ButtonList = new List<MyButton>();
		//		Color[] colors = new[] { Color.Red, Color.LightBlue, Color.Green, Color.Yellow, Color.Orange };
		Color[] colors = new[] { Color.DarkSeaGreen /*line clor*//*unplayed node*/, Color.LightBlue /*unplayed node*/, Color.Green/*p1*/, Color.Yellow/*p2*/, Color.Orange };

		public int ROW_SPACING { get { return (Width / 10) - 5; } } // = (Width / 10) - 5;


		public int Y0_w { get { return (Width / 2) + Y0offSet_w; } } // = (Width / 10) - 5;
		public int Y0_h { get { return (Height / 2); } } // = (Width / 10) - 5;
		public int X0 { get { return (Width / 2); } } // = (Width / 10) - 5;
		public int BUTTON_WIDTH { get { return Width / 3; } } // = (Width / 10) - 5;
		public int BUTTON_HEIGHT { get { return Height / 10; } } // = (Width / 10) - 5;

		public string[] names = { "Bob", "John", "Paul", "Wasi", "Mark" };

		#region Constructors


		public TicTacToeView(Context context) :
		base(context)
		{
			init(context);
		}
		public TicTacToeView(Context context, IAttributeSet attrs) :
		base(context, attrs)
		{
			init(context);
		}

		public TicTacToeView(Context context, IAttributeSet attrs, int defStyle) :
		base(context, attrs, defStyle)
		{
			init(context);
		}

		#endregion
		private void init(Context ctx)
		{

			//	rowSpacing = (Width / 10) - 5;
			//**
			mContext = ctx;

			animatorX = new ValueAnimator();
			animatorY = new ValueAnimator();
			animatorRadius = new ValueAnimator();
			animatorX.SetDuration(1000);
			animatorY.SetDuration(1000);
			animatorRadius.SetDuration(1000);
			animatorX.SetInterpolator(new DecelerateInterpolator());
			animatorY.SetInterpolator(new BounceInterpolator());

			animatorRadius.SetIntValues(new[] { radius, radius_big });
			animatorRadius.Update += (sender, e) =>
			{
				activeRadius = (float)e.Animation.AnimatedValue;
				Invalidate();
			};

			animatorX.Update += (sender, e) =>
			{
				activeX = (float)e.Animation.AnimatedValue;
				Invalidate();
			};
			animatorY.Update += (sender, e) =>
			{
				activeY = (float)e.Animation.AnimatedValue;
				Invalidate();
			};

		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			float centerScreenX = Width / 2.0f;
			float centerScreenY = Height / 2.0f;
			activeIndex = IsInsideGameNode(e.GetX(), e.GetY());
			if (activeIndex > -1)
			{
				if (!HasMoved)
				{
					HasMoved = true;
					MainActivity.CreateAndNormalizeGameNodes(activeIndex, GameNodeXYs);
				}
				Toast.MakeText(mContext, "Got index" + activeIndex, ToastLength.Short).Show();
				animatorX.SetFloatValues(new[] { (float)GameNodeXYs[activeIndex].First, centerScreenX });
				animatorY.SetFloatValues(new[] { (float)GameNodeXYs[activeIndex].Second, centerScreenY });
				animatorX.Start();
				animatorY.Start();
				animatorRadius.Start();
			}
			isInsideButton(e.GetX(), e.GetY());


			return false;
		}

		private void isInsideButton(float x, float y)
		{
			foreach (MyButton b in ButtonList)
			{
				b.CheckIfClicked(x, y);
			}
		}

		int IsInsideGameNode(float x, float y)
		{
			for (int i = 0; i < GameNodeXYs.Count; i++)
			{
				int centerX = (int)GameNodeXYs[i].First;
				int centerY = (int)GameNodeXYs[i].Second;
				if (System.Math.Pow(x - centerX, 2) + System.Math.Pow(y - centerY, 2) < System.Math.Pow(radius, 2))
				{
					return i;
				}
			}
			return -1;
		}



		void initPositions()
		{
			#region old

			//draw lines

			//int count = 0;
			//for (int i = 1; i <= VERTICES; i++)
			//{
			//	drawPaint.setStyle(Style.STROKE);
			//	float xLength = (int)(LINELENGTH * Math.cos(ANGLE * i));
			//	float yLength = (int)(LINELENGTH * Math.sin(ANGLE * i));
			//	canvas.drawLine(x0, y0, (x0 - xLength), (y0 - yLength), drawPaint);
			//	for (int j = 0; j < ROWS; j++)
			//	{

			//		drawPaint.setStyle(Style.FILL_AND_STROKE);
			//		xs[count] = (float)(x0 - ((LINELENGTH - rowSpacing * j) * Math.cos(ANGLE * i)));
			//		ys[count] = (float)(y0 - ((LINELENGTH - rowSpacing * j) * Math.sin(ANGLE * i)));
			//		count++;
			//	}
			//}
			/////set text size
			//drawPaint.setTextSize(27/*HEIGHT / 100 + 10*/);
			//drawPaint.setStrokeWidth(4);
			////        draw node numb
			//drawPaint.setColor(Color.WHITE);
			//drawPaint.setStyle(Style.FILL_AND_STROKE);
			////        if (win||numDraws == 10||numDraws==1) {
			//for (int i = 0; i < VERTICES; i++)
			//{
			//	for (int j = 0; j < ROWS; j++)
			//	{
			//		// draw vertices and player moves
			//		drawPaint.setStyle(Style.FILL_AND_STROKE);
			//		switch (gameNodes[j][i].player)
			//		{
			//			//AIp1
			//			case -1:
			//				drawPaint.setColor(P2_COLOR);
			//				canvas.drawCircle(gameNodes[j][i].xcoor, gameNodes[j][i].ycoor, MOVE_SIZE, drawPaint);
			//				break;
			//			case 0:
			//				drawPaint.setColor(BOARD_COLOR);
			//				canvas.drawCircle(gameNodes[j][i].xcoor, gameNodes[j][i].ycoor, NODE_SIZE, drawPaint);
			//				break;
			//			case 1:
			//				drawPaint.setColor(P1_COLOR);
			//				canvas.drawCircle(gameNodes[j][i].xcoor, gameNodes[j][i].ycoor, MOVE_SIZE, drawPaint);
			//				break;

			//		}
			//		drawPaint.setColor(Color.WHITE);
			//		canvas.drawText("" + gameNodes[j][i].number, gameNodes[j][i].getXcoor(), gameNodes[j][i].getYcoor(), drawPaint);
			//	}
			//}

			#endregion

			#region ButtonCreators NEW
			MyButton mb = new MyButton()
			{
				Text = "Exit",
				BColor = DrawColors.BUTTON_ONE,
				Rectangle = new RectF(0, Height - BUTTON_HEIGHT, BUTTON_WIDTH, Height)
			};
			mb.OnClicked += btnExit_OnClicked;
			ButtonList.Add(mb);

			/*
			 * 
			Left	0	Top	1874		Right	360		Bottom	1704	
			Left	0	Top	2044		Right	360		Bottom	1250	
					this.Width	1080	int
					this.Height	1704	int

			*/
			mb = new MyButton()
			{
				Text = "Start Game AUTO",
				BColor = DrawColors.BUTTON_FOUR,
				Rectangle = new RectF(0, (Height) - BUTTON_HEIGHT * 2, BUTTON_WIDTH, Height - BUTTON_HEIGHT),

			};
			mb.OnClicked += btnStartGameAUTO_OnClicked;

			ButtonList.Add(mb);

			#endregion
			#region ButtonPositions old
			//drawPaint.setColor(BUTTON_ONE);
			//drawPaint.setStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(0, top2, fourFifty, bottom2, drawPaint);
			//drawPaint.setColor(BUTTON_TEXT);
			//canvas.drawText("Game type 3 & Start Network", 50, top2 + buttonSize / 2, drawPaint);

			////type 2 button
			//right = fourFifty * 2;
			//left = fourFifty;
			//drawPaint.setColor(BUTTON_TWO);
			//drawPaint.setStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(left, top2, right, bottom2, drawPaint);
			//drawPaint.setColor(BUTTON_TEXT);
			//canvas.drawText("Game type 2 or 1", left + 50, top2 + buttonSize / 2, drawPaint);

			////button 5 display gamnes button

			//right = fourFifty * 2;
			//left = fourFifty;
			//drawPaint.setColor(BUTTON_FIVE);
			//drawPaint.setStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(left, top, right, bottom, drawPaint);
			//drawPaint.setColor(BUTTON_TEXT);
			//canvas.drawText("DisplayGames", left + 50, top + buttonSize / 2, drawPaint);


			////game type button timer 3
			//float rightgt = fourFifty * 3;
			//float leftgt = fourFifty * 2;
			//drawPaint.setColor(BUTTON_THREE);
			//drawPaint.setStyle(Style.FILL_AND_STROKE);
			//canvas.drawRect(leftgt, top2, rightgt, bottom2, drawPaint);
			//drawPaint.setColor(BUTTON_TEXT);
			//canvas.drawText("Timer", leftgt + 50, top2 + buttonSize / 2, drawPaint);



			#endregion
			Initialized = true;
			float LINELENGTH = ROW_SPACING + ROW_SPACING * ROWS;
			if (GameNodeXYs.Count == 0)
			{



				GameNodeXYs.Add(new Pair(X0, Y0_w));
				int spacing = Width / ROWS;
				int shift = spacing / 2;
				//these are columns in matrix
				for (int i = 0; i < VERTICES; i++)
				{
					//	float xLength = (int)(LINELENGTH * Math.cos(ANGLE * i));
					//float yLength = (int)(LINELENGTH * Math.sin(ANGLE * i));
					for (int j = 0; j < ROWS; j++)
					{
						int x = (int)(X0 - ((LINELENGTH - ROW_SPACING * j) * Math.Cos(ANGLE * i)));
						int y = (int)(Y0_w - ((LINELENGTH - ROW_SPACING * j) * Math.Sin(ANGLE * i)));
						GameNodeXYs.Add(new Pair(x, y));
					}

				}
			}
		}



		void drawSmallCircles(Canvas canvas)
		{
			if (!Initialized)
				initPositions();

			Drawer.DrawGameNodes(mContext, canvas, this);
			Drawer.DrawButtons(mContext, canvas, ButtonList);


			//Paint DrawButtonPaint = new Paint();
			//DrawButtonPaint.SetStyle(Paint.Style.FillAndStroke);

			//Paint DrawButtonText = new Paint() { Color = DrawColors.TXT_COLOR };
			//DrawButtonText.TextAlign = Paint.Align.Center;
			//// Get the screen's density scale
			////var scale = context.Resources.DisplayMetrics.Density;
			//// Convert the dps to pixels, based on density scale
			//foreach (var b in ButtonList)
			//{
			//	DrawButtonPaint.Color = b.BColor;
			//	canvas.DrawRoundRect(b.Rectangle, b.Rectangle.Width() / 2, b.Rectangle.Height() / 2, DrawButtonPaint);
			//	canvas.DrawRoundRect(b.Rectangle, b.Rectangle.Width() / 2, b.Rectangle.Height() / 2, DrawButtonPaint);
			//	DrawButtonText.TextSize = (int)(b.TextSize * scale);
			//	canvas.DrawText(b.Text, b.Rectangle.CenterX() - b.Rectangle.Width() / 4, b.Rectangle.Top + b.Rectangle.Height() / 4, DrawButtonText);
			//}
		}



		private void drawBigCircle(Canvas canvas)
		{
			//if (activeIndex > -1)
			//{
			//	var paintCircle = new Paint() { Color = colors[activeIndex] };
			//	canvas.DrawCircle(activeX, activeY, activeRadius, paintCircle);

			//	var paintText = new Paint() { Color = Color.Black };
			//	//  the screen's density scale
			//	var scale = mContext.Resources.DisplayMetrics.Density;
			//	// Convert the dps to pixels, based on density scale
			//	var textSizePx = (int)(20f * scale);
			//	var name = names[activeIndex];
			//	paintText.TextSize = textSizePx;
			//	paintText.TextAlign = Paint.Align.Center;
			//	canvas.DrawText(name, activeX, activeY + radius / 2, paintText);

			//}
		}

		protected override void OnDraw(Canvas canvas)
		{
			//this.Background= Color.
			drawSmallCircles(canvas);
			drawBigCircle(canvas);
		}

		#region buttonActionCalls

		public void btnExit_OnClicked(object sender, EventArgs e) => DelegatedActions.btnExit_OnClicked(sender, e);

		public void btnStartGameAUTO_OnClicked(object sender, EventArgs e) => DelegatedActions.btnStartGameAUTO_OnClicked(this);

		#endregion
	}

}
