namespace DeckScaler.Service
{
    public interface IUtils : IService
    {
        TeamSlotsUtil TeamSlotsUtil { get; }
    }

    public class Utils : IUtils
    {
        public TeamSlotsUtil TeamSlotsUtil { get; } = new();
    }
}