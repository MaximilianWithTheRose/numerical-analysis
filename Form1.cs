using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		static decimal F(decimal x)
		{
			try
			{
				return x * x * x + 3 * x - 2; // y = x^3 + 3x - 2
				//return 0.5m * (x+1m) * (x+1m) - 1; // y = x^3 + 3x - 2
			}
			catch (Exception)
			{
				return 0m;
			}
		}
		static float F(float x)
		{
			try
			{
				return (float)F((decimal)x);
			}
			catch (Exception)
			{
				return 0f;
			}
		}

		List<(PointF, PointF)> chords = new();

		private void button1_Click(object sender, EventArgs e)
		{
			#region lb stuff
			listBox1.Items.Clear();
			#endregion
			#region graph stuff
			chords.Clear();
			#endregion

			decimal min, min_val;
			decimal max, max_val;
			decimal error;

			min = numericUpDown1.Value;
			max = numericUpDown2.Value;
			#region // исправить границы в случае ошибки ввода
			if (min > max)
			{
				min = min + max;
				max = min - max;
				min = min - max;
			}
			#endregion
			error = numericUpDown3.Value;

			int numDigits = NumOfImportantDigits(error);
			string valueFormat = $"F{numDigits}";

			min_val = F(min);
			max_val = F(max);

			#region graph stuff
			chords.Add(new(new PointF((float)min, (float)min_val), new PointF((float)max, (float)max_val)));
			#endregion

			bool move_right = (min_val < max_val);

			int stepNum = 1;
			decimal root_old = decimal.MinValue;
			int eq_counter = 0;
			while (max - min >= error)
			{
				decimal root = min - (min_val / (max_val - min_val)) * (max - min);

				root = Math.Round(root, numDigits);

				if (root == root_old)
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

				#region output stuff
				listBox1.Items.Add($"{stepNum + ")",-4} ({min.ToString(valueFormat),-10}, {max.ToString(valueFormat),-10})");
				#endregion
				#region graph stuff
				chords.Add(new(new PointF((float)min, (float)min_val), new PointF((float)max, (float)max_val)));
				#endregion
				stepNum++;
				if (stepNum > 100000 || eq_counter == 3)
					break;
			}
			#region graph stuff
			chords.Add(new(new PointF((float)min, (float)min_val), new PointF((float)max, (float)max_val)));
			#endregion
			#region clean-up stuff
			listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
			listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
			listBox1.Items.RemoveAt(listBox1.Items.Count - 1);

			chords.RemoveAt(chords.Count - 1);
			chords.RemoveAt(chords.Count - 1);
			chords.RemoveAt(chords.Count - 1);
			#endregion
			textBox1.Text = $"ξ ϵ ({min.ToString(valueFormat)};{max.ToString(valueFormat)})";
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





		int MAX_REAL, MIN_REAL;
		const int NUM_STEPS = 70;
		const int TICK_HEIGHT = 2;
		const int FITH_TICK_HEIGHT = 6;
		const int INCREASE_LOL = 4;
		float ratio;

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

		private void Form1_Load(object sender, EventArgs e)
		{
			button2_Click(sender, null);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MAX_REAL = (int)numericUpDown4.Value;
			MIN_REAL = -MAX_REAL;

			#region bitmap stuff
			Bitmap mainBmp;
			Graphics graphics;
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
			#endregion

			int pbSize = size;
			int pbC = pbSize / 2;
			ratio = MAX_REAL * 2f / pbSize;

			#region draw grid
			gridPen.Width = 1;
			graphics.DrawLine(gridPen, pbSize / 2, 0, pbSize / 2, pbSize);
			graphics.DrawLine(gridPen, 0, pbSize / 2, pbSize, pbSize / 2);

			gridPen.Width = 1;
			for (float realX = MIN_REAL; realX <= MAX_REAL; realX += 1)
			{
				int x = (int)ToCord(realX, ratio, pbSize);

				int offset;
				if (realX % 5 == 0)
					offset = FITH_TICK_HEIGHT;
				else
					offset = TICK_HEIGHT;

				graphics.DrawLine(gridPen, x, pbC - offset, x, pbC + offset);
				graphics.DrawLine(gridPen, pbC - offset, x, pbC + offset, x);

				if (realX != 0)
				{
					Font f = new("Arial", 8);
					graphics.DrawString((-realX).ToString(), f, new SolidBrush(Color.Black), x, pbC + offset);
					graphics.DrawString((-realX).ToString(), f, new SolidBrush(Color.Black), pbC + offset, x);
				}
			}
			#endregion

			List<PointF> graphPoints = new();
			for (float x = 0; x < pbSize; x += pbSize / NUM_STEPS)
			{
				float correctedX = ToReal(x, ratio, MAX_REAL),
				 y = F(correctedX),
				 reversedY = ToCord(y, ratio, pbSize);

				graphPoints.Add(new PointF(x, reversedY));
			}

			graphics.DrawCurve(graphPen, graphPoints.ToArray());


			#region draw chords
			foreach (var chord in chords)
			{
				float
					x1 = ToCord(chord.Item1.X, ratio, pbSize),
					y1 = ToCord(chord.Item1.Y, ratio, pbSize);

				float
					x2 = ToCord(chord.Item2.X, ratio, pbSize),
					y2 = ToCord(chord.Item2.Y, ratio, pbSize);

				y1 = ToCord(F(chord.Item1.X), ratio, pbSize);
				y2 = ToCord(F(chord.Item2.X), ratio, pbSize);

				x1 = pbC - (x1 - pbC);
				x2 = pbC - (x2 - pbC);

				graphics.DrawLine(chordPen, x1, y1, x2, y2);
			}
			#endregion

			pictureBox1.Image = mainBmp;
		}


		static float ToCord(float real, float ratio, float pic_dimension)
		{
			return MathF.Max(MathF.Min((-real) / ratio + pic_dimension / 2, pic_dimension), 0);
		}

		static float ToReal(float cord, float ratio, float max_real)
		{
			return cord * ratio - max_real;
		}
	}
}
