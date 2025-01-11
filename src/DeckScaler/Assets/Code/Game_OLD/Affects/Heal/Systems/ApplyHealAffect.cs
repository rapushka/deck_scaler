using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ApplyHealAffect : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _affects
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<HealAffect>()
                    .And<AffectValue>()
                    .And<TargetID>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var attack in _affects)
            {
                var target = attack.Get<TargetID>().Value.GetEntity();
                var healing = attack.Get<AffectValue>().Value;

                target.Increment<Health>(healing);
            }
        }
    }
}