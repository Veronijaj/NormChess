

using System.Collections.Generic;

namespace Figure
{
    public class Rook : Figure
    {
        public Rook(int x, int y, int color) : base(x, y, color)
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
                if (i == x-1)
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
            return moves;
        }
    }
}
