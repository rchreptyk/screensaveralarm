using Gma.System.MouseKeyHook;

namespace SSA
{
    class MouseAndKeyboard
    {
        private IKeyboardMouseEvents m_GlobalHook;
        public delegate void MouseMovedEventHandler();
        public delegate void KeyPressedEventHandler();
        public delegate void MouseClickedEventHandler();
        public delegate void DoubleMouseClickedEventHandler();
        public event MouseMovedEventHandler MouseMoved;
        public event KeyPressedEventHandler KeyPressed;
        public event MouseClickedEventHandler MouseClicked;
        public event DoubleMouseClickedEventHandler DoubleMouseClicked;

        private int initialXMouseLocation;
        private int initialYMouseLocation;
        private bool isLocationSet;

        public MouseAndKeyboard()
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
            m_GlobalHook.MouseClick += M_GlobalHook_MouseClick;
            m_GlobalHook.MouseDoubleClick += M_GlobalHook_MouseDoubleClick;
            m_GlobalHook.KeyPress += M_GlobalHook_KeyPress;
        }

        private void M_GlobalHook_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            OnDoubleMouseClicked();
        }

        private void M_GlobalHook_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            OnMouseClicked();
        }

        private void M_GlobalHook_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            OnKeyPressed();
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

        protected virtual void OnKeyPressed()
        {
            KeyPressed?.Invoke();
        }

        protected virtual void OnMouseMoved()
        {
            MouseMoved?.Invoke();
        }
        protected virtual void OnMouseClicked()
        {
            MouseClicked?.Invoke();
        }

        protected virtual void OnDoubleMouseClicked()
        {
            DoubleMouseClicked?.Invoke();
        }



    }
}
