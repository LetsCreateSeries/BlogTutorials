using System;
using System.Threading.Tasks;

namespace BlogTutorials.PageModels.Base
{
    public abstract class PageModelBase : ExtendedBindableObject
    {
        public PageModelBase()
        {
        }

        public virtual Task InitializeAsync(object navigationData = null)
        {
            return Task.CompletedTask;
        }

        public virtual Task InitializeAsync<TDataType>(TDataType navigationData)
            where TDataType : class
        {
            return Task.CompletedTask;
        }
    }
}
