using System;
using BlogTutorials.PageModels.Base;
using BlogTutorials.Services.Navigation;
using BlogTutorials.ViewModels;

namespace BlogTutorials.PageModels
{
    public class MainPageModel : PageModelBase
    {
        private SampleCardViewModel _radialGaugeRow;
        public SampleCardViewModel RadialGaugeRow
        {
            get => _radialGaugeRow;
            set => SetProperty(ref _radialGaugeRow, value);
        }

        private INavigationService _navigationService;

        public MainPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            RadialGaugeRow = new SampleCardViewModel("Radial Gauge", "Our custom Radial Gauge View with multiple variants of attributes.", GoToRadialGaugePage); ;
        }

        private void GoToRadialGaugePage()
        {
            _navigationService.NavigateToAsync<RadialGaugePageModel>();
        }
    }
}
