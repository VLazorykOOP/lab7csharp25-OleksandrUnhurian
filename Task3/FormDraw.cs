using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7
{
    public class FormDraw : Form
    {
        List<Shape> shapes = new List<Shape>();
        Random rnd = new Random();

        ComboBox comboBox;
        Button btnAdd;

        public FormDraw()
        {
            Text = "Draw Shapes";
            Width = 700;
            Height = 500;

            comboBox = new ComboBox()
            {
                Left = 10,
                Top = 10,
                Width = 150
            };

            comboBox.Items.AddRange(new string[]
            {
                "Circle",
                "Square",
                "Triangle",
                "Star"
            });

            comboBox.SelectedIndex = 0;

            btnAdd = new Button()
            {
                Text = "Додати",
                Left = 180,
                Top = 10,
                Width = 100,
                Height = 30
            };

            btnAdd.Click += AddShape;

            Controls.Add(comboBox);
            Controls.Add(btnAdd);

            Paint += DrawShapes;
        }

        private void AddShape(object sender, EventArgs e)
        {
            Shape s;

            string type = comboBox.SelectedItem.ToString();

            if (type == "Circle") s = new Circle();
            else if (type == "Square") s = new Square();
            else if (type == "Triangle") s = new Triangle();
            else s = new Star();

            s.X = rnd.Next(50, Width - 100);
            s.Y = rnd.Next(80, Height - 100);
            s.Size = rnd.Next(20, 50);
            s.Color = Color.FromArgb(
                rnd.Next(255),
                rnd.Next(255),
                rnd.Next(255)
            );

            shapes.Add(s);

            Invalidate(); 
        }

        private void DrawShapes(object sender, PaintEventArgs e)
        {
            foreach (var s in shapes)
            {
                s.Draw(e.Graphics);
            }
        }
    }
}