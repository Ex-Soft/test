using System;

namespace BridgeGenerics
{
	// "Abstraction"
	interface IShape
	{
		void Draw();                             // low-level (i.e. Implementation-specific)
		void ResizeByPercentage(double pct);     // high-level (i.e. Abstraction-specific)
	}

	// "Implementor"
	interface IDrawingAPI
	{
		void DrawCircle(double x, double y, double radius);
	}

	// "Refined Abstraction"
	class CircleShape<T> : IShape where T : struct, IDrawingAPI
	{
		private double x, y, radius;
		private IDrawingAPI drawingAPI = new T();

		public CircleShape(double x, double y, double radius)
		{
			this.x = x; this.y = y; this.radius = radius;
		}

		// low-level (i.e. Implementation-specific)
		public void Draw()
		{
			drawingAPI.DrawCircle(x, y, radius);
		}

		// high-level (i.e. Abstraction-specific)
		public void ResizeByPercentage(double pct)
		{
			radius *= pct;
		}
	}

	// "ConcreteImplementor" 1/2
	struct DrawingAPI1 : IDrawingAPI
	{
		public void DrawCircle(double x, double y, double radius)
		{
			Console.WriteLine("API1.circle at {0}:{1} radius {2}", x, y, radius);
		}
	}

	// "ConcreteImplementor" 2/2
	struct DrawingAPI2 : IDrawingAPI
	{
		public void DrawCircle(double x, double y, double radius)
		{
			Console.WriteLine("API2.circle at {0}:{1} radius {2}", x, y, radius);
		}
	}

	class Program
	{
		static void Main()
		{
			IShape[] shapes = new IShape[2];
			shapes[0] = new CircleShape<DrawingAPI1>(1, 2, 3);
			shapes[1] = new CircleShape<DrawingAPI2>(5, 7, 11);

			foreach (IShape shape in shapes)
			{
				shape.ResizeByPercentage(2.5);
				shape.Draw();
			}
		}
	}
}
