using System;
using System.Threading.Tasks;
using BlogTutorials.PageModels.Base;
using BlogTutorials.ViewModels;

namespace BlogTutorials.PageModels
{
    public class RadialGaugePageModel : PageModelBase
    {
        private RadialGaugeViewModel _radialGauge;
        public RadialGaugeViewModel RadialGaugeViewModel
        {
            get => _radialGauge;
            set => SetProperty(ref _radialGauge, value);
        }

        public RadialGaugePageModel()
        {
            RadialGaugeViewModel = new RadialGaugeViewModel
            {
                MinValue = 0,
                MaxValue = 100,
                CurrentProgress = 50,
                Detail = "Completed"
            };
        }
    }
}
