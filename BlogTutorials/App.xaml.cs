using System;
using BlogTutorials.PageModels;
using BlogTutorials.PageModels.Base;
using BlogTutorials.Services.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlogTutorials
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            PageModelLocator.Resolve<INavigationService>().NavigateToAsync<MainPageModel>(null, true);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
