using System;

namespace NumAnalysis.Subsystems
{
	internal class MyFunction
	{
		private readonly Func<decimal, decimal> func;

		public MyFunction(Func<decimal, decimal> func)
		{
			this.func = func;
		}

		public T F<T>(T x) where T : IConvertible
		{
			try
			{
				return (T)Convert.ChangeType(func.Invoke((decimal)Convert.ChangeType(x, typeof(decimal))), typeof(T));
			}
			catch (Exception)
			{
				return (T)Convert.ChangeType(0, typeof(T));
			}
		}

		#region premade functions
		public static MyFunction One => new MyFunction(x => 1m);

		public static MyFunction Linear => new MyFunction(x => x);

		public static MyFunction Quadratic => new MyFunction(x => x * x);

		public static MyFunction Cubic => new MyFunction(x => x * x * x);

		public static MyFunction Var25 => new MyFunction(x => 0.5m * (x + 1m) * (x + 1m) - 1);

		#endregion
	}
}