using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SetupPlayerCardView : ReactiveSystem<Entity<Scope>>
    {
        public SetupPlayerCardView(Contexts contexts) : base(contexts.Get<Scope>()) { }

        protected override ICollector<Entity<Scope>> GetTrigger(IContext<Entity<Scope>> context)
            => context.CreateCollector(ScopeMatcher<Scope>.Get<PlayerCard>().Added());

        protected override bool Filter(Entity<Scope> entity) => true;

        protected override void Execute(List<Entity<Scope>> entities)
        {
            foreach (var e in entities)
            {
                
            }
        }
    }
}