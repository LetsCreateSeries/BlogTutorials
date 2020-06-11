using Xamarin.Forms;

namespace BlogTutorials.Behaviors.Base
{
    public abstract class ScrollViewObserverBase : Behavior<VisualElement>
    {
        /// <summary>
        /// The range of the effected scroll area
        /// </summary>
        protected double ScrollDistance { get; private set; }

        public static readonly BindableProperty ScrollViewReferenceProperty =
            BindableProperty.CreateAttached(nameof(ScrollViewReference), typeof(ScrollView),
                typeof(ScrollViewObserverBase), null);

        public static BindableProperty ScrollStartProperty = BindableProperty.CreateAttached(
            nameof(ScrollStart), typeof(double), typeof(ScaleForScrollViewBehavior), 0d);

        public static BindableProperty ScrollEndProperty = BindableProperty.CreateAttached(
            nameof(ScrollEnd), typeof(double), typeof(ScaleForScrollViewBehavior), 50d);


        public double ScrollStart
        {
            get => (double)GetValue(ScrollStartProperty);
            set => SetValue(ScrollStartProperty, value);
        }

        public double ScrollEnd
        {
            get => (double)GetValue(ScrollEndProperty);
            set => SetValue(ScrollEndProperty, value);
        }

        public ScrollView ScrollViewReference
        {
            get => (ScrollView)GetValue(ScrollViewReferenceProperty);
            set => SetValue(ScrollViewReferenceProperty, value);
        }
        /// <summary>
        /// The VisualElement that this Behavior is attached to.
        /// </summary>
        public VisualElement AssociatedElement { get; private set; }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            // Store a reference to our element
            AssociatedElement = bindable;
            // register our method to the Scrolled event.
            ScrollViewReference.Scrolled += ScrollViewReference_Scrolled;
            ScrollDistance = ScrollEnd - ScrollStart;
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            base.OnDetachingFrom(bindable);
            // deregister our method
            ScrollViewReference.Scrolled -= ScrollViewReference_Scrolled;
        }

        protected abstract void ScrollViewReference_Scrolled(object sender, ScrolledEventArgs e);
    }
}
