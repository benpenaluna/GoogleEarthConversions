using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public static class ColorComparison
    {
        public static string ColorHexValue(this System.Drawing.Color color)
        {
            return color.A.ToString("X2").ToLower() + color.R.ToString("X2").ToLower() +
                   color.G.ToString("X2").ToLower() + color.B.ToString("X2").ToLower();
        }
    }
}
