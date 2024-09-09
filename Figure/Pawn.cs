using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Pawn : Figure
    {
        public Pawn(int x, int y, int color) : base(x, y, color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public override List<List<(int, int)>> Move()
        {
            List<List<(int, int)>> moves = new List<List<(int, int)>>();
            moves.Add(new List<(int, int)>());
            int ind = 0;
            if (y > 0 && color == 0)
            {
                moves[0].Add((x, y - 1));
                if(y==6) moves[0].Add((x, y - 2));
                if (x > 0)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                    moves[ind].Add((x - 1, y - 1));
                }
                if (x < 7)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                    moves[ind].Add((x + 1, y - 1));
                }
            }
            if (y < 7 && color == 1)
            {
                moves[0].Add((x, y + 1));
                if (y == 1) moves[0].Add((x, y + 2));
                if (x > 0)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                    moves[ind].Add((x-1, y + 1));
                }
                if (x < 7)
                {
                    moves.Add(new List<(int, int)>());
                    ind++;
                    moves[ind].Add((x + 1, y + 1));
                }
            }
            
            return moves;
        }
    }
}
