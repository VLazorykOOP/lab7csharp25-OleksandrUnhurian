using System.Drawing;

namespace Lab7
{
    public class Square : Shape
    {
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color), X, Y, Size, Size);
        }
    }
}