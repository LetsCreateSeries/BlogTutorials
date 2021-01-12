using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlogTutorials.Views
{
    public partial class AnimatedEntryView : ContentView
    {
        public AnimatedEntryView()
        {
            InitializeComponent();
            entInput.Focused += EntInput_Focused;
            entInput.Unfocused += EntInput_Focused;
        }

        private async void EntInput_Focused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
            {
                await Task.WhenAll(bvBackground.FadeTo(1),
                    bvGradient.ScaleXTo(1),
                    entInput.FadeTo(1));
            }
            else
            {
                await Task.WhenAll(bvBackground.FadeTo(0.25),
                    bvGradient.ScaleXTo(0),
                    entInput.FadeTo(0.5));
            }
        }
    }
}
