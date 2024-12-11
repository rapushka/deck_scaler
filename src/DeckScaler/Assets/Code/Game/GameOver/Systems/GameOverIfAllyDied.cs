using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class GameOverIfAllyDied : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _deadAllies
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Ally>()
                    .And<Dead>()
                    .Build()
            );

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public void Execute()
        {
            foreach (var _ in _deadAllies)
            {
                UiMediator.GameOver();
                return;
            }
        }
    }
}