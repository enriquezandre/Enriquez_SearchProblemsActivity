using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace SearchProblemsActivity
{
    public partial class Form1 : Form
    {
        readonly int height = 20, width = 20;
        readonly bool[,] graph = new bool[31, 51];
        bool Drawing = false;

        readonly Color Wall = Color.FromArgb(26, 13, 0);
        readonly Color Start = Color.FromArgb(0, 0, 255);
        readonly Color End = Color.FromArgb(186, 24, 27);
        readonly Color Path = Color.FromArgb(128, 255, 128);
        readonly Color Visited = Color.FromArgb(192, 192, 192);
        readonly Color NodeColor = Color.FromArgb(128, 128, 128);

        struct Node
        {
            public int IndexX, IndexY;
            public void SetYX(int Y, int X)
            {
                IndexX = X;
                IndexY = Y;
            }
        };

        Node StartNode = new Node(), EndNode = new Node();

        public Form1()
        {
            InitializeComponent();
        }

        //loads the form
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = 30 * width + 1;
            pictureBox1.Height = 10 * height + 1;
            StartNode.SetYX(8, 1);
            EndNode.SetYX(1, 28);
            this.BackColor = Color.FromArgb(0, 255, 255);
            this.Width = 32 + pictureBox1.Width;
            this.Height = 160 + pictureBox1.Height;
            timer1.Start();
        }

        //clears board
        void ClearBoard(bool Reset)
        {
            NoNode_label.Text = "Nodes:";
            VisitedCount_label.Text = "Visited:";
            this.Refresh();
            Draw();
            Graphics g = pictureBox1.CreateGraphics();
            Brush _Brush = new SolidBrush(Wall);
            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (Reset) graph[j, i] = false;
                    if (graph[j, i]) g.FillRectangle(_Brush, i * width + 1, j * height + 1, width - 1, height - 1);
                }
        }

        //clears board if ClearBoard_button is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            ClearBoard(true);
        }

        void Draw()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen _Pen = new Pen(Color.Black);
            SolidBrush _SolidBrush = new SolidBrush(Color.White);

            g.FillRectangle(_SolidBrush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < pictureBox1.Height; i += height)
                g.DrawLine(_Pen, 0, i, pictureBox1.Width, i);
            for (int i = 0; i < pictureBox1.Width; i += width)
                g.DrawLine(_Pen, i, 0, i, pictureBox1.Height);

            _SolidBrush.Color = Start;
            g.FillRectangle(_SolidBrush, StartNode.IndexX * width + 1, StartNode.IndexY * height + 1, width - 1, height - 1);
            _SolidBrush.Color = End;
            g.FillRectangle(_SolidBrush, EndNode.IndexX * width + 1, EndNode.IndexY * height + 1, width - 1, height - 1);
        }

        double Heuristic(int Y, int X, string s)
        {
            double y = Math.Abs(Y - EndNode.IndexY), x = Math.Abs(X - EndNode.IndexX);
            return Math.Sqrt(y * y + x * x) + s.Length;
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush _Brush = new SolidBrush(End);

            bool[,] bio = new bool[31, 51], bio2 = new bool[31, 51]; ;
            for (int i = 0; i < 51; i++)
                for (int j = 0; j < 31; j++)
                {
                    bio[j, i] = false;
                    bio2[j, i] = false;
                }

            bio[StartNode.IndexY, StartNode.IndexX] = true;
            bio2[EndNode.IndexY, EndNode.IndexX] = true;

            int[] directionY = new int[4] { 0, 0, 1, -1 }, smjerX = new int[4] { 1, -1, 0, 0 };
            string[] direction = new string[4] { "r", "l", "d", "u" };
            int Visited = 1;
            LinkedList<Tuple<int, int, string>> list = new LinkedList<Tuple<int, int, string>>();
            list.AddFirst(new Tuple<int, int, string>(StartNode.IndexY, StartNode.IndexX, ""));
            string put = "", put2 = "";

            while (list.Count > 0)
            {
                Tuple<int, int, string> Node = new Tuple<int, int, string>(10000, 10000, "");
                Tuple<int, int, string> Node2 = new Tuple<int, int, string>(10000, 10000, "");
                foreach (var it in list)
                    if (Heuristic(it.Item1, it.Item2, it.Item3) < Heuristic(Node.Item1, Node.Item2, Node.Item3))
                        Node = it;
                int x = Node.Item2, x2 = Node.Item2;
                int y = Node.Item1, y2 = Node.Item1;
                put = Node.Item3; put2 = Node.Item3;

                if (x == EndNode.IndexX && y == EndNode.IndexY)
                {
                    _Brush.Color = End; ;
                    g.FillRectangle(_Brush, EndNode.IndexX * width + 1, EndNode.IndexY * height + 1, width - 1, height - 1);
                    break;
                }

                for (int i = 0; i < 4; i++)
                {
                    int newX = x + smjerX[i];
                    int newY = y + directionY[i];
                    if (newX >= 0 && newY >= 0 && newY < 10 && newX < 30 && !bio[newY, newX] && !graph[newY, newX])
                    {
                        list.AddFirst(new Tuple<int, int, string>(newY, newX, put + direction[i]));
                        bio[newY, newX] = true;
                        _Brush.Color = NodeColor;
                        g.FillRectangle(_Brush, newX * width + 1, newY * height + 1, width - 1, height - 1);
                    }
                }
                list.Remove(Node);

                if (StartNode.IndexX != x || StartNode.IndexY != y)
                {
                    _Brush.Color = this.Visited;
                    g.FillRectangle(_Brush, x * width + 1, y * height + 1, width - 1, height - 1);
                    VisitedCount_label.Text = "Visited: " + Visited++;
                }
                VisitedCount_label.Refresh();
                NoNode_label.Text = "Nodes: " + (list.Count());
                NoNode_label.Refresh();
                put = "";
            }

            //draws path
            int xx = StartNode.IndexX * width, yy = StartNode.IndexY * height;
            _Brush.Color = Path;
            for (int i = 0; i < put.Length - 1; i++)
            {
                if (put[i] == 'r') xx += width;
                if (put[i] == 'l') xx -= width;
                if (put[i] == 'd') yy += width;
                if (put[i] == 'u') yy -= width;
                g.FillRectangle(_Brush, xx + 1, yy + 1, height - 1, height - 1);
                System.Threading.Thread.Sleep(1);
            }
        }

        char Item = 'z';
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Drawing = false;
            if (Item == 'P') Item = 'z';
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int X = e.X - e.X % height;
            int Y = e.Y - e.Y % width;
            if (X >= pictureBox1.Width - 1 || Y >= pictureBox1.Height - 1) return;
            if (graph[Y / height, X / width] && Item != 'k' && Item != 'p') Item = 'P';
            Drawing = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drawing == false || Item == 'p' || Item == 'k') return;

            int X = e.X - e.X % width;
            int Y = e.Y - e.Y % height;

            if ((X == StartNode.IndexX * width && Y == StartNode.IndexY * height) || (X == EndNode.IndexX * width && Y == EndNode.IndexY * height)
                || X >= pictureBox1.Width - 1 || Y >= pictureBox1.Height - 1 || X < 0 || Y < 0) return;

            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush _SolidBrush = new SolidBrush(Wall);

            if (Item == 'P')
            {
                _SolidBrush.Color = Color.White;
                graph[(Y / height), (X / width)] = false;
            }
            else
            {
                _SolidBrush.Color = Wall;
                graph[(Y / height), (X / width)] = true;
            }
            g.FillRectangle(_SolidBrush, X + 1, Y + 1, height - 1, height - 1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
            timer1.Stop();
        }
    }
}