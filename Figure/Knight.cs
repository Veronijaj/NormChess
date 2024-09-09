using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Knight : Figure
    {
        public Knight(int x, int y, int color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public override List<List<(int, int)>> Move()
        {
            List<List<(int, int)>> moves = new List<List<(int, int)>>();
            int ind = 0;
            if (y > 1)
            {
                if (x > 0)
                {
                    moves.Add(new List<(int, int)>());
                    moves[ind].Add((x - 1, y - 2));
                    ind++;
                }
                if (x < 7)
                {
                    moves.Add(new List<(int, int)>());
                    moves[ind].Add((x + 1, y - 2));
                    ind++;
                }
            }
            if (y < 6)
            {
                if (x > 0)
                {
                    moves.Add(new List<(int, int)>());
                    moves[ind].Add((x - 1, y + 2));
                    ind++;
                }
                if (x < 7)
                {
                    moves.Add(new List<(int, int)>());
                    moves[ind].Add((x + 1, y + 2));
                    ind++;
                }
            }
            if (x > 1)
            {
                if (y > 0)
                {
                    moves.Add(new List<(int, int)>());
                    moves[ind].Add((x - 2, y - 1));
                    ind++;
                }
                if (y < 7)
                {
                    moves.Add(new List<(int, int)>());
                    moves[ind].Add((x - 2, y + 1));
                    ind++;
                }
            }
            if (x < 6)
            {
                if (y > 0)
                {
                    moves.Add(new List<(int, int)>());
                    moves[ind].Add((x + 2, y - 1));
                    ind++;
                }
                if (y < 7)
                {
                    moves.Add(new List<(int, int)>());
                    moves[ind].Add((x + 2, y + 1));
                }
            }
            return moves;
        }
    }
}
