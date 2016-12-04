using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Draw(Circle a, Color color)
        {

            SolidBrush myBrush = new System.Drawing.SolidBrush(color);
            Graphics formGraphics = this.CreateGraphics();
            if (color == System.Drawing.Color.Red)
            {
                formGraphics.Clear(Color.White);
            }
            formGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            formGraphics.FillEllipse(myBrush, (float)(a.X - a.Radius), (float)(a.Y - a.Radius), (float)a.Radius * 2, (float)a.Radius * 2);
            myBrush.Dispose();
            formGraphics.Dispose();
        }
        private void drawBoth(object sender, EventArgs e)
        { 
            Circle a = new Circle(double.Parse(x1.Text), double.Parse(y1.Text), double.Parse(r1.Text));
            Circle b = new Circle(double.Parse(x2.Text), double.Parse(y2.Text), double.Parse(r2.Text));
            Draw(a, System.Drawing.Color.Red);
            Draw(b, System.Drawing.Color.Blue);
            resultBox.Text = Geometry.Check(a, b) ? "Intersect" : "Do not intersect";
        }
        private void checkButton_Click(object sender, EventArgs e)
        {
            drawBoth(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



    }
}
