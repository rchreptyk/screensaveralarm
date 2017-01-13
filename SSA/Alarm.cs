using System;
using System.Media;
using System.Windows.Forms;

namespace SSA
{
    class Alarm
    {
        bool active = false;
        bool triggered = false;
        
        ScreenShot screenshot = new ScreenShot();

        SoundPlayer player;
        MaximumVolume maxVolume = null;
        MouseAndKeyboard mouseAndKeyboard = new MouseAndKeyboard();
        ImageViewer viewer = null;

        Timer activateTimer = new Timer();

        public Alarm(SoundPlayer player)
        {
            this.player = player;
            mouseAndKeyboard.Subscribe();

            activateTimer.Interval = 250;
            activateTimer.Tick += Timer_Tick;
        }

        public void Deactivate()
        {
            if (!active)
                return;

            active = false;

            /* Tear down */

            activateTimer.Stop();
            player.Stop();
            viewer.Close();
            maxVolume?.Revert();

            triggered = false;
            unsubscribe();
        }

        public void Activate()
        {
            if (active)
                return;

            /*  Setup */

            var image = screenshot.CaptureMainScreen();
            viewer = new ImageViewer(image);
            viewer.Show();

            activateTimer.Start();

            active = true;
            triggered = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            activateTimer.Stop();
            subscribe();
        }

        public bool Active
        {
            get { return active; }
        }

        private void Trigger()
        {
            if (triggered)
                return;

            triggered = true;

            maxVolume = new MaximumVolume();
            player.PlayLooping();
            unsubscribe();
        }

        private void unsubscribe()
        {
            mouseAndKeyboard.KeyPressed -= Trigger;
            mouseAndKeyboard.MouseClicked -= Trigger;
            mouseAndKeyboard.MouseMoved -= Trigger;
            mouseAndKeyboard.DoubleMouseClicked -= Trigger;
        }

        private void subscribe()
        {
            mouseAndKeyboard.KeyPressed += Trigger;
            mouseAndKeyboard.MouseClicked += Trigger;
            mouseAndKeyboard.MouseMoved += Trigger;
            mouseAndKeyboard.DoubleMouseClicked += Trigger;
        }
    }
}
