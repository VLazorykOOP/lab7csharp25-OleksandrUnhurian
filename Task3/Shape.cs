using System.Drawing;

namespace Lab7
{
    public abstract class Shape
    {
        public int X, Y, Size;
        public Color Color;

        public abstract void Draw(Graphics g);
    }
}