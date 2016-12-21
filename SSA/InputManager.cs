using Gma.System.MouseKeyHook;
using System.Windows.Forms;

namespace SSA
{
    class InputManager
    {

        private IKeyboardMouseEvents m_GlobalHook;

        public InputManager()
        {
            m_GlobalHook = null;
        }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            //create event handlers
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            //DO SOMETHING ON KEY PRESS
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            //DO SOMETHING ON MOUSE CLICK
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
