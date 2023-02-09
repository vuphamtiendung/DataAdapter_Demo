using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ExerciseADO_002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAdapter_003 data = new DataAdapter_003();
            data.Adapter();
            ReadLine();
        }
    }
}
