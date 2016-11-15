using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Flowers_Mouse
{
	public partial class MainForm : Form
	{
		private int m_Dx;
		private int m_Dy;
		private WaitCallback m_wk;
		public MainForm( )
		{
			InitializeComponent();
			m_wk = DrawShape;
		}

		private void MainForm_MouseMove(object sender,MouseEventArgs e)
		{
			if(Math.Abs(m_Dx - e.X) > 40 || Math.Abs(m_Dy - e.Y) > 40)
			{
				m_Dx = e.X;
				m_Dy = e.Y;
				Point Coord = new Point(m_Dx+Left, m_Dy + Top);
				ThreadPool.QueueUserWorkItem(m_wk, Coord);
			}
		}

		static void DrawShape(object Coord)
		{
			Shape nS = new Shape();
			nS.Location = (Point)Coord;
			nS.Show();
			nS.Update();
			Thread.Sleep(500);
			nS.Close();
		}
	}

}