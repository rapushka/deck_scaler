namespace DeckScaler.Service
{
    public interface IFactories : IService
    {
        IUnitFactory Unit { get; }

        IEntityBehaviourFactory EntityBehaviour { get; }
    }

    public class Factories : IFactories
    {
        public IUnitFactory Unit { get; } = new UnitFactory();

        public IEntityBehaviourFactory EntityBehaviour { get; } = new EntityBehaviourFactory();
    }
}