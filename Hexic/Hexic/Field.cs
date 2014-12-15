using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexic
{
    enum Color
    {
        RED,
        BLUE,
        GREEN,
        PURPLE,
        ORANGE,
        CYAN,
        YELLOW,
        MAGENTA,
        LIME,
        VIOLET
    }
    enum RotationType
    {
        Left,
        UpLeft,
        UpRight,
        Right,
        DownLeft,
        DownRight
    }
    enum Direction
    {
        CW,
        CCW
    }
    struct Rotation
    {
        public Tuple<int, int> point;
        public RotationType type;
        public Direction direction;
        public long score;
        public Rotation(Tuple<int, int> pt, RotationType newType, Direction newDirection, long x)
        {
            point = pt;
            type = newType;
            direction = newDirection;
            score = x;
        }
    }

    class Field
    {
        private int NumberOfColors = 6; // Should be from 1 to 10
        public int Height = 9;
        public int Width = 10;
        private Random random = new Random(1);
        public Color[,] field;
        public Field()
        {
            field = new Color[Height, Width];
            foreach (Tuple<int, int> number in GetEnumerator())
                {field[number.Item1, number.Item2] = (Color)(random.Next(NumberOfColors) + 1);}
        }
        public IEnumerable<Tuple<int, int> > GetEnumerator()
        {
            int i = 0;
            int j = 1;
            while (j < Width)
            {
                while (i < Height)
                {
                    yield return new Tuple<int, int>(i, j);
                    i += 2;
                }
                ++j;
                i = 0;
                if (j % 2 == 0)
                    {++i;}
            }
        }
        static void RotateCW(ref Color x, ref Color y, ref Color z)
        {
            Color tmp = z;
            z = x;
            x = y;
            y = tmp;
        }
        static void ChooseDirection(ref Color x, ref Color y, ref Color z, Direction direction)
        {
            RotateCW(ref x, ref y, ref z);
            if (direction == Direction.CCW)
                {RotateCW(ref x, ref y, ref z);}
        }

        public void Rotate(RotationType rotation, Direction direction, Tuple<int, int> point)
        {
            int x = point.Item1;
            int y = point.Item2;
            switch (rotation)
            {
                case RotationType.UpLeft:
                    if ((x > 1) && (y > 0) && (x < Height) && (y < Width))
                    {
                        ChooseDirection(ref field[x - 2, y], ref field[x - 1, y - 1], ref field[x, y], direction);
                    }
                    break;
                case RotationType.UpRight:
                    if ((x > 1) && (y >= 0) && (x < Height) && (y < Width - 1))
                    {
                        ChooseDirection(ref field[x, y], ref field[x - 1, y + 1], ref field[x - 2, y], direction);
                    }
                    break;
                case RotationType.Left:
                    if ((x > 1) && (y > 0) && (x < Height - 2) && (y < Width))
                    {
                        ChooseDirection(ref field[x + 1, y - 1], ref field[x, y], ref field[x - 1, y - 1], direction);
                    }
                    break;
                case RotationType.Right:
                    if ((x > 0) && (y >= 0) && (x < Height - 1) && (y < Width - 1))
                    {
                        ChooseDirection(ref field[x - 1, y + 1], ref field[x, y], ref field[x + 1, y + 1], direction);
                    }
                    break;
                case RotationType.DownLeft:
                    if ((x >= 0) && (y > 0) && (x < Height - 2) && (y < Width))
                    {
                        ChooseDirection(ref field[x, y], ref field[x + 1, y - 1], ref field[x + 2, y], direction);
                    }
                    break;
                case RotationType.DownRight:
                    if ((x >= 0) && (y >= 0) && (x < Height - 2) && (y < Width - 1))
                    {
                        ChooseDirection(ref field[x + 2, y], ref field[x + 1, y + 1], ref field[x, y], direction);
                    }
                    break;
                default:
                    break;
            }
        }
        public void Undo(RotationType rotationType, Direction direction, Tuple<int, int> point)
        {
            if(direction == Direction.CCW)
                Rotate(rotationType, Direction.CW, point);
            else
                Rotate(rotationType, Direction.CCW, point);
        }
        public void Fill()
        {
            foreach (Tuple<int, int> number in GetEnumerator())
            {
                if (field[number.Item1, number.Item2] == 0)
                {
                    int x = number.Item1;
                    while (x > 1)
                    {
                        field[x, number.Item2] = field[x - 2, number.Item2];
                        x -= 2;
                    }
                    field[x, number.Item2] = (Color)(random.Next(NumberOfColors) + 1);
                }
            }
        }
    }
}
