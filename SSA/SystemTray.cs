using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SSA
{
    class SystemTray
    {
        NotifyIcon trayIcon;
        ContextMenu trayMenu;
        string masterPassword;

        public SystemTray()
        {
            trayIcon = new NotifyIcon();
            SetIcon("SSA", SystemIcons.Application);
            masterPassword = "playstation10";
        }

        //default icon to use this with: SystemIcons.Application
        private void SetIcon(string title, Icon icon)
        {
            trayIcon.Text = title;
            trayIcon.Icon = new Icon(icon, 40, 40);
            trayMenu = new ContextMenu();
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            AddMenuItem("Exit", Exited());
        }

        private void AddMenuItem(string title, EventHandler eventHandler)
        {
            trayMenu.MenuItems.Add(title, eventHandler);
            trayIcon.ContextMenu = trayMenu;
        }

        private void RemoveMenuItem(string title)
        {
            trayMenu.MenuItems.Remove(trayMenu.MenuItems[title]);
        }

        private EventHandler Exited()
        {
            return new EventHandler(Exit);
        }

        private void Exit(object sender, EventArgs e)
        {
            if (Interaction.InputBox("Password?", "PASSWORD", "").Equals(masterPassword))
                Application.Exit();
        }





    }
}
