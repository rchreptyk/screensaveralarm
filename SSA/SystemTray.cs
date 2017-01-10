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
            masterPassword = "playstation10";
        }

        //default icon to use this with: SystemIcons.Application
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

        private void Exit(object sender, EventArgs e)
        {
            
                Application.Exit();
        }





    }
}
