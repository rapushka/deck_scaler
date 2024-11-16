using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SpawnUnitView : ReactiveSystem<Entity<Model>> // TODO: REMOVE ME
    {
        public SpawnUnitView(Contexts contexts) : base(contexts.Get<Model>()) { }

        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        protected override ICollector<Entity<Model>> GetTrigger(IContext<Entity<Model>> context)
            => context.CreateCollector(ScopeMatcher<Model>.Get<UnitID>());

        protected override bool Filter(Entity<Model> entity)
            => true;

        protected override void Execute(List<Entity<Model>> entities)
        {
            foreach (var entity in entities)
            {
                var unitID = entity.Get<UnitID>().Value;
                var unitConfig = Services.Get<Configs>().Units[unitID];

                UnitsConfig.UnitViewPrefab
                           .Spawn()
                           .Entity
                           .Add<Name, string>("Test Lead")
                           .AddModel(entity)
                    // .Add<Portrait, Sprite>(unitConfig.Portrait)
                    ;
            }
        }
    }
}