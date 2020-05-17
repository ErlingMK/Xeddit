using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.DataViewModels.Contracts;

namespace Xeddit.Views.Comments
{
    public class ReplyTypeSelector : DataTemplateSelector, IMarkupExtension
    {
        public DataTemplate MoreCommentsTemplate { get; set; }
        public DataTemplate RepliesTemplate { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item is IMoreViewModel ? MoreCommentsTemplate : RepliesTemplate;
        }
    }
}