using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xeddit.iOS;
using Xeddit.Services;

[assembly: Dependency(typeof(UniqueIdGenerator))]
namespace Xeddit.iOS
{
    public class UniqueIdGenerator : IUniqueIdGenerator
    {
        public string GenerateDeviceId()
        {
            return new NSUuid().ToString();
        }
    }
}