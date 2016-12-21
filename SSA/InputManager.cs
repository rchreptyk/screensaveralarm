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

            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            //DO SOMETHING
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            //DO SOMETHING
        }

        public void Unsubscribe()
        {
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;

            //It is recommeneded to dispose it
            m_GlobalHook.Dispose();
        }

    }
}
