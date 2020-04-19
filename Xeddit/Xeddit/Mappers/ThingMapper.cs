using System.Linq;
using Newtonsoft.Json.Linq;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Wrappers;

namespace Xeddit.Mappers
{
    public class ThingMapper : IThingMapper
    {
        public void Mapper(ref ListingWrapper listingWrapper)
        {
            foreach (var thingWrapper in listingWrapper.Data.Children)
            {
                if (!(thingWrapper.Data is JObject jObject)) continue;

                switch (thingWrapper.Kind)
                {
                    case ThingTypes.Message:
                        break;
                    case ThingTypes.Comment:
                        thingWrapper.Data = jObject.ToObject<Comment>();
                        break;
                    case ThingTypes.Link:
                        thingWrapper.Data = jObject.ToObject<Link>();
                        break;
                    case ThingTypes.Account:
                        break;
                    case ThingTypes.More:
                        break;
                }
            }
        }
    }
}