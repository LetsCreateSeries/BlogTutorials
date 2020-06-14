using System;
using System.Threading.Tasks;
using BlogTutorials.PageModels.Base;
using Xamarin.Forms;

namespace BlogTutorials.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase
        {
            var page = PageModelLocator.CreatePageFor<TPageModel>();
            if (App.Current.MainPage is NavigationPage navPage)
            {
                await navPage.PushAsync(page);
            }
            else
            {
                App.Current.MainPage = new NavigationPage(page);
            }
            await ((PageModelBase)page.BindingContext).InitializeAsync(navigationData);
        }
    }
}
