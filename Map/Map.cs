
using System.Drawing;

namespace Map
{
    public class Map<T>
    {
        private T[,] data;
        private int height;
        private int width;
        public Map()
        {
            height = 8;
            width = 8;
            data = new T[height, width];
        }

        public (int, int) Size
        {
            get { return (width, height); }
        }
        public T this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }

        }

    }
}
