using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hexic;

namespace Hexic
{
    class Player
    {
        Field field;
        HashSet<Tuple<int, int> > currentCluster = new HashSet<Tuple<int, int> >();
        public Player(Field newField)
        {
            field = newField;
        }
        public long Play()
        {
            CountCascade();
            Rotation bestMove = new Rotation();
            long score = 0;
            do
            {
                bestMove = new Rotation();
                long currentScore = 0;
                foreach (Tuple<int, int> hex in field.GetEnumerator())
                    foreach (RotationType rotationType in Enum.GetValues(typeof(RotationType)))
                        foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                        {
                            field.Rotate(rotationType, direction, hex);
                            currentScore = SearchOneColor(hex);
                            if (currentScore > bestMove.score)
                                { bestMove = new Rotation(hex, rotationType, direction, currentScore); }
                            field.Undo(rotationType, direction, hex);
                        }
                if (bestMove.score != 0)
                {
                    field.Rotate(bestMove.type, bestMove.direction, bestMove.point);
                    score += MakeMove(bestMove.point);
                }
            } while (bestMove.score != 0);
            return score;
        }

        public long MakeMove(Tuple<int, int> hex)
        {
            currentCluster.Clear();
            return SearchOneColor(hex) + CountCascade();
        }

        private long CountCascade()
        {
            long score = 0;
            do
            {
                foreach (Tuple<int, int> hex in currentCluster)
                    {field.field[hex.Item1, hex.Item2] = 0;}
                currentCluster.Clear();
                field.Fill();
                foreach (Tuple<int, int> hex in field.GetEnumerator())
                    {score += SearchOneColor(hex);}
            } while (currentCluster.Count != 0);
            return score;
        }

        private bool TryToAdd(Tuple<int, int> x, Tuple<int, int> y, Tuple<int, int> z, Queue<Tuple<int, int> > hexesToCheck)
        {
            if (y.Item1 >= 0 && x.Item1 >= 0 && z.Item1 >= 0 && y.Item2 >= 0 && x.Item2 >= 0 && z.Item2 >= 0 
                && y.Item1 < field.Height && x.Item1 < field.Height && z.Item1 < field.Height 
                && y.Item2 < field.Width && x.Item2 < field.Width && z.Item2 < field.Width 
                && field.field[x.Item1, x.Item2] == field.field[y.Item1, y.Item2] 
                && field.field[x.Item1, x.Item2] == field.field[z.Item1, z.Item2])
                {
                    currentCluster.Add(x);

                    if (!currentCluster.Contains(y))
                    {
                        hexesToCheck.Enqueue(y);
                        currentCluster.Add(y);
                    }
                    if (!currentCluster.Contains(z))
                    {
                        hexesToCheck.Enqueue(z);
                        currentCluster.Add(z);
                    }
                    return true;
                }
            return false;
        }
        public long SearchOneColor(Tuple<int, int> hex)
        {
            Queue<Tuple<int, int>> hexesToCheck = new Queue<Tuple<int, int>>();
            int score = 0;
            hexesToCheck.Enqueue(hex);
            while (hexesToCheck.Count != 0)
            {
                Tuple<int, int> current = hexesToCheck.Dequeue();
                Tuple<int, int>[] neighbourHexes = new Tuple<int, int>[6] 
                {new Tuple<int, int> (current.Item1 - 1, current.Item2 - 1), 
                 new Tuple<int, int> (current.Item1 - 2, current.Item2), 
                 new Tuple<int, int> (current.Item1 - 1, current.Item2 + 1), 
                 new Tuple<int, int> (current.Item1 + 1, current.Item2 + 1), 
                 new Tuple<int, int> (current.Item1 + 2, current.Item2),
                 new Tuple<int, int> (current.Item1 + 1, current.Item2 - 1)};

                for (int i = 0; i < 6; ++i)
                {
                    if (TryToAdd(current, neighbourHexes[i % 6], neighbourHexes[(i + 1) % 6], hexesToCheck))
                    {
                        score++;
                        break;
                    }
                }
            }
            return (long)Math.Pow(2, (score - 2)) * 3;
        }
    }
}
