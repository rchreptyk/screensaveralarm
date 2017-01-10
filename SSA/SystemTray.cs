using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace SSA
{
    class SystemTray
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        NotifyIcon trayIcon;
        ContextMenu trayMenu;
        string masterPassword;
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public SystemTray()
        {
            trayIcon = new NotifyIcon();
            masterPassword = "playstation10";
        }

        //default icon to use this with (preferably): SystemIcons.Application
        public void SetIcon(string title, Icon icon)
        {
            trayIcon.Text = title;
            trayIcon.Icon = new Icon(icon, 40, 40);
            trayMenu = new ContextMenu();
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        public void AddMenuItem(string title, EventHandler eventHandler)
        {
            trayMenu.MenuItems.Add(title, eventHandler);
            trayIcon.ContextMenu = trayMenu;
        }

        public void RemoveMenuItem(string title)
        {
            trayMenu.MenuItems.Remove(trayMenu.MenuItems[title]);
        }

        public bool Authenticate()
        {
            if (Interaction.InputBox("Password?", "PASSWORD", "").Equals(masterPassword))
                return true;
            else
                return false;
        }

        public void HideWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }

        public void ShowWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
        }
    }
}
