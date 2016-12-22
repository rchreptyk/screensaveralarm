using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Old Volume");
            Console.ReadLine();
            using (new MaximumVolume())
            {
                Console.WriteLine("MAX Volume");
                Console.ReadLine();
            }
            Console.WriteLine("Old Volume");
        }
    }
}
