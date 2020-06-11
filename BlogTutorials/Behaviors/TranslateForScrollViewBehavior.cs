using System;
using BlogTutorials.Behaviors.Base;
using Xamarin.Forms;

namespace BlogTutorials.Behaviors
{
    public class TranslateForScrollViewBehavior : ScrollViewObserverBase
    {
        /// <summary>
        /// The initial translation of the Visual Element
        /// </summary>
        private Point _initialTranslation;
        /// <summary>
        /// The difference between start translation and end translation
        /// </summary>
        private Point _translationAmount;

        public static readonly BindableProperty EndTranslationProperty = BindableProperty.CreateAttached(
            nameof(EndTranslation), typeof(Point), typeof(ScaleForScrollViewBehavior), Point.Zero);

        public Point EndTranslation
        {
            get => (Point)GetValue(EndTranslationProperty);
            set => SetValue(EndTranslationProperty, value);
        }


        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            _initialTranslation = new Point(AssociatedElement.TranslationX, AssociatedElement.TranslationY);
            _translationAmount = new Point(EndTranslation.X - AssociatedElement.TranslationX, EndTranslation.Y - AssociatedElement.TranslationY);
        }

        protected override void ScrollViewReference_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY <= ScrollStart)
            {
                // No need to do anything except ensure we are at
                // our Starting Translation. This one needs both X and Y
                if (AssociatedElement.TranslationX != _initialTranslation.X)
                    AssociatedElement.TranslationX = _initialTranslation.X;
                if (AssociatedElement.TranslationY != _initialTranslation.Y)
                    AssociatedElement.TranslationY = _initialTranslation.Y;
            }
            else if (e.ScrollY >= ScrollEnd)
            {
                // Only thing we need to do here is ensure we are
                // at our Final Translation. Again, both X and Y
                if (AssociatedElement.TranslationX != EndTranslation.X)
                    AssociatedElement.TranslationX = EndTranslation.X;
                if (AssociatedElement.TranslationY != EndTranslation.Y)
                    AssociatedElement.TranslationY = EndTranslation.Y;
            }
            else
            {
                // get our current scroll offset
                var scrollOffset = e.ScrollY - ScrollStart;
                // calculate the translation for X and Y at this point in the scroll
                var translationX = scrollOffset / ScrollDistance * _translationAmount.X;
                var translationY = scrollOffset / ScrollDistance * _translationAmount.Y;
                // set the translation on the visual element
                AssociatedElement.TranslationX = _initialTranslation.X + translationX;
                AssociatedElement.TranslationY = _initialTranslation.Y + translationY;
            }
        }
    }
}
