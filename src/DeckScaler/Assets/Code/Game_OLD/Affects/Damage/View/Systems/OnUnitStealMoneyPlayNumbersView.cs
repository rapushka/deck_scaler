using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnUnitStealMoneyPlayNumbersView : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _affects
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StealMoneyAffect>()
                    .And<SenderID>()
                    .And<AffectValue>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var affect in _affects)
            {
                var stealer = affect.GetByID<SenderID>();

                if (stealer.TryGet<NumbersView, FloatingNumberView>(out var numbersView))
                {
                    var stealFrom = stealer.Is<Teammate>()
                        ? FloatingNumberView.Type.StealMoneyFromEnemy
                        : FloatingNumberView.Type.StealMoneyFromPlayer;

                    var stolenMoney = affect.Get<AffectValue, int>();
                    numbersView.Play(stolenMoney, stealFrom);
                }
            }
        }
    }
}