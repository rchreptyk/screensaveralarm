using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;

namespace SSA
{
    class Mouse
    {

        public event MouseEventHandler MouseMoved;

        public Mouse()
        {
            
        }

        public void onMouseMoved()
        {
            MouseMoved?.Invoke(this, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
        }

        public void handleMouseMoved(object sender, MouseEventExtArgs e)
        {
            MessageBox.Show("MOUSE MOVED");
        }


    }
}
