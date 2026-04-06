using System.Drawing;

namespace Lab7
{
    public class Star : Shape
    {
        public override void Draw(Graphics g)
        {
            PointF[] points = new PointF[10];

            double angle = -Math.PI / 2; 
            double step = Math.PI / 5;  

            float R = Size;       
            float r = Size / 2.5f; 

            for (int i = 0; i < 10; i++)
            {
                float radius = (i % 2 == 0) ? R : r;

                points[i] = new PointF(
                    X + (float)(radius * Math.Cos(angle)),
                    Y + (float)(radius * Math.Sin(angle))
                );

                angle += step;
            }

            g.FillPolygon(new SolidBrush(Color), points);
        }
    }
}