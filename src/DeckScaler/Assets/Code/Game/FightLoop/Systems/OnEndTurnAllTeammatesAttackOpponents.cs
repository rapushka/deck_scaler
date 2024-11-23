using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnEndTurnAllTeammatesAttackOpponents : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _event = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<EndTurn>()
                .Build()
        );

        private readonly IGroup<Entity<Game>> _teammates = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Teammate>()
                .And<BaseDamage>()
                .And<InSlot>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _event)
            foreach (var teammate in _teammates)
            {
                if (teammate.TryGetOpponent(out var enemyID))
                    teammate.Add<PrepareAttack, EntityID>(enemyID);
            }
        }
    }
}