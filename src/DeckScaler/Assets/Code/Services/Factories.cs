namespace DeckScaler.Service
{
    public interface IFactories : IService
    {
        UnitFactory     Unit     { get; }
        TeamSlotFactory TeamSlot { get; }
    }

    public class Factories : IFactories
    {
        public UnitFactory     Unit     { get; } = new();
        public TeamSlotFactory TeamSlot { get; } = new();
    }
}