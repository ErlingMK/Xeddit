using System.ComponentModel;
using DIPS.Xamarin.UI.Extensions;
using Xeddit.Views.Comments;
using Xeddit.Views.Front.ViewModel;

namespace Xeddit.Views
{
    public class ContextViewModel : IContextViewModel
    {
        private readonly ICommentsViewModel m_commentsViewModel;
        private readonly ISubredditViewModel m_subredditViewModel;
        private object m_current;

        public ContextViewModel(ISubredditViewModel subredditViewModel, ICommentsViewModel commentsViewModel)
        {
            m_subredditViewModel = subredditViewModel;
            m_commentsViewModel = commentsViewModel;

            Current = subredditViewModel;
        }

        public object Current
        {
            get => m_current;
            set => PropertyChanged.RaiseWhenSet(ref m_current, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public interface IContextViewModel : INotifyPropertyChanged
    {
        object Current { get; }
    }
}