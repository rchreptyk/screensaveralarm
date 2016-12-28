using System;
using System.Drawing;
using Pranas;

namespace SSA
{
    class Screen
    {

        private Image mainScreenImage;
        private ScreenShot screenshot;

        public Screen()
        {
            mainScreenImage = null;
            screenshot = new ScreenShot();
        }

        public Image GetScreenshot()
        {
            try
            {
                //take screenshot and replace main screen image
                mainScreenImage = screenshot.CaptureMainScreen();
                //return image
                return mainScreenImage;
            }
            catch (Exception e)
            {
                Console.WriteLine("ScreenManager.getScreenshot() Error: " + e.Message);
                return null;
            }
        }

    }
}
