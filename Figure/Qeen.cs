using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Queen : Figure
    {
        public Queen(int x, int y, int color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public override List<List<(int, int)>> Move()
        {
            List<List<(int, int)>> moves = new List<List<(int, int)>>();
            int ind = -1;
            for (int i = x - 1; i >= 0; --i)
            {
                if (i == x - 1)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                }
                moves[ind].Add((i, y));
            }
            for (int i = x + 1; i < 8; ++i)
            {
                if (i == x + 1)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                }
                moves[ind].Add((i, y));
            }
            for (int i = y - 1; i >= 0; --i)
            {
                if (i == y - 1)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                }
                moves[ind].Add((x, i));
            }
            for (int i = y + 1; i < 8; ++i)
            {
                if (i == y + 1)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                }
                moves[ind].Add((x, i));

            }
            int j = 0;
            while (x - j > 0 && y - j > 0)
            {
                if (j == 0)
                {
                    ind++;
                    moves.Add(new List<(int, int)>());
                }
                j++;
                moves[ind].Add((x - j, y - j));
            }
            j = 0;
            while (x + j < 7 && y + j < 7)
            {
                if (j == 0)
                {
                    ind++;
                    moves.Add(new List<(int, int)>());
                }
                j++;
                moves[ind].Add((x + j, y + j));
            }
            j = 0;
            while (x - j > 0 && y + j < 7)
            {
                if (j == 0)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                }
                j++;
                moves[ind].Add((x - j, y + j));
            }
            j = 0;
            while (x + j < 7 && y - j > 0)
            {
                if (j == 0)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                }
                j++;
                moves[ind].Add((x + j, y - j));
            }
            return moves;
        }
    }
}
