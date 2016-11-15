using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Flowers_Mouse
{
	public partial class Shape : Form
	{
		public Shape( )
		{
			InitializeComponent();
			List<Point> ShPath = new List<Point>(); 
			double ang = 0;
			double delta = Math.PI + Math.PI/18;
			Random rrnndd = new Random();
			int size = rrnndd.Next(20, 50);
			for (int ii = 0; ii < 36; ii ++)
			{
				int X  = (int)Math.Round((1+ Math.Cos(ang))*size)+ Left;
				int Y  = (int)Math.Round((1+ Math.Sin(ang))*size)+ Top;
				ang += delta;
				Point pnt = new Point(X, Y);
				ShPath.Add(pnt);
			}
			GraphicsPath path = new GraphicsPath();
			path.AddPolygon(ShPath.ToArray());
			Region = new Region(path);
		}

		

		private void Shape_FormClosed(object sender,FormClosedEventArgs e)
		{
			for(float op = 0.9F; op > 0; op -= 0.02F)
			{
				Thread.Sleep(10);
				Opacity = op;
			}
		}
		
	}
}