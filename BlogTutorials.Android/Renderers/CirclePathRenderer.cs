using System;
using Android.Content;
using Android.Graphics;
using BlogTutorials.Droid.Renderers;
using BlogTutorials.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CirclePathView), typeof(CirclePathRenderer))]
namespace BlogTutorials.Droid.Renderers
{
    public class CirclePathRenderer : ViewRenderer
    {
        public CirclePathRenderer(Context context) : base(context)
        {
            // Allow the view to call the Draw method
            SetWillNotDraw(false);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            // Hook into the Action on the CirclePathView element
            if (e.NewElement != null)
                ((CirclePathView)e.NewElement).CurrentProgressChanged = OnCurrentProgressChanged;
            // If the old element exists, break that hook
            if (e.OldElement != null)
                ((CirclePathView)e.OldElement).CurrentProgressChanged = null;
        }

        private void OnCurrentProgressChanged()
        {
            // force a redraw
            Invalidate();
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            // Create the paint that we'll use to draw the line
            var paint = new Paint();
            paint.SetStyle(Paint.Style.Stroke);
            // Set its width from DP. This will help with varying screen densities
            var pathWidth = Context.ToPixels(10);
            paint.StrokeWidth = pathWidth;
            // Set the color based on the Element's property
            paint.Color = ((CirclePathView)Element).LineColor.ToAndroid();
            var view = Element as CirclePathView;
            // Get the difference between min and max
            var span = view.MaxValue - view.MinValue;
            // then calculate the percentage of current vs that span.
            var progressPercent = view.CurrentProgress / span;
            // With all that accounted for, we can draw the arc of the Radial Gauge
            canvas.DrawArc(pathWidth, pathWidth, canvas.Width - pathWidth, canvas.Height - pathWidth, 0, (float)(360f * progressPercent), false, paint);
        }
    }
}
