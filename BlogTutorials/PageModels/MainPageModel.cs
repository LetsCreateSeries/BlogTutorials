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

        private SampleCardViewModel _animatedEntryRow;
        public SampleCardViewModel AnimatedEntryRow
        {
            get => _animatedEntryRow;
            set => SetProperty(ref _animatedEntryRow, value);
        }

        private INavigationService _navigationService;

        public MainPageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            RadialGaugeRow = new SampleCardViewModel("Radial Gauge",
                "Our custom Radial Gauge View with multiple variants of attributes.",
                GoToPage<RadialGaugePageModel>);

            AnimatedEntryRow = new SampleCardViewModel("Animated Entry",
                "We'll use Xamarin.Forms 5 Brushes and standard animations to create Entries that respond to their Focus events.",
                GoToPage<AnimatedEntryPageModel>);
        }

        private void GoToPage<TPageModel>() where TPageModel : PageModelBase
        {
            _navigationService.NavigateToAsync<TPageModel>();
        }
    }
}
