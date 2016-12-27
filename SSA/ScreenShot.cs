using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SSA
{
    class ScreenShot
    {

        public ScreenShot()
        {
        }

        public Bitmap CaptureMainScreen()
        {
            int screenWidth = (int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width);
            int screenHeight = (int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height);
            Bitmap bmp_with_actual_resolution = new Bitmap(screenWidth, screenHeight);
            Graphics g = Graphics.FromImage(bmp_with_actual_resolution);
            g.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
            return bmp_with_actual_resolution;
        }

    }
}
