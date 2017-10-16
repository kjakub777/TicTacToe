using Android.Util;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToe {
	/**
	 * Created by kj on 8/18/15.
	 */
	//[Serializable]
	public class Node
	{
		static String TAG = "NODE";
		public Pair XY { get; set; }
		//Weight weights[];
		public static int numLines = 7, numlinefeats = 8;
		private bool print = false;

		//  public enum lineType {EMPTY, F1, F2, F3, E1, E2, E3, MIX}


		//   public enum line {A1, A2, A3, A4, SL, SR, R}

		public int[,] FEATURES { get; set; }//	FEATURES = new int[numLines, numlinefeats];
		public float value = 0;
		public double featureVal = 0;
		public int row;
		public int col;
		public int number;
		public int player = 0;
		public bool A = false, R = false, SR = false, SL;//= false, A1 = false, R1 = false, SR1 = false, SL1 = false;
		public List<Node> neighbors;

		public Node()
		{
			this.player = 0;
			this.row = 0;
			this.col = 0;
			this.number = 0;
			XY = new Pair(0, 0);
			// starts out with empty list of neighbors
			neighbors = new List<Node>();
		}

		public Node(int row, int vert, int number, float xcoor, float ycoor)
		{

			this.player = 0;
			this.row = row;
			this.col = vert;
			this.number = number;
			XY = new Pair(0, 0);

			// starts out with empty list of neighbors
			neighbors = new List<Node>();

		}

		public void addNeighbor(Node n)
		{
			neighbors.Add(n);
		}


		//    
		//    protected Object clone() throws CloneNotSupportedException {
		//        Node nn=new Node();
		//        nn.number = this.number;
		//        nn.player = this.player;
		//        nn.A = this.A;
		//        nn.R = this.R;
		//        nn.SR = this.SR;
		//        nn.SL = this.SL;
		//        nn.vert = this.vert;
		//        nn.value = this.value;
		//        nn.row = this.row;
		//        nn.xcoor = this.xcoor;
		//        nn.ycoor = this.ycoor;
		//        return nn;
		//    }

		public Node cloneNode()
		{
			Node nn = new Node();
			nn.number = this.number;
			nn.player = this.player;//
			nn.A = this.A;
			nn.R = this.R;
			nn.SR = this.SR;
			nn.SL = this.SL;
			nn.col = this.col;
			nn.value = this.value;
			nn.row = this.row;
			nn.XY = this.XY;
			return nn;
		}

		public string hashCode()
		{
			return MD5HashGenerator.GenerateKey(ToString());
		}



		public bool equals(Object o)
		{
			return base.Equals(o);
		}

		public double getHValue()
		{
			if (player == -1)
			{
				return getEdgesValue() == 0 ? 1 : getEdgesValue() * 1;
			}
			else if (player == 1)
			{
				return getEdgesValue() == 0 ? .5 : getEdgesValue() * .5;
			}
			return 0;
		}

		//    public double getHValue() {
		//        if (player == -1) {
		//            return getEdgesValue() == 0 ? 1 : getEdgesValue() * 1;
		//        } else if (player == 1) {
		//            return getEdgesValue() == 0 ? .5 : getEdgesValue() * .5;
		//        }
		//        return 0;
		//    }

		public double getValue(Node[,] gs)
		{
			//        featureVal = 0;
			//        //determinesFeatures(this, gs);
			//        return featureVal + getValue();
			return player;
		}

		public double getValue()
		{
			featureVal = 0;
			foreach (Node neigh in neighbors)
			{
				if (player == neigh.player)
				{
					int diff = Math.Abs(number - neigh.number);
					//determine edge type
					if (diff == 1)
					{
						double t = (1 + getR(neigh));
						featureVal = t > featureVal ? t : featureVal; //current.SL = current.neighbors.get(n).SL = edge = true;
					}
					if (diff == 45 || diff == 3)
					{
						double t = (1 + getSR(neigh));
						featureVal = t > featureVal ? t : featureVal; //current.SL = current.neighbors.get(n).SL = edge = true;
					}
					if (diff == 44 || diff == 4)
					{
						double t = (1 + getA(neigh));
						featureVal = t > featureVal ? t : featureVal; //current.SL = current.neighbors.get(n).SL = edge = true;
					}
					if (diff == 43 || diff == 5)
					{
						double t = (1 + getSL(neigh));
						featureVal = t > featureVal ? t : featureVal; //current.SL = current.neighbors.get(n).SL = edge = true;
						;

					}
				}
			}
			//        if (player == 1) {
			//            return getEdgesValue() == 0 ? 1 : getEdgesValue() * 1;
			//        } else if (player == -1) {
			//            return getEdgesValue() == 0 ? -.5 : getEdgesValue() * .25;
			//        }
			return featureVal + getHValue();

		}

		private int getR(Node current)
		{
			foreach (Node neigh in current.neighbors)
			{
				if (neigh.R && neigh.player == player)
				{
					return 1 + getR(neigh);
				}
				else return 0;
			}
			return 0;
		}

		private int getA(Node current)
		{
			foreach (Node neigh in current.neighbors)
			{
				if (neigh.A && neigh.player == player)
				{
					return 1 + getA(neigh);
				}
				else return 0;
			}
			return 0;
		}

		private int getSR(Node current)
		{
			foreach (Node neigh in current.neighbors)
			{
				if (neigh.SR && neigh.player == player)
				{
					return 1 + getSR(neigh);
				}
				else return 0;
			}
			return 0;
		}

		private int getSL(Node current)
		{
			foreach (Node neigh in current.neighbors)
			{
				if (neigh.SL && neigh.player == player)
				{
					return 1 + getSL(neigh);
				}
				else return 0;
			}
			return 0;
		}

		public int right(int cur, int Length)
		{
			int ret = cur;
			for (int i = 0; i < Length; i++)
				ret = ret == 12 - 1 ? 0 : ret + 1;
			return ret;
		}

		public int left(int cur, int Length)
		{
			int ret = cur;
			for (int i = 0; i < Length; i++)
				ret = ret == 0 ? 12 - 1 : ret - 1;
			return ret;
		}

		public void determinesFeatures(Node current, Node[,] gamesNodes)
		{
			// LINE_INPUTS = new int[numLines,numlinefeats];
			int COUNT = 2;
			//check Arcs        ;
			int row = current.row, col = current.col;
			int start = col;
			int[] vals = new int[4];
			//        for (int bottom = 0; bottom < rows; bottom++) {
			for (int a = 0; a < 4; a++)
			{
				int c1 = 0;
				col = left(current.col, a);
				while (c1 < 4)
				{
					vals[c1] = gamesNodes[row, col].player;
					if (print)
						Log.Debug(TAG, "A count " + COUNT + " btm " + row + " col " + col + " # " + current.number + " row " + current.row + " vert " + current.col + " #CUR" + gamesNodes[row, col].number);
					c1++;
					col = right(col, 1);
				}
				decideLineType(current, vals, COUNT);
				start = left(start, 1);
				//            }
			}//endarc
			 //radial
			 //    row = 0;
			col = current.col;
			start = col;
			vals = new int[4];
			row = left(row, 3);
			//        for (int r = 0; r < 7; r++) {
			int c = 0;
			COUNT = 1;
			while (c < 4)
			{
				vals[c] = gamesNodes[c, col/*left(r, 3)*/].player;
				if (print)
					Log.Debug(TAG, "R count " + COUNT + " btm " + c + " col " + col/*left(r, 3)*/ + " # " + current.number + " row " + current.row + " vert " + current.col + " #CUR" + gamesNodes[c, col/*left(r, 3)*/].number);
				c++;
			}
			decideLineType(current, vals, COUNT);
			//        }//////endradial
			///spirals
			//SR
			row = 0;
			int STARTCOL = current.col;
			col = current.col;
			start = col;
			//        for (int sr = 0; sr < rows; sr++) {
			STARTCOL = col;// left(current.vert, sr);
			vals = new int[4];
			c = 0;
			while (c < 4)
			{
				vals[c] = gamesNodes[c, right(STARTCOL, c)].player;
				if (print)
					Log.Debug(TAG, "SR count " + COUNT + " btm " + c + " col " + right(STARTCOL, c) + " #IN " + current.number + " row " + current.row + " vert " + current.col + " #CUR" + gamesNodes[c, right(STARTCOL, c)].number);
				c++;
			}
			decideLineType(current, vals, COUNT);
			//        }
			////SL
			row = 0;
			col = current.col;
			start = col;
			//        for (int sr = 0; sr < rows; sr++) {
			STARTCOL = col;// right(current.vert, sr);
			vals = new int[4];
			c = 0;
			while (c < 4)
			{
				vals[c] = gamesNodes[c, left(STARTCOL, c)].player;
				if (print)
					Log.Debug(TAG, "SL count " + COUNT + " btm " + c + " col " + left(STARTCOL, c) + " # " + current.number + " row " + current.row + " vert " + current.col + " #CUR" + gamesNodes[c, left(STARTCOL, c)].number);
				c++;
			}
			decideLineType(current, vals, COUNT++);
			//        }///////////sr

			//        printit

			//        if (print) {
			//            String o = "";
			//            for (int[] lin : LINE_INPUTS) {
			//                for (int ltype : lin) {
			//                    o += "\t" + ltype;
			//                }
			//                o += "\n";
			//                Log.Debug(TAG, o);  }
			//
			//            Log.Debug(TAG, "___________________________________________________________"); }


		}

		public void decideLineType(Node current, int[] vals, int line)
		{
			int c = 0;
			int sum = 0, sum1 = 0, sum2 = 0;
			for (int i = 0; i < 4; i++)
			{
				switch (vals[i])
				{
					case 0:
						sum2++;
						break;
					case -1:
						sum++;
						break;
					case 1:
						sum1++;
						break;
				}
			}

			String t = "";
			String s = String.Format("%d %d %d %d", vals[0], vals[1], vals[2], vals[3]);


			if (print) Log.Debug(TAG, "\n::::::::::::::::::::::::    " + s);
			if (sum2 != 4)
			{
				//            if (sum > 0) {
				//                featureVal+= (.25- (sum - 1))*line;
				//  LINE_INPUTS[line ,  lineType.E1.ordinal() + sum - 1] = -1;
				t += "E" + (sum);
				//            }
				if (sum1 > 0)
				{
					//            } else {
					featureVal += (1 + (sum1 - 1)) * line;//  LINE_INPUTS[line,  lineType.F1.ordinal() + sum1 - 1] = 1;
					t += "F" + (sum1);
					//            }
				}
				if (sum > 0 && sum1 == 0)
				{
					featureVal += 1 * ((sum - 1) * line);//LINE_INPUTS[line, lineType.MIX.ordinal()] = sum1 > sum ? 1 : 0;
					t += "MIX";
				}
			}
			else
			{
				featureVal += 0;// LINE_INPUTS[line ,   lineType.EMPTY.ordinal()] = 1;
				t += "EMPTY";
			}
			//        if (print)
			//            Log.Debug(TAG, "\n::::::::::::::::::::::::    " + t + "\nLINEINPUTS\t" + LINE_INPUTS.ToString());
		}

		public void setValue(float value)
		{
			this.value = value;
		}

		public void setTruths(Node n)
		{
			this.A = n.A;
			this.R = n.R;
			this.SR = n.SR;
			this.SL = n.SL;
		}

		public String neighborString()
		{
			String s = "Neighbors { ";
			foreach (Node n in neighbors)
			{
				s += n.getNumber() + "  ";
			}
			s += " } ";
			return s;
		}


		public override string ToString()
		{
			return "Node{" +
					", number=" + number +
					", player=" + player +
					", row=" + row +
					", vert=" + col +
					'}';
		}

		private float getEdgesValue()
		{
			int numEdge = 0;
			if (A) numEdge++;
			if (R) numEdge++;
			if (SL) numEdge++;
			if (SR) numEdge++;
			return numEdge;
		}



		public void setNumber(int number)
		{
			this.number = number;
		}

		public void setPlayer(int player)
		{
			this.player = player;
		}

		public void setRow(int row)
		{
			this.row = row;
		}

		public void setVert(int vert)
		{
			this.col = vert;
		}


		public List<Node> getNeighbors()
		{
			return neighbors;
		}

		public int getNumber()
		{
			return number;
		}

		public int getPlayer()
		{
			return player;
		}

		public int getRow()
		{
			return row;
		}

		public int getVert()
		{
			return col;
		}
		 
	}
}