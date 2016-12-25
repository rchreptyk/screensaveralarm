using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSA
{
    class Mouse
    {
        private IKeyboardMouseEvents m_GlobalHook;
        public delegate void MouseMovedEventHandler();
        public event MouseMovedEventHandler MouseMoved;

        private int initialXMouseLocation;
        private int initialYMouseLocation;
        private bool isLocationSet;

        public Mouse()
        {
            //initialize variables
            initialXMouseLocation = 0;
            initialYMouseLocation = 0;
            isLocationSet = false;

            m_GlobalHook = Hook.GlobalEvents();
        }

        public void Subscribe()
        {
            m_GlobalHook.MouseMoveExt += M_GlobalHook_MouseMoveExt;
        }

        private void M_GlobalHook_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            //set initial x and y coordinates
            initialXMouseLocation = isLocationSet ? initialXMouseLocation : e.X;
            initialYMouseLocation = isLocationSet ? initialYMouseLocation : e.Y;
            isLocationSet = true;

            //check if mouse moved a significant distance, if it did, trigger event
            if (initialXMouseLocation > e.X + 200 || initialYMouseLocation > e.Y + 200 || initialXMouseLocation < e.X - 200 || initialYMouseLocation < e.Y - 200)
                OnMouseMoved();
        }

        protected virtual void OnMouseMoved()
        {
            MouseMoved?.Invoke();
        }


    }
}
