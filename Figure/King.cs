using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class King : Figure
    {
        public King(int x, int y, int color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public override List<List<(int, int)>> Move()
        {
            List<List<(int, int)>> moves = new List<List<(int, int)>>();
            int ind = 0;
            if (x > 0)
            {
                moves.Add(new List<(int, int)>());
                moves[ind].Add((x - 1, y));
                ind++;
            }
            if (x < 7)
            {
                moves.Add(new List<(int, int)>());
                moves[ind].Add((x + 1, y));
                ind++;
            }
            if (y < 7)
            {
                moves.Add(new List<(int, int)>());
                moves[ind].Add((x, y + 1));
                ind++;
            }
            if (y > 0)
            {
                moves.Add(new List<(int, int)>());
                moves[ind].Add((x, y - 1));
                ind++;
            }
            if (x > 0 && y > 0)
            {
                moves.Add(new List<(int, int)>());
                moves[ind].Add((x - 1, y - 1));
                ind++;
            }
            if (x < 7 && y < 7)
            {
                moves.Add(new List<(int, int)>());
                moves[ind].Add((x + 1, y + 1));
                ind++;
            }
            if (x > 0 && y < 7)
            {
                moves.Add(new List<(int, int)>());
                moves[ind].Add((x - 1, y + 1));
                ind++;
            }
            if (x < 7 && y > 0)
            {
                moves.Add(new List<(int, int)>());
                moves[ind].Add((x + 1, y - 1));
                ind++;
            }
            return moves;
        }
    }
}
