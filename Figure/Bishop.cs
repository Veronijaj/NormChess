using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Bishop : Figure
    {
        public Bishop(int x, int y, int color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public override List<List<(int, int)>> Move()
        {
            List<List<(int, int)>> moves = new List<List<(int, int)>>();
            int j = 0;
            int ind = -1;
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
