using System;
using System.Drawing;
using Pranas;

namespace SSA
{
    class Screen
    {

        private Image mainScreenImage;

        public Screen()
        {
            mainScreenImage = null;
        }

        public Image getScreenshot()
        {
            try
            {
                //take screenshot and replace main screen image
                mainScreenImage = ScreenshotCapture.TakeScreenshot();
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
