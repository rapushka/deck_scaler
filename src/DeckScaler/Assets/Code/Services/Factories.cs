namespace DeckScaler.Service
{
    public interface IFactories : IService
    {
        IUnitFactory Unit { get; }

        IEntityBehaviourFactory EntityBehaviour { get; }

        IAffectsFactory Affects { get; }

        ITrinketFactory Trinkets { get; }
    }

    public class Factories : IFactories
    {
        public IUnitFactory Unit { get; } = new UnitFactory();

        public IEntityBehaviourFactory EntityBehaviour { get; } = new EntityBehaviourFactory();

        public IAffectsFactory Affects { get; } = new AffectsFactory();

        public ITrinketFactory Trinkets { get; } = new TrinketFactory();
    }
}