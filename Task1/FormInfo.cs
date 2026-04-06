using System;
using System.Windows.Forms;

namespace Lab7
{
    public class FormInfo : Form
    {
        TextBox textBox;
        Button btnInfo, btnExit;
        Random rnd = new Random();

        public FormInfo()
        {
            Text = "Info Form";
            Width = 800;
            Height = 400;

            textBox = new TextBox() { Top = 20, Left = 20, Width = 300 };

            btnInfo = new Button() { Text = "Інформація", Top = 100, Left = 40, Width = 100, Height = 30 };
            btnExit = new Button() { Text = "Вихід", Top = 60, Left = 150, Width = 100, Height = 30 };

            btnInfo.Click += (s, e) =>
            {
                textBox.Text = $"X: {Location.X}, Y: {Location.Y}";
            };

            btnExit.MouseMove += (s, e) =>
            {
                btnExit.Left = rnd.Next(0, Width - btnExit.Width);
                btnExit.Top = rnd.Next(0, Height - btnExit.Height);
            };

            btnExit.Click += (s, e) => Close();

            Controls.AddRange(new Control[] { textBox, btnInfo, btnExit });
        }
    }
}