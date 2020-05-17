using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.DataViewModels.Contracts;

namespace Xeddit.Views.Comments
{
    public class CommentTypeSelector : DataTemplateSelector, IMarkupExtension
    {
        public DataTemplate MoreCommentsTemplate { get; set; }
        public DataTemplate CommentsTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item is IMoreViewModel ? MoreCommentsTemplate : CommentsTemplate;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
