using Xeddit.DataModels.Wrappers;

namespace Xeddit.Mappers
{
    public interface IThingMapper
    {
        void Mapper(ref ListingWrapper listingWrapper);
    }
}