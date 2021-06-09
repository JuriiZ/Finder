using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Finder.Services
{
    public static class Helper
    {
        public static async Task AnimationSVG(SvgCachedImage svg, uint speed)
        {
            await svg.ScaleTo(0.95, speed);
            await svg.ScaleTo(1, speed);
        }

        public static async Task AnimationView(View view, uint speed)
        {
            await view.ScaleTo(0.95, speed);
            await view.ScaleTo(1, speed);
        }
    }
}
