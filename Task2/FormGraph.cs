using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7
{
    public class FormGraph : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        float x;
        List<PointF> points = new List<PointF>();

        Color graphColor = Color.Red;
        float pointSize = 6;
        float lineThickness = 2;

        Button btnRedraw;
        TrackBar trackSize;
        ComboBox comboThickness;

        public FormGraph()
        {
            Text = "Graph PRO";
            this.WindowState = FormWindowState.Maximized;

            RadioButton r1 = new RadioButton() { Text = "Red", Top = 10, Left = 10, Checked = true };
            RadioButton r2 = new RadioButton() { Text = "Blue", Top = 30, Left = 10 };
            RadioButton r3 = new RadioButton() { Text = "Green", Top = 50, Left = 10 };
            RadioButton r4 = new RadioButton() { Text = "Purple", Top = 70, Left = 10 };
            RadioButton r5 = new RadioButton() { Text = "Black", Top = 90, Left = 10 };
            RadioButton r6 = new RadioButton() { Text = "Pink", Top = 110, Left = 10 };


            r1.CheckedChanged += (s, e) => graphColor = Color.Red;
            r2.CheckedChanged += (s, e) => graphColor = Color.Blue;
            r3.CheckedChanged += (s, e) => graphColor = Color.Green;
            r4.CheckedChanged += (s, e) => graphColor = Color.Purple;
            r5.CheckedChanged += (s, e) => graphColor = Color.Black;
            r6.CheckedChanged += (s, e) => graphColor = Color.Pink;

            btnRedraw = new Button()
            {
                Text = "Перемалювати",
                Top = 150,
                Left = 10,
                Width = 150,
                Height = 30
            };
            btnRedraw.Click += RedrawGraph;

            // 🎚 TrackBar (розмір точок)
            trackSize = new TrackBar()
            {
                Minimum = 2,
                Maximum = 20,
                Value = 6,
                Top = 180,
                Left = 10,
                Width = 150
            };

            trackSize.Scroll += (s, e) =>
            {
                pointSize = trackSize.Value;
                Invalidate();
            };

            comboThickness = new ComboBox()
            {
                Top = 250,
                Left = 10,
                Width = 100
            };

            comboThickness.Items.AddRange(new string[] { "1", "2", "3", "5", "8" });
            comboThickness.SelectedIndex = 1;

            comboThickness.SelectedIndexChanged += (s, e) =>
            {
                lineThickness = float.Parse(comboThickness.SelectedItem.ToString());
                Invalidate();
            };

            Controls.AddRange(new Control[]
            {
                r1, 
                r2, 
                r3, 
                r4, 
                r5, 
                r6,
                btnRedraw, 
                trackSize, 
                comboThickness
            });

            timer.Interval = 50;
            timer.Tick += Timer_Tick;

            StartGraph();

            Paint += DrawGraph;
        }

        private void StartGraph()
        {
            points.Clear();
            x = -2;
            timer.Start();
        }

        private void RedrawGraph(object sender, EventArgs e)
        {
            timer.Stop();
            StartGraph();
            Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (x <= 2)
            {
                float y = (1 - x * x) * (x - 2);
                points.Add(new PointF(x, y));
                x += 0.1f;
                Invalidate();
            }
            else
            {
                timer.Stop();
            }
        }

        private void DrawGraph(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int centerX = Width / 2;
            int centerY = Height / 2;
            int scale = 60;

            Pen axisPen = new Pen(Color.Black, 2);

            g.DrawLine(axisPen, 0, centerY, Width, centerY); // X
            g.DrawLine(axisPen, centerX, 0, centerX, Height); // Y

            Font font = new Font("Arial", 8);

            for (int i = -5; i <= 5; i++)
            {
                int xPos = centerX + i * scale;
                int yPos = centerY - i * scale;

                g.DrawLine(Pens.Black, xPos, centerY - 5, xPos, centerY + 5);
                g.DrawLine(Pens.Black, centerX - 5, yPos, centerX + 5, yPos);

                g.DrawString(i.ToString(), font, Brushes.Black, xPos - 10, centerY + 8);
                g.DrawString(i.ToString(), font, Brushes.Black, centerX + 8, yPos - 10);
            }

            Pen graphPen = new Pen(graphColor, lineThickness);

            for (int i = 1; i < points.Count; i++)
            {
                var p1 = points[i - 1];
                var p2 = points[i];

                g.DrawLine(graphPen,
                    centerX + p1.X * scale,
                    centerY - p1.Y * scale,
                    centerX + p2.X * scale,
                    centerY - p2.Y * scale);
            }

            foreach (var p in points)
            {
                float px = centerX + p.X * scale;
                float py = centerY - p.Y * scale;

                g.FillEllipse(
                    new SolidBrush(graphColor),
                    px - pointSize / 2,
                    py - pointSize / 2,
                    pointSize,
                    pointSize
                );
            }
        }
    }
}