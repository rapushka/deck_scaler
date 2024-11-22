using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class SendTurnEndedEventWhenThereNoAttackers : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Attack>()
                .Build()
        );

        public void Execute()
        {
            if (_attackers.Any())
                return;

            CreateEntity.OneFrame()
                        .Add<TurnEnded>();
        }
    }
}