#define TEST_MEASURE_STRING
#define TEST_MEASURE_TEXT
//#define TEST_PAGE_UNIT

using System.Drawing;
using System.Windows.Forms;

namespace TestGraphics
{
    public partial class MainForm : Form
    {
        #if TEST_MEASURE_STRING
            //string measureString = "Measure String";
            string measureString = "0";
            Font stringFont = new Font("Calibri", 11);
        #endif

        public MainForm()
        {
            InitializeComponent();
        }

        void MainFormPaint(object sender, PaintEventArgs e)
        {
            #if TEST_PAGE_UNIT
                ChangePageUnit(e);
            #endif

            #if TEST_MEASURE_STRING
                TestMeasureString(e);
            #endif

            #if TEST_MEASURE_TEXT
                TestMeasureText(e);
            #endif
        }

        #if TEST_PAGE_UNIT
            void ChangePageUnit(PaintEventArgs e)
            {

                // Create a rectangle.
                Rectangle rectangle1 = new Rectangle(20, 20, 50, 100);

                // Draw its outline.
                e.Graphics.DrawRectangle(Pens.SlateBlue, rectangle1);

                // Change the page scale.  
                e.Graphics.PageUnit = GraphicsUnit.Point;

                // Draw the rectangle again.
                e.Graphics.DrawRectangle(Pens.Tomato, rectangle1);

            }
        #endif

        #if TEST_MEASURE_STRING
            void TestMeasureString(PaintEventArgs e)
            {
                // Measure string.
                SizeF stringSize = new SizeF();
                stringSize = e.Graphics.MeasureString(measureString, stringFont);

                // Draw rectangle representing size of string.
                e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

                // Draw string to screen.
                e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0));    
            }
        #endif

        #if TEST_MEASURE_TEXT
            void TestMeasureText(PaintEventArgs e)
            {
                Size textSize = TextRenderer.MeasureText(measureString, stringFont);
                TextRenderer.DrawText(e.Graphics, measureString, stringFont, new Rectangle(new Point(0, 20), textSize), Color.Red);  
            }
        #endif
    }
}
