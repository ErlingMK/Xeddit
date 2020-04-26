using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xeddit.Views;
using DIPS.Xamarin.UI.Extensions;

namespace Xeddit.Custom
{
    public class ShowBackDropTriggerAction : TriggerAction<VisualElement>
    {
        protected override void Invoke(VisualElement sender)
        {
            var backDrop = sender.GetParentOfType<BackDrop>();
            if (backDrop != null)
            {
                BackDrop.SetShowBackDrop(backDrop, !BackDrop.GetShowBackDrop(backDrop));
            }
        }
    }
}
