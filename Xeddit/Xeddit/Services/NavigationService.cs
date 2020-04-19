using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LightInject;
using Xamarin.Forms;
using Xeddit.Views.Comments;
using Xeddit.Views.Front;
using Xeddit.Views.Front.ViewModel;

namespace Xeddit.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceContainer m_serviceContainer;
        private Dictionary<Type, Type> m_pages = new Dictionary<Type, Type>();

        public NavigationService(IServiceContainer serviceContainer)
        {
            m_serviceContainer = serviceContainer;
        }

        private INavigation Navigator => m_serviceContainer.GetInstance<NavigationPage>().Navigation;
        
        public async Task NavigateTo<TViewModel>(Func<Task> beforeNavigation)
        {
            var viewModel = m_serviceContainer.GetInstance<TViewModel>();
            var page = m_serviceContainer.GetInstance(m_pages[typeof(TViewModel)]);
            if (page is Page goToPage)
            {
                goToPage.BindingContext = viewModel;
                var task = beforeNavigation.Invoke();
                await Navigator.PushAsync(goToPage);
                await task;
            }
        }

        public void RegisterPages()
        {
            m_pages[typeof(ISubredditViewModel)] = typeof(SubredditPage);
            m_pages[typeof(ICommentsViewModel)] = typeof(CommentsPage);
        }
    }

    public interface INavigationService
    {
        Task NavigateTo<TViewModel>(Func<Task> beforeNavigation);
        void RegisterPages();
    }
}
