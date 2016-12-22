using Gma.System.MouseKeyHook;
using System;
using System.Windows.Forms;

namespace SSA
{
    class InputManager
    {

        private IKeyboardMouseEvents m_GlobalHook;
        private int initialXMouseLocation;
        private int initialYMouseLocation;
        private bool isLocationSet;

        public InputManager()
        {
            m_GlobalHook = null;
            initialXMouseLocation = 0;
            initialYMouseLocation = 0;
            isLocationSet = false;
    }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            //create event handlers
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
            m_GlobalHook.MouseMoveExt += GlobalHookMouseMove;
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            //DO SOMETHING ON KEY PRESS
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            //DO SOMETHING ON MOUSE CLICK
        }

        private void GlobalHookMouseMove(object sender, MouseEventExtArgs e)
        {
            //set initial mouse location
            initialXMouseLocation = isLocationSet ? initialXMouseLocation : e.X;
            initialYMouseLocation = isLocationSet ? initialYMouseLocation : e.Y;
            isLocationSet = true;

            if (e.X == (initialXMouseLocation + 300) || e.Y == (initialYMouseLocation + 300))
            {
                //DO SOMETHING WHEN MOUSE MOVES
            }

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
