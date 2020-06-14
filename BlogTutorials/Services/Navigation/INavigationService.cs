using System;
using System.Threading.Tasks;
using BlogTutorials.PageModels.Base;

namespace BlogTutorials.Services.Navigation
{
    public interface INavigationService
    {
        Task GoBackAsync();

        Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase;
    }
}
