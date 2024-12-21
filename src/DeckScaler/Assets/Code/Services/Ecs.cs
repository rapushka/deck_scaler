using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Service
{
    public interface IEcs : IService
    {
        void Initialize();

        void StartGameplay();
        void Update();
        void EndGameplay();
    }

    public class Ecs : IEcs
    {
        private CustomIndexes _customIndexes;
        private Contexts _contexts;

        private static IEcsRunner EcsRunner => ServiceLocator.Resolve<IEcsRunner>();

        public void Initialize()
        {
            _contexts = Contexts.Instance;

            _contexts.InitializeScope<Game>();
            _contexts.InitializeScope<Scopes.Cheats>();
            _contexts.InitializeScope<Input>();

            _contexts.Get<Game>().GetPrimaryIndex<ID, EntityID>().Initialize();
            _contexts.Get<Game>().GetPrimaryIndex<Inventory, Side>().Initialize();
            _contexts.Get<Game>().GetPrimaryIndex<TrinketSlot, int>().Initialize();
            _contexts.Get<Game>().GetPrimaryIndex<TrinketInSlot, int>().Initialize();
            _contexts.Get<Game>().GetPrimaryIndex<StageIndex, int>().Initialize();

            _customIndexes = new(_contexts);
            _customIndexes.Initialize();

#if DEBUG
            Entity<Game>.Formatter = new GameEntityFormatter();
#endif
        }

        public void StartGameplay()
        {
            EcsRunner.AddFeature<MainFeature>();
        }

        public void Update()
        {
            EcsRunner.Update();
        }

        public void EndGameplay()
        {
            EcsRunner.RemoveFeature<MainFeature>(destroyAllEntities: true);

            _contexts.Get<Game>().Reset();
            _contexts.Get<Input>().Reset();
            _contexts.Get<Scopes.Cheats>().Reset();
        }
    }
}