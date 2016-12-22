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
            //TESTING PURPOSES//
            InputManager im = new InputManager();
            im.Subscribe();
            ScreenManager sm = new ScreenManager();
            Form form = new Form();
            form.BackgroundImage = sm.getScreenshot();
            form.Size = new Size(500, 500);
            form.ShowDialog();

        }
    }
}
