namespace DeckScaler.Service
{
    public class Factories : IService
    {
        public UnitFactory     Unit     { get; } = new();
        public TeamSlotFactory TeamSlot { get; } = new();
    }
}