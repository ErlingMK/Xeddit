namespace Xeddit.DataModels.Things
{
    public interface IThing
    {
        string Id { get; set; }
        string Name { get; set; }
    }

    /// <summary>
    /// The Reddit base class for Comment, Link and Subreddit. 
    /// </summary>
    public class Thing : IThing
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}