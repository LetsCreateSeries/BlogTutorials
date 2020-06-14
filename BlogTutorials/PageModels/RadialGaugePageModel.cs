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

        public override async Task InitializeAsync(object navigationData = null)
        {
            await Task.Delay(5000);
            var initialDelay = 300;
            for (var i = 0; i < 30; i++)
            {
                RadialGaugeViewModel.CurrentProgress++;

                if (initialDelay - 20 > 30)
                    initialDelay -= 20;

                await Task.Delay(initialDelay);
            }
            await base.InitializeAsync(navigationData);
        }
    }
}
