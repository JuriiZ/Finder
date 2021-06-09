using Finder.iOS.CustomRenders;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer_IOS))]
namespace Finder.iOS.CustomRenders
{
    class CustomEntryRenderer_IOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                NativeView.BackgroundColor = UIColor.FromRGBA(0, 255, 255, 1);
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}