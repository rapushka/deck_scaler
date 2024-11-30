using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnAnimationCompletedRemoveAnimationsFlags : ReactiveSystem<Entity<Game>>
    {
        public OnAnimationCompletedRemoveAnimationsFlags() : base(Contexts.Instance.Get<Game>()) { }

        protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
            => context.CreateCollector(ScopeMatcher<Game>.Get<PlayingAnimation>().Removed());

        protected override bool Filter(Entity<Game> entity) => !entity.Has<PlayingAnimation>();

        protected override void Execute(List<Entity<Game>> entities)
        {
            foreach (var entity in entities)
            {
                entity
                    .Is<PlayingAttackAnimation>(false)
                    ;
            }
        }
    }
}