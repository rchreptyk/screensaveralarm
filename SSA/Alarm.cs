using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace SSA
{
    class Alarm
    {
        Player currentlySelectedSound;
        List<Player> playerList;

        public Alarm()
        {
            currentlySelectedSound = null;
            playerList = new List<Player>();
        }

        public void PlayLastAddedAlarm()
        {
            playerList[playerList.Count - 1].Load();
            playerList[playerList.Count - 1].Play();
        }

        public void AddAlarm(string path, string name)
        {
            Player player = new Player(name);
            player.SoundLocation = path;
            currentlySelectedSound = player;
            playerList.Add(player);

        }

        private void PlaySound(Player player)
        {
            player.Load();
            player.Play();
        }

        public void PlayAllAlarms()
        {
            foreach (Player player in playerList)
            {
                Thread t = new Thread(new ThreadStart(() => PlaySound(player)));
                t.Start();
            }
        }

        public void StopAllAlarms()
        {
            foreach (Player alarm in playerList)
            {
                alarm.Stop();
            }
        }

        public void PlayAlarm(string name)
        {
            foreach (Player alarm in playerList)
            {
                if (alarm.name.Equals(name))
                {
                    currentlySelectedSound = alarm;
                    Thread t = new Thread(new ThreadStart(() => PlaySound(alarm)));
                    t.Start();
                }
            }
        }




    }
}
