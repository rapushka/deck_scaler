namespace DeckScaler.Service
{
    public class Factories : IService
    {
        public LeadFactory Lead { get; } = new();
    }
}