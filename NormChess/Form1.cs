using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Match;

namespace NormChess
{
    public partial class Form1 : Form
    {
        public Image chessSprites;
        Match.Match map = new Match.Match();
        public Button[,] buttons = new Button[8, 8];
        Button? currButt = null;
        int move;
        public Form1()
        {
            InitializeComponent();
            chessSprites = new Bitmap("chess.png");
            Console.WriteLine(7);
            move = 0;
            CreateMap();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        public void CreateMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button butt = new Button();
                    butt.Size = new Size(50, 50);
                    butt.Location = new Point(i * 50, j * 50);
                    if (map[i, j] != null)
                    {
                        Image part = new Bitmap(50, 50);
                        Graphics g = Graphics.FromImage(part);
                        if (map[i, j] is Figure.Pawn)
                        {
                            if (map[i, j].Color == 0)
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (6 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (6 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            }
                        }
                        if (map[i, j] is Figure.Rook)
                        {
                            if (map[i, j].Color == 0)
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (5 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (5 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            }
                        }
                        if (map[i, j] is Figure.Knight)
                        {
                            if (map[i, j].Color == 0)
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (4 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (4 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            }
                        }
                        if (map[i, j] is Figure.Bishop)
                        {
                            if (map[i, j].Color == 0)
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (3 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (3 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            }
                        }
                        if (map[i, j] is Figure.Queen)
                        {
                            if (map[i, j].Color == 0)
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (2 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (2 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            }
                        }
                        if (map[i, j] is Figure.King)
                        {
                            if (map[i, j].Color == 0)
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (1 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            }
                            else
                            {
                                g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150 * (1 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            }
                        }
                        butt.BackgroundImage = part;
                    }
                    butt.Click += new EventHandler(ButtPress);
                    butt.BackColor = Color.White;
                    buttons[i, j] = butt;
                    this.Controls.Add(butt);
                }
            }
            DisActivate();
            Activate();
        }

        private void DisActivate()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j].Enabled = false;
                }
            }
        }
        public void Activate()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (map[i, j] != null)
                    {
                        if (map[i, j].Color == move) buttons[i, j].Enabled = true;
                    }
                }
            }
        }

        private void ButtPress(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            if (currButt == null)
            {
                int x = pressedButton.Location.X / 50;
                int y = pressedButton.Location.Y / 50;
                DisActivate();
                if (map[x, y] != null)
                {
                    pressedButton.Enabled = true;
                    pressedButton.BackColor = Color.Blue;
                    var l = map.ChooseMove(map[x, y]);
                    for (int i = 0; i < l.Count; i++)
                    {
                        buttons[l[i].Item1, l[i].Item2].Enabled = true;
                        buttons[l[i].Item1, l[i].Item2].BackColor = Color.Blue;
                    }
                }
                currButt = pressedButton;
            }
            else
            {
                currButt.BackColor = Color.White;
                int x = currButt.Location.X / 50;
                int y = currButt.Location.Y / 50;
                int x1 = pressedButton.Location.X / 50;
                int y1 = pressedButton.Location.Y / 50;
                var l = map.ChooseMove(map[x, y]);
                for (int i = 0; i < l.Count; i++)
                {
                    buttons[l[i].Item1, l[i].Item2].BackColor = Color.White;
                }
                if (currButt != pressedButton)
                {
                    pressedButton.BackgroundImage = currButt.BackgroundImage;
                    currButt.BackgroundImage = null;
                    map[x, y].Coordinates = (x1, y1);
                    map[x1, y1] = map[x, y];
                    map[x, y] = null;
                    if (move == 0) move = 1;
                    else move = 0;
                }
                DisActivate();
                Activate();
                currButt = null;
            }
        }

    }
}
