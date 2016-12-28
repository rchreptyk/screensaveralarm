using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSA
{
    class Tray
    {

        public Tray()
        {
            CreateIcon("SSA", SystemIcons.Application);
        }

        private void CreateIcon(string name, Icon icon)
        {
            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Text = name;
            trayIcon.Icon = new Icon(icon, 40, 40);
        }

    }
}
