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

        private int _minValue;
        public int MinValue
        {
            get => _minValue;
            set => SetProperty(ref _minValue, value);
        }

        private int _maxValue;
        public int MaxValue
        {
            get => _maxValue;
            set => SetProperty(ref _maxValue, value);
        }

        private int _currentProgress;
        public int CurrentProgress
        {
            get => _currentProgress;
            set => SetProperty(ref _currentProgress, value);
        }

        public RadialGaugeViewModel()
        {
        }
    }
}
