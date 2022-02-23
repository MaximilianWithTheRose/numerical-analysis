using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Half_interval
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		decimal F(decimal x)
		{
			try
			{
				return x * x * x + 3 * x - 2;
				//return (decimal)Math.Sqrt((double)x);
				//return x*x*x-2*x-5;
				//return (decimal)Math.Sin((double)x);
				//return x;
				//return (decimal)((double)x + Math.Pow(Math.E, (double)x));
			}
			catch (Exception)
			{
				return 0m;
			}
		}

		float F(float x)
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


		private void button1_Click(object sender, EventArgs e)
		{
			decimal min = numericUpDown1.Value;
			decimal max = numericUpDown2.Value;
			if (min > max)
			{
				min = min + max;
				max = min - max;
				min = min - max;
			}

			decimal? min_val = null,
				max_val = null;

			decimal error = numericUpDown3.Value;
			int c = 0;
			while (max - min >= error)
			{
				c++;
				min_val ??= F(min);
				max_val ??= F(max);

				decimal avg = (min + max) / 2M,
					avg_val = F(avg);

				if (min_val * avg_val < 0)
				{
					max = avg;
					max_val = avg_val;
				}
				else
				{
					min = avg;
					min_val = avg_val;
				}

				if (c > 100000)
					break;
			}


			string format = $"F{CalcDigits(error)}";
			listBox1.Items.Insert(0, "");
			listBox1.Items.Insert(0, $"шагов: {c}");
			listBox1.Items.Insert(0, $"ξ ϵ ({min.ToString(format)};{max.ToString(format)})");
			textBox1.Text = $"ξ ϵ ({min.ToString(format)};{max.ToString(format)})";

		}

		int CalcDigits(decimal num)
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

		int MAX_REAL = 10;
		int MIN_REAL;
		int NUM_STEPS = 100;
		const int UNIT_OFFSET = 2;
		const int FITH_UNIT_OFFSET = 6;
		float ratio;

		Pen gridPen = new(Color.Black, 1)
		{
			Alignment = PenAlignment.Center,
			StartCap = LineCap.Round,
			EndCap = LineCap.Round
		};
		Pen graphPen = new(Color.Blue, 1)
		{
			Alignment = PenAlignment.Center,
			StartCap = LineCap.Round,
			EndCap = LineCap.Round
		};

		private void button2_Click(object sender, EventArgs e)
		{
			MAX_REAL = (int)numericUpDown4.Value;
			MIN_REAL = -MAX_REAL;

			#region bitmap stuff
			Bitmap mainBmp;
			Graphics graphics;
			RectangleF pictureBoxBounds;
			gridPen.Alignment = PenAlignment.Center;
			gridPen.StartCap = gridPen.EndCap = LineCap.Round;
			using (Graphics g = pictureBox1.CreateGraphics())
			{
				pictureBoxBounds = g.VisibleClipBounds;
				mainBmp = new Bitmap((int)pictureBoxBounds.Width, (int)pictureBoxBounds.Height, g);
			}
			graphics = Graphics.FromImage(mainBmp);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			#endregion

			// pictureBox check
			if ((int)pictureBoxBounds.Width != (int)pictureBoxBounds.Height)
			{
				throw new Exception("height should be equal to width");
			}

			int pbSize = (int)pictureBoxBounds.Width;
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
					offset = FITH_UNIT_OFFSET;
				else
					offset = UNIT_OFFSET;

				graphics.DrawLine(gridPen, x, pbC - offset, x, pbC + offset);
				graphics.DrawLine(gridPen, pbC - offset, x, pbC + offset, x);
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

			pictureBox1.Image = mainBmp;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			button2_Click(sender, null);
		}

		float ToCord(float real, float ratio, float pic_dimension)
		{
			return MathF.Max(MathF.Min((-real) / ratio + pic_dimension / 2, pic_dimension), 0);
		}

		float ToReal(float cord, float ratio, float max_real)
		{
			return cord * ratio - max_real;
		}
	}
}
