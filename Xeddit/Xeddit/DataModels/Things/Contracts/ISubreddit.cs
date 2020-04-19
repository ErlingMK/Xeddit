namespace Xeddit.DataModels.Things.Contracts
{
    public interface ISubreddit
    {
        int AccountsActive { get; }
        string Description { get; }
        string DisplayName { get; }
        long Subscribers { get; }
        string Title { get; }
        string Url { get; }
        string Id { get; set; }
        string Name { get; set; }
    }
}