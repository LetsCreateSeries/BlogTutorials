using System;
using BlogTutorials.Behaviors.Base;
using Xamarin.Forms;

namespace BlogTutorials.Behaviors
{
    public class ScaleForScrollViewBehavior : ScrollViewObserverBase
    {
        /// <summary>
        /// The initial scale of the Visual Element
        /// </summary>
        private double _startScale;
        /// <summary>
        /// The difference between start scale and end scale
        /// </summary>
        private double _scaleAmount;

        public static readonly BindableProperty EndScaleProperty = BindableProperty.CreateAttached(
            nameof(EndScale), typeof(double), typeof(ScaleForScrollViewBehavior), 1d);

        public double EndScale
        {
            get => (double)GetValue(EndScaleProperty);
            set => SetValue(EndScaleProperty, value);
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            _startScale = AssociatedElement.Scale;
            _scaleAmount = EndScale - _startScale;
        }

        protected override void ScrollViewReference_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY <= ScrollStart)
            {
                // No need to do anything except ensure we are at
                // our Starting Scale
                if (AssociatedElement.Scale != _startScale)
                    AssociatedElement.Scale = _startScale;
            }
            else if (e.ScrollY >= ScrollEnd)
            {
                // Only thing we need to do here is ensure we are
                // at our Final End Scale
                if (AssociatedElement.Scale != EndScale)
                    AssociatedElement.Scale = EndScale;
            }
            else
            {
                // get our current scroll offset
                var scrollOffset = e.ScrollY - ScrollStart;
                // calculate the scale at this point in the scroll
                var scale = scrollOffset / ScrollDistance * _scaleAmount;
                // set the scale with respect to up or down. scale
                // will be negative if scaling down!
                AssociatedElement.Scale = _startScale + scale;
            }
        }
    }
}
