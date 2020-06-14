using System;
using BlogTutorials.PageModels.Base;

namespace BlogTutorials.ViewModels
{
    public class RadialGaugeViewModel : ExtendedBindableObject
    {
        private string _detail;
        public string Detail
        {
            get => _detail;
            set => SetProperty(ref _detail, value);
        }

        private double _minValue;
        public double MinValue
        {
            get => _minValue;
            set => SetProperty(ref _minValue, value);
        }

        private double _maxValue;
        public double MaxValue
        {
            get => _maxValue;
            set => SetProperty(ref _maxValue, value);
        }

        private double _currentProgress;
        public double CurrentProgress
        {
            get => _currentProgress;
            set => SetProperty(ref _currentProgress, value);
        }

        public RadialGaugeViewModel()
        {
        }
    }
}
