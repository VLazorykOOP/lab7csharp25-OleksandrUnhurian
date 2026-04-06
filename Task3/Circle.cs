using System.Drawing;

namespace Lab7
{
    public class Circle : Shape
    {
        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color), X, Y, Size, Size);
        }
    }
}