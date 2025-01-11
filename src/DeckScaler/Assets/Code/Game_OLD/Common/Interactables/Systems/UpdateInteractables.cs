using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BlockInteractablesOnAbilitiesUsage : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _interactables
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<EnableOnlyOnPlayerTurn>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _delaysBeforeAbility
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SendTurnStartedAfter>()
                    .Or<TriggerOnTurnStartedAbility>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _delaysBeforeAbility)
            foreach (var interactable in _interactables)
            {
                interactable.Is<Interactable>(false);
            }
        }
    }
}