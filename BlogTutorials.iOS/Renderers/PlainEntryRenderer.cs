using System;
using BlogTutorials.Controls;
using BlogTutorials.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PlainEntry), typeof(PlainEntryRenderer))]
namespace BlogTutorials.iOS.Renderers
{
    public class PlainEntryRenderer : EntryRenderer
    {
        public PlainEntryRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}
