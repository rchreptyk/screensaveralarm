using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSA
{
    public partial class ImageViewer : Form
    {
        /// <summary>
        /// Creates a window that displays an image full screen
        /// </summary>
        /// <param name="image">The image to show</param>
        public ImageViewer(Image image)
        {
            InitializeComponent();
            BackgroundImage = image;
        }
    }
}
