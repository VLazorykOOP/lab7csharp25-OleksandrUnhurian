using System.Drawing;

namespace Lab7
{
    public class Triangle : Shape
    {
        public override void Draw(Graphics g)
        {
            Point[] p = {
                new Point(X, Y),
                new Point(X + Size, Y),
                new Point(X + Size / 2, Y - Size)
            };
            g.FillPolygon(new SolidBrush(Color), p);
        }
    }
}