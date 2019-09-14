namespace Xeddit.DataModels.Things.InterfacesForThings
{
    public interface IVotable
    {
        int Ups { get; set; }
        int Downs { get; set; }
        bool? Likes { get; set; }
    }
}