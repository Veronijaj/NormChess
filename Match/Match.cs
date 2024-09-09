using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figure;
using System.Data;
using System.Timers;

namespace Match
{
    public class Match
    {
        public Map.Map<Figure.Figure?> desk;

        public Match()
        {
            desk = new Map.Map<Figure.Figure?>();
            for (int i = 0; i < 8; i++)
            {
                desk[i, 1] = new Figure.Pawn(i, 1, 1);
                desk[i, 6] = new Figure.Pawn(i, 6, 0);
            }
            desk[0, 0] = new Figure.Rook(0, 0, 1);
            desk[7, 0] = new Figure.Rook(7, 0, 1);
            desk[0, 7] = new Figure.Rook(0, 7, 0);
            desk[7, 7] = new Figure.Rook(7, 7, 0);

            desk[1, 0] = new Figure.Knight(1, 0, 1);
            desk[6, 0] = new Figure.Knight(6, 0, 1);
            desk[1, 7] = new Figure.Knight(1, 7, 0);
            desk[6, 7] = new Figure.Knight(6, 7, 0);

            desk[2, 0] = new Figure.Bishop(2, 0, 1);
            desk[5, 0] = new Figure.Bishop(5, 0, 1);
            desk[2, 7] = new Figure.Bishop(2, 7, 0);
            desk[5, 7] = new Figure.Bishop(5, 7, 0);

            desk[3, 0] = new Figure.Queen(3, 0, 1);
            desk[3, 7] = new Figure.Queen(3, 7, 0);

            desk[4, 0] = new Figure.King(4, 0, 1);
            desk[4, 7] = new Figure.King(4, 7, 0);

        }
        public Figure.Figure? this[int i, int j]
        {
            get { return desk[i, j]; }
            set { desk[i, j] = value; }
        }

        private List<(int, int)>? CheckCorrect(Figure.Figure f, List<(int, int)> l)
        {
            if (f is Figure.Pawn)
            {
                if (l[0].Item1 == f.Coordinates.Item1)
                {
                    for (int i = 0; i < l.Count; i++)
                    {
                        if (this[l[i].Item1, l[i].Item2] != null)
                        {
                            l.RemoveRange(i, l.Count - i);
                            return l;
                        }
                    }
                }
                else
                {
                    if (f.Color == 0)
                    {
                        if (this[l[0].Item1, l[0].Item2] == null || this[l[0].Item1, l[0].Item2].Color != 1) return null;
                    }
                    if (f.Color == 1)
                    {
                        if (this[l[0].Item1, l[0].Item2] == null || this[l[0].Item1, l[0].Item2].Color != 0) return null;
                    }
                }
            }
            for (int i = 0; i < l.Count; i++)
            {
                Figure.Figure? tmp = desk[l[i].Item1, l[i].Item2];
                if (tmp != null && tmp.Color != f.Color)
                {
                    if (i + 1 < l.Count)
                    {
                        l.RemoveRange(i + 1, l.Count - i - 1);
                        break;
                    }
                }
                if (tmp != null && tmp.Color == f.Color)
                {
                    l.RemoveRange(i, l.Count - i);
                    break;
                }
            }
            return l;
        }
        public List<(int, int)> ChooseMove(Figure.Figure f)
        {
            List<(int, int)> ans = new List<(int, int)>();
            List<List<(int, int)>> tmp = f.Move();
            for (int i = 0; i < tmp.Count; ++i)
            {
                if (CheckCorrect(f, tmp[i]) != null)
                {
                    ans.AddRange(tmp[i]);
                }
            }
            return ans;
        }
    }
}

