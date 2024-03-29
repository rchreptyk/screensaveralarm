﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gma.System.MouseKeyHook;

namespace SSA
{
    class MouseListener
    {
        private IKeyboardMouseEvents m_GlobalHook;

        private int initialXMouseLocation;
        private int initialYMouseLocation;
        private bool isLocationSet;

        public MouseListener()
        {
            m_GlobalHook = Hook.GlobalEvents();
            //create event handlers
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.MouseMoveExt += GlobalHookMouseMove;
        }

        public void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            //DO SOMETHING ON MOUSE CLICK
        }

        public void GlobalHookMouseMove(object sender, MouseEventExtArgs e)
        {
            //set initial mouse location
            initialXMouseLocation = isLocationSet ? initialXMouseLocation : e.X;
            initialYMouseLocation = isLocationSet ? initialYMouseLocation : e.Y;
            isLocationSet = true;

            if (e.X > (initialXMouseLocation + 300) || e.Y > (initialYMouseLocation + 300))
            {
                //DO SOMETHING ON MOUSE MOVEMENT
            }

        }

    }
}
