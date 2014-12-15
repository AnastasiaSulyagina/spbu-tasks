using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexic
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();
            Player player = new Player(field);
            System.Console.WriteLine(player.Play());
            return;
        }
    }
}
