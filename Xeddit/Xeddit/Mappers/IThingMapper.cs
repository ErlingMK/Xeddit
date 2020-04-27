using System.Collections.Generic;
using Xeddit.DataModels.Wrappers;
using Xeddit.DataViewModels;

namespace Xeddit.Mappers
{
    public interface IThingMapper
    {
        void Mapper(ref ListingWrapper listingWrapper);
        IList<ILinkViewModel> LinkMapper(IList<ThingWrapper> links);
    }
}