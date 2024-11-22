using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnTurnEndedWhenNoAttackersStartEnemiesTurn : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _endTurns = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TurnEnded>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _endTurns)
            {
                CreateEntity.OneFrame()
                            .Add<StartEnemyTurn>();
            }
        }
    }
}