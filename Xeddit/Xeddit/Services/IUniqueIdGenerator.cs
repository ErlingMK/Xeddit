using System;
using System.Collections.Generic;
using System.Text;

namespace Xeddit.Services
{
    public interface IUniqueIdGenerator
    {
        string GenerateDeviceId();
    }
}
