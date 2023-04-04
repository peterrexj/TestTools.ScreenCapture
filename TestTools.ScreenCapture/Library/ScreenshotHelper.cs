using Pj.Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestTools.ScreenCapture.Library
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(string filePath, Screen screen)
        {
            // Get the bounds of the primary screen
            Rectangle bounds = screen.Bounds;

            // Create a bitmap object to store the screenshot
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height);

            // Create a graphics object from the bitmap
            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                // Copy the contents of the screen to the bitmap
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            //Create folder if not exists
            IoHelper.CreateDirectory(filePath);

            // Save the screenshot to a file
            screenshot.Save(filePath);
        }
    }

}
