using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;
using Xeddit.DataModels.Things.Contracts;
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
                        if (thingWrapper.Data is IComment comment && comment.Replies is JObject repliesAsJObject && repliesAsJObject.ContainsKey("kind"))
                        {
                            comment.Replies = repliesAsJObject.ToObject<ListingWrapper>();
                        }
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