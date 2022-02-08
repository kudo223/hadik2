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

namespace hadik2
{
    public partial class Form1 : Form
    {
        Region region1;
        Region region2;
        Region intersection;
        GraphicsPath snakePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GraphicsPath graphicsPath1 = new GraphicsPath();
            GraphicsPath graphicsPath2 = new GraphicsPath();
            
            graphicsPath1.AddEllipse(10, 10, 100, 100);
            graphicsPath2.AddEllipse(50, 50, 200, 200);

            region1 = new Region(graphicsPath1);
            region2 = new Region(graphicsPath2);

            intersection = region1.Clone();
            intersection.Intersect(region2);

            snakePath = new GraphicsPath();
            snakePath.AddLine(0, 0, 100, 100);
            snakePath.AddLine(100, 100, 200, 200);
            snakePath.AddLine(100, 200, 300, 400);
            snakePath.AddLines(new Point[] { new Point(300, 400), new Point(250, 200), new Point(150, 300) });

            Pen pero = new Pen(Color.Black, 10);
            pero.StartCap = LineCap.Round;
            pero.EndCap = LineCap.Round;
            snakePath.Widen(pero);

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(region1 != null)
            {
                e.Graphics.FillRegion(Brushes.Red, region1);
            }
            if (region2 != null)
            {
                e.Graphics.FillRegion(Brushes.Lime, region2);
            }
            if (intersection != null)
            {
                e.Graphics.FillRegion(Brushes.Yellow, intersection);
                Text = (!intersection.IsEmpty(e.Graphics)).ToString();
            }
            if(snakePath !=null)
            {
                //e.Graphics.DrawPath(, snakePath);
            }
        }

    }
}
