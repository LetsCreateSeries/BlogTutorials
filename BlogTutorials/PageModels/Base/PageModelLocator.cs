using System;
using System.Collections.Generic;
using BlogTutorials.Pages;
using BlogTutorials.Services.Navigation;
using TinyIoC;
using Xamarin.Forms;

namespace BlogTutorials.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _lookupTable;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _lookupTable = new Dictionary<Type, Type>();

            _container.Register<INavigationService, NavigationService>();

            RegisterPageAndPageModel<MainPageModel, MainPage>();
            RegisterPageAndPageModel<RadialGaugePageModel, RadialGaugePage>();
        }

        public static Page CreatePageFor<TPageModel>()
            where TPageModel : PageModelBase
        {
            var pageModelType = typeof(TPageModel);
            var page = (Page)Activator.CreateInstance(_lookupTable[pageModelType]);
            try
            {
                var pageModel = _container.Resolve<TPageModel>();
                page.BindingContext = pageModel;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error Resolving Page Model");
            }
            return page;
        }

        public static void RegisterPageAndPageModel<TPageModel, TPage>()
            where TPage : Page where TPageModel : PageModelBase
        {
            _container.Register<TPageModel>();
            _lookupTable.Add(typeof(TPageModel), typeof(TPage));
        }

        public static void Register<TInterface, TImplementation>()
            where TInterface : class where TImplementation : class, TInterface
        {
            _container.Register<TInterface, TImplementation>();
        }

        public static T Resolve<T>() where T : class
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error Resolving Type " + typeof(T));
            }
            return default(T);
        }
    }
}
