using Newtonsoft.Json.Linq;
using Xeddit.DataModels;
using Xeddit.DataModels.Things;

namespace Xeddit.Clients
{
    public class ListingParser
    {
        public static Listing ParseThings(ListingWrapper listingWrapper)
        {
            if (listingWrapper.Kind != "Listing") return null;

            var currentListing = listingWrapper.Data;

            if (currentListing == null) return null;

            foreach (var currentThing in currentListing.Children)
            {
                switch (currentThing.Kind)
                {
                    case ThingTypes.Link:
                        if (currentThing.Data is JObject link)
                        {
                            currentThing.Data = link.ToObject<Link>();
                        }
                        break;
                    case ThingTypes.Comment:
                        if (currentThing.Data is JObject comment)
                        {
                            currentThing.Data = comment.ToObject<Comment>();
                        }
                        break;
                    default:
                        break;
                }
            }

            return currentListing;
        }
    }
}