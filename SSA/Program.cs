using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SSA
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new SSA(new Alarm(new SoundPlayer(Properties.Resources.alarm)), new SoundPlayer(Properties.Resources.arming));

            Application.Run();
        }
    }
}
