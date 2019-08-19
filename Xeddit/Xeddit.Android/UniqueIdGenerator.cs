using Xamarin.Forms;
using Xeddit.Droid;
using Xeddit.Services;

[assembly: Dependency(typeof(UniqueIdGenerator))]
namespace Xeddit.Droid
{
    public class UniqueIdGenerator : IUniqueIdGenerator
    {
        public string GenerateDeviceId()
        {
            return Java.Util.UUID.RandomUUID().ToString();
        }
    }
}