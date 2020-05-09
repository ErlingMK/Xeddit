namespace Xeddit.DataModels.Wrappers
{
    public class ListingWrapper
    {
        public string Kind { get; set; } // Should always be a Listing
        public Listing Data { get; set; }
    }
}
