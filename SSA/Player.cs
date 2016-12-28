using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SSA
{
    class Player : SoundPlayer
    {
        public String name;

        public Player(string name)
        {
            this.name = name;
        }

    }
}
