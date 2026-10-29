using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittlePlanete
{
    internal class Couleur
    {
        private static Color background = Color.FromArgb(250, 245, 255);
        private static Color text = Color.FromArgb(26, 10, 60);
        private static Color button = Color.FromArgb(168, 85, 247);
        private static Color button_hover = Color.FromArgb(124, 58, 237);
        private static bool darkTheme = false;

        public static void SwitchTheme()
        {
            darkTheme = !darkTheme;
            if (darkTheme)
            {
                background = Color.FromArgb(26, 10, 60);
                text = Color.FromArgb(184, 78, 255);
                button = Color.FromArgb(46, 16, 101);
                button_hover = Color.FromArgb(250, 245, 255);
            }
            else
            {
                background = Color.FromArgb(250, 245, 255);
                text = Color.FromArgb(26, 10, 60);
                button = Color.FromArgb(168, 85, 247);
                button_hover = Color.FromArgb(124, 58, 237);
            }
        }

        public static Color getBackground
        {
            get { return background; }
        }

        public static Color getText
        { get { return text; } }

        public static Color getButton
        { get { return button; } }
        public static Color getButtonHover
        { get { return button_hover; } }
    }
}
