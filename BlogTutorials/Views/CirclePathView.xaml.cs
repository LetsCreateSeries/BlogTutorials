using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BlogTutorials.Views
{
    public partial class CirclePathView : ContentView
    {
        public static BindableProperty MaxValueProperty = BindableProperty.Create(
            nameof(MaxValue), typeof(double), typeof(CirclePathView), 1.0d);
        public static BindableProperty MinValueProperty = BindableProperty.Create(
            nameof(MinValue), typeof(double), typeof(CirclePathView));
        public static BindableProperty CurrentProgressProperty = BindableProperty.Create(
            nameof(CurrentProgress), typeof(double), typeof(CirclePathView));
        public static BindableProperty LineColorProperty = BindableProperty.Create(
            nameof(LineColor), typeof(Color), typeof(CirclePathView), Color.Aquamarine);

        /// <summary>
        /// The Maximum Value of Total Progress
        /// </summary>
        public double MaxValue
        {
            get => (double)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        /// <summary>
        /// The minimum value of Total Progress
        /// </summary>
        public double MinValue
        {
            get => (double)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        /// <summary>
        /// The Current Value of Progress between Min and Max
        /// </summary>
        public double CurrentProgress
        {
            get => (double)GetValue(CurrentProgressProperty);
            set => SetValue(CurrentProgressProperty, value);
        }

        /// <summary>
        /// The Color of the Radial Gauge Line
        /// </summary>
        public Color LineColor
        {
            get => (Color)GetValue(LineColorProperty);
            set => SetValue(LineColorProperty, value);
        }

        /// <summary>
        /// Action to provide a hook for the renderer to force redraw
        /// </summary>
        public Action CurrentProgressChanged { get; set; }

        public CirclePathView()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            // If the Current Progress gets updated, Invoke the Action to Force Redraw
            // if it is available.
            if (propertyName != null && propertyName.Equals(CurrentProgressProperty.PropertyName))
            {
                CurrentProgressChanged?.Invoke();
            }
        }
    }
}
