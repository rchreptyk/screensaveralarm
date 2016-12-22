using Gma.System.MouseKeyHook;
using System;
using System.Windows.Forms;

namespace SSA
{
    class InputManager
    {

        

        public InputManager()
        {
            m_GlobalHook = null;
            initialXMouseLocation = 0;
            initialYMouseLocation = 0;
            isLocationSet = false;
    }

        public void Subscribe()
        {
            
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            //DO SOMETHING ON KEY PRESS
        }

        

        public void Unsubscribe()
        {
            //remove event handlers
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;

            //It is recommeneded to dispose it
            m_GlobalHook.Dispose();
        }

    }
}
