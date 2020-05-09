namespace Xeddit.DataModels.Things.InterfacesForThings
{
    public interface ICreated
    {
        long? Created { get; set; }
        long? CreatedUtc { get; set; }
    }
}