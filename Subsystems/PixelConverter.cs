using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Half_interval
{
	internal class PixelConverter
	{
		float ratio;
		int size;
		(int X, int Y) shift;

		public PixelConverter(float ratio, int size, (int X, int Y) shift)
		{
			this.ratio = ratio;
			this.size = size;
			this.shift = shift;
		}

		int ToPixelsX(float value, int maxVal)
		{
			return (int)
				MathF.Round(
					Math.Clamp(
						(value - maxVal) / ratio,
						0,
						size)
					);
		}

		int ToPixelsY(float value, int maxVal)
		{
			return ToPixelsX(-value, maxVal);
		}

		float ToValue(float pixel, int maxVal)
		{
			return pixel * ratio - maxVal;
		}
	}
}
