using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BlogTutorials.Controls
{
    public partial class OvalFrame : Frame
    {
        public OvalFrame()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName.Equals(HeightProperty.PropertyName))
            {
                CornerRadius = (float)Height / 2;
            }
        }
    }
}
