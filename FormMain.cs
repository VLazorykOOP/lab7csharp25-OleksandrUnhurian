using System;
using System.Windows.Forms;

namespace Lab7
{
    public class FormMain : Form
    {
        public FormMain()
        {
            Text = "Main Menu";
            Width = 750;
            Height = 300;

            Button btn1 = new Button() { Text = "Task 1", Top = 40, Left = 120, Width = 500, Height = 50 };
            Button btn2 = new Button() { Text = "Task 2", Top = 80, Left = 120, Width = 500, Height = 50 };
            Button btn3 = new Button() { Text = "Task 3", Top = 120, Left = 120, Width = 500, Height = 50 };

            btn1.Click += (s, e) => new FormInfo().Show();
            btn2.Click += (s, e) => new FormGraph().Show();
            btn3.Click += (s, e) => new FormDraw().Show();

            Controls.AddRange(new Control[] { btn1, btn2, btn3 });
        }
    }
}