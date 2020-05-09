using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xeddit.DataViewModels;

namespace Xeddit.Views.Comments
{
    class CommentsListTemplateSelector : DataTemplateSelector, IMarkupExtension
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ICommentViewModel comment)
            {
                if (comment.Replies.Any())
                {

                }
            }
            return new DataTemplate();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
