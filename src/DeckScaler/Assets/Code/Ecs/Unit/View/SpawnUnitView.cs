using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SpawnUnitView : ReactiveSystem<Entity<Game>> // TODO: REMOVE ME
    {
        public SpawnUnitView(Contexts contexts) : base(contexts.Get<Game>()) { }

        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(ScopeMatcher<Game>.Get<UnitID>());

        protected override bool Filter(Entity<Game> entity)
            => true;

        protected override void Execute(List<Entity<Game>> entities)
        {
            foreach (var entity in entities)
            {
                var unitID = entity.Get<UnitID>().Value;
                var unitConfig = Services.Get<Configs>().Units[unitID];

                UnitsConfig.ViewPrefab
                           .Spawn()
                           .Entity
                           .Add<Name, string>("Test Lead")
                    // .AddModel(entity)
                    // .Add<Portrait, Sprite>(unitConfig.Portrait)
                    ;
            }
        }
    }
}