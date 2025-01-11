using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class CreateTurnTracker : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _selectedStage
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SelectStage>()
                    .And<FightStage>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _selectedStage)
            {
                CreateEntity.Empty()
                    .Add<DebugName, string>("turn tracker")
                    .Add<TurnTracker>()
                    .Add<WaitingForAnimations>()
                    ;
            }
        }
    }
}