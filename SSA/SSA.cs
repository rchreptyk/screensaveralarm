using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSA
{
    class SSA
    {
        Alarm alarm;
        SoundPlayer armedPlayer;
        SystemTray systemTray;

        bool aPressed = false;
        bool sPressed = false;
        bool pressed = false;

        public SSA(Alarm alarm, SoundPlayer armedPlayer)
        {
            this.alarm = alarm;
            this.armedPlayer = armedPlayer;
            systemTray = new SystemTray();

            systemTray.HideWindow();
            Hook.GlobalEvents().KeyDown += GlobalHook_KeyDown;
            Hook.GlobalEvents().KeyUp += SSA_KeyUp;
            systemTray.SetIcon("SSA", SystemIcons.Application);
            systemTray.AddMenuItem("Exit", Exit);
            systemTray.AddMenuItem("Toggle Alarm", ToggleAlarm);
        }

        private void SSA_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                aPressed = false;

            if (e.KeyCode == Keys.S)
                sPressed = false;

            if (pressed)
            {
                pressed = false;
                ToggleAlarm();
            } 
        }

        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                aPressed = true;

            if (e.KeyCode == Keys.S)
                sPressed = true;

            if(!pressed && e.Control && e.Alt && aPressed && sPressed)
            {
                Console.WriteLine("Flipping pressed");
                pressed = true;
                e.Handled = true;
            }
        }

        private void ToggleAlarm()
        {
            if (alarm.Active)
            {
                Console.WriteLine("Deactivated Alarm");
                alarm.Deactivate();
            }
            else
            {
                armedPlayer.Play();
                Console.WriteLine("Alarm Activated");
                alarm.Activate();
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            if (systemTray.Authenticate())
                Application.Exit();
        }

        private void ToggleAlarm(object sender, EventArgs e)
        {
            if (systemTray.Authenticate())
                ToggleAlarm();
        }
    }
}
