using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Figure
    {
        protected int x;
        protected int y;
        protected int color;

        public Figure(int x, int y, int color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        protected bool CkeckMove(int _x, int _y)
        {
            if (_x >= 0 && _x < 8 && _y >= 0 && _y < 8) return true;
            return false;
        }
        public virtual List<List<(int, int)>> Move()
        {
            List<List<(int, int)>> moves = new List<List<(int, int)>>();
            moves.Add(new List<(int, int)>());
            return new List<List<(int, int)>>();
        }
        public (int, int) Coordinates
        {
            get { return (x, y); }
            set
            {
                x = value.Item1;
                y = value.Item2;
            }
        }
        public int Color
        {
            get
            {
                return color;
            }
        }
    }
}
