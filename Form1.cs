using System.Collections.Generic;
using System.Drawing;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows;
using System.Linq;
using NumAnalysis.Subsystems;
//using Windows.Devices.Radios;

namespace NumAnalysis
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}


		delegate (decimal, decimal) Calculator(decimal min, decimal max, decimal error, 
			out List<((decimal X, decimal Y) min, (decimal X, decimal Y) max)> steps);		

		List<((decimal X, decimal Y) min, (decimal X, decimal Y) max)> steps = new();
		
		Calculator MethodDelegate;

		MyFunction function;


		int MAX_X, MIN_X;
		const int NUM_STEPS = 70;
		const int TICK_HEIGHT = 2;
		const int FITH_TICK_HEIGHT = 6;
		const int INCREASE_LOL = 4;

		private void Form1_Load(object sender, EventArgs e)
		{
			MethodDelegate += CalcChords;
			function = MyFunction.Linear;

			button2_Click(sender, null);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Calculate();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Draw();
		}

		private void Calculate()
		{
			listBox1.Items.Clear();


			decimal min = numericUpDown1.Value;
			decimal max = numericUpDown2.Value;
			decimal error = numericUpDown3.Value;

			#region исправить границы в случае ошибки ввода
			if (min > max)
			{
				min = min + max;
				max = min - max;
				min = min - max;
			}
			#endregion

			int digits = NumOfImportantDigits(error);

			(min, max) = MethodDelegate.Invoke(min, max, error, out steps);

			textBox1.Text = $"ξ ϵ ({ToString(min, digits)};{ToString(max, digits)})";

			for (int i = 1; i < steps.Count; i++)
				listBox1.Items.Add($"{i + ")",-4} ({ToString(steps[i].min.X, digits),-10}, {ToString(steps[i].max.X, digits),-10})");
		}

		private static string ToString(decimal d, int digits)
		{
			string valueFormat = $"F{digits}";
			return d.ToString(valueFormat);
		}


		private static (decimal min, decimal max) CalcChords(decimal min, decimal max, decimal error, out List<((decimal X, decimal Y) min, (decimal X, decimal Y) max)> steps)
		{
			decimal min_val = F(min);
			decimal max_val = F(max);
			decimal root_old = decimal.MinValue;
			bool move_right = (min_val < max_val);
			int eq_counter = 0;
			int i = 0;

			steps = new();
			steps.Add(((min, min_val), (max, max_val)));

			while (max - min >= error)
			{
				decimal root = min - (min_val / (max_val - min_val)) * (max - min);

				if (Math.Abs(root - root_old) < error)
					eq_counter++;
				else
					eq_counter = 0;

				root_old = root;

				if (move_right)
				{
					min = root;
					min_val = F(min);
				}
				else
				{
					max = root;
					max_val = F(max);
				}

				steps.Add(((min, min_val), (max, max_val)));

				i++;
				if (i > 100000 || eq_counter == 3)
					break;
			}

			//steps.Add(new(new PointF((float)min, (float)min_val), new PointF((float)max, (float)max_val)));


			steps.RemoveAt(steps.Count - 1);
			steps.RemoveAt(steps.Count - 1);
			//steps.RemoveAt(steps.Count - 1);

			return (min, max);
		}

		static int NumOfImportantDigits(decimal num)
		{
			int i;
			for (i = 1; i < 15; i++)
			{
				num *= 10;
				if (num >= 1)
					break;
			}

			return i;
		}


		readonly Pen gridPen = new(Color.Black, 1)
		{
			Alignment = PenAlignment.Center,
			StartCap = LineCap.Round,
			EndCap = LineCap.Round
		};
		readonly Pen graphPen = new(Color.Blue, 1)
		{
			Alignment = PenAlignment.Center,
			StartCap = LineCap.Round,
			EndCap = LineCap.Round
		};
		readonly Pen chordPen = new(Color.Red, 1)
		{
			Alignment = PenAlignment.Center,
			StartCap = LineCap.Round,
			EndCap = LineCap.Round
		};

		Bitmap mainBmp;
		Graphics graphics;

		private int GetSize()
		{
			return mainBmp.Size.Width;
		}

		private void Draw()
		{
			CreateBmp();

			int pbSize = GetSize();
			int pbC = pbSize / 2;

			CalcCoeffs();

			DrawGrid(gridPen);

			DrawFunction(graphPen);

			List<((float X, float Y), (float X, float Y))> stepsF;
			stepsF = steps.Select(x => (((float)x.max.X, (float)x.max.Y), ((float)x.min.X, (float)x.min.Y))).ToList();

			#region draw chords
			foreach (var chord in stepsF)
			{
				float
					x1 = ToPixelsX(chord.Item1.X, MIN_X, MAX_X),
					y1 = ToPixelsY(chord.Item1.Y, MIN_Y, MAX_Y);

				float
					x2 = ToPixelsX(chord.Item2.X, MIN_X, MAX_X),
					y2 = ToPixelsY(chord.Item2.Y, MIN_Y, MAX_Y);

				y1 = ToPixelsY(F(chord.Item1.X), MIN_Y, MAX_X);
				y2 = ToPixelsY(F(chord.Item2.X), MIN_Y, MAX_Y);

				x1 = pbC - (x1 - pbC);
				x2 = pbC - (x2 - pbC);

				graphics.DrawLine(chordPen, x1, y1, x2, y2);
			}
			#endregion

			pictureBox1.Image = mainBmp;
		}


		(int X, int Y) Shift = new(0, 0);
		int MAX_Y;
		int MIN_Y;
		private void CalcCoeffs()
		{
			MAX_X = GetZoom() / 2 - Shift.X;
			MIN_X = MAX_X - GetZoom();

			MAX_Y = GetZoom() / 2 - Shift.Y;
			MIN_Y = MAX_Y - GetZoom();

			// HACK: fix wierd behavior
			//MoveGraph(Direction.Up);

			ratio = (float)GetZoom() / GetSize();
		}

		private int GetZoom()
		{
			return trackBar1.Value;
		}

		private void DrawFunction(Pen pen)
		{
			List<PointF> graphPoints = new();
			for (float X_px = 0; X_px < GetSize(); X_px += GetSize() / NUM_STEPS)
			{
				float X_val = ToValue(X_px, MIN_X, MAX_X);
				float Y_val = F(X_val);
				float Y_px = ToPixelsY(Y_val, MIN_Y, MAX_Y);

				graphPoints.Add(new(X_px, Y_px));
			}

			graphics.DrawCurve(pen, graphPoints.ToArray());
		}



		private void DrawGrid(Pen pen)
		{
			
			int pbSize = GetSize();
			int pbC = pbSize / 2;

			graphics.DrawLine(pen, pbSize / 2, 0, pbSize / 2, pbSize);
			graphics.DrawLine(pen, 0, pbSize / 2, pbSize, pbSize / 2);

			int numSteps = GetZoom();
			int pixelsStep = GetSize() / numSteps;

			for (int stepNum = 0; stepNum <= numSteps; stepNum++)
			{
				int valueX = stepNum - MAX_X;
				int valueY = -(stepNum - MAX_Y);

				int px = pixelsStep * stepNum;

				int tickHeightForX = ChooseTickHeight(valueX);
				int tickHeightForY = ChooseTickHeight(valueY);

				if (stepNum != numSteps / 2) // don't draw tick for Ox & Oy intersection
				{
					// draw tick for Ox
					graphics.DrawLine(pen, px, pbC - tickHeightForX, px, pbC + tickHeightForX);
					// draw tick for Oy
					graphics.DrawLine(pen, pbC - tickHeightForY, px, pbC + tickHeightForY, px);


					Font font = new("Arial", 8);
					SolidBrush brush = new(Color.Black);

					// draw Ox val
					graphics.DrawString(valueX.ToString(), font, brush, px, pbC + TICK_HEIGHT);
					// draw Oy val
					graphics.DrawString(valueY.ToString(), font, brush, pbC + TICK_HEIGHT, px);
				}
			}

		}

		/// <summary>
		/// Every 5-th tick is higher than others.
		/// </summary>
		/// <param name="valueX">Tick value.</param>
		/// <returns>Height of tick for value.</returns>
		private static int ChooseTickHeight(int valueX)
		{
			int offset_x;
			if (valueX % 5 == 0)
				offset_x = FITH_TICK_HEIGHT;
			else
				offset_x = TICK_HEIGHT;
			return offset_x;
		}

		private void CreateBmp()
		{
			int size;
			gridPen.Alignment = PenAlignment.Center;
			gridPen.StartCap = gridPen.EndCap = LineCap.Round;
			using (Graphics g = pictureBox1.CreateGraphics())
			{
				size = (int)Math.Min(g.VisibleClipBounds.Height, g.VisibleClipBounds.Width) + INCREASE_LOL;
				mainBmp = new Bitmap(size, size, g);
			}
			graphics = Graphics.FromImage(mainBmp);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
		}

		int ToPixels(float value, int minVal, int maxVal)
		{
			int span = maxVal - minVal;
			float value_zeroed = value - minVal;

			float perc = value_zeroed / span;
			return (int)Math.Round(perc * GetSize());
		}

		int ToPixelsX(float value, int minVal, int maxVal)
		{
			return ToPixels(value, minVal, maxVal);
		}

		int ToPixelsY(float value, int minVal, int maxVal)
		{
			return ToPixels(-value, minVal, maxVal);
		}

		float ToValue(float pixel, int minVal, int maxVal)
		{
			int span = maxVal - minVal;
			float perc = pixel / GetSize();

			float value_zeroed = perc * span;

			return value_zeroed+minVal;
			//return pixel * ratio - maxVal;
		}

		#region moving graph
		private void button3_Click(object sender, EventArgs e)
		{
			MoveGraph(Direction.Left);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			MoveGraph(Direction.Right);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			MoveGraph(Direction.Up);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			MoveGraph(Direction.Down);
		}

		private void MoveGraph(Direction direction)
		{
			switch (direction)
			{
				case Direction.Left:
					Shift.X -= GetZoom() / 2;
					break;
				case Direction.Right:
					Shift.X += GetZoom() / 2;
					break;
				case Direction.Up:
					Shift.Y += GetZoom() / 2;
					break;
				case Direction.Down:
					Shift.Y -= GetZoom() / 2;
					break;
			}
		}
		#endregion
	}
}