using System;
using BlogTutorials.iOS.Renderers;
using BlogTutorials.Views;
using CoreAnimation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CirclePathView), typeof(CirclePathRenderer))]
namespace BlogTutorials.iOS.Renderers
{
    public class CirclePathRenderer : ViewRenderer
    {
        private CAShapeLayer _layer;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            // Hook into the Action on the CirclePathView element
            if (e.NewElement != null)
            {
                ((CirclePathView)e.NewElement).CurrentProgressChanged = OnCurrentProgressChanged;
                e.NewElement.SizeChanged += Element_SizeChanged;
            }
            // If the old element exists, break that hook
            if (e.OldElement != null)
            {
                ((CirclePathView)e.OldElement).CurrentProgressChanged = null;
                e.OldElement.SizeChanged -= Element_SizeChanged;
            }
        }

        /// <summary>
        /// Called when the Element size changes. Useful for screen rotation
        /// and initial Draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Element_SizeChanged(object sender, EventArgs e)
        {
            Draw();
        }

        /// <summary>
        /// Hooked into the Element's Action that forces a view Redraw
        /// </summary>
        private void OnCurrentProgressChanged()
        {
            Draw();
        }

        /// <summary>
        /// Draws the path on the CAShapeLayer with respect to Current Progress
        /// </summary>
        private void Draw()
        {
            var view = Element as CirclePathView;
            var angle = (view.CurrentProgress / (view.MaxValue - view.MinValue)) * 2 * Math.PI;
            var path = UIBezierPath.FromArc(new CoreGraphics.CGPoint(Element.Width / 2, Element.Height / 2), (float)Element.Height / 2 - 10, 0, (float)angle, true);
            if (_layer != null)
            {
                _layer.RemoveFromSuperLayer();
            }
            _layer = new CAShapeLayer();
            _layer.Path = path.CGPath;
            _layer.StrokeColor = view.LineColor.ToCGColor();
            _layer.FillColor = Color.Transparent.ToCGColor();
            _layer.LineWidth = 10;
            Layer.AddSublayer(_layer);
        }
    }
}
