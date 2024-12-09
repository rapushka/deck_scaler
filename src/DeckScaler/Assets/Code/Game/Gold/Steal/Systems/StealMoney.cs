using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class StealMoney : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Component.StealMoney>()
                    .And<StealMoneyFrom>()
                    .Build()
            );

        private static PrimaryEntityIndex<Game, Inventory, Side> Index
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<Inventory, Side>();

        public void Execute()
        {
            foreach (var request in _requests)
            {
                var targetAmount = request.Get<Component.StealMoney, int>();
                var targetSide = request.Get<StealMoneyFrom, Side>();
                var beneficiarySide = targetSide.Flip();

                var targetInventory = Index.GetEntity(targetSide);
                var availableMoney = targetInventory.Get<Money, int>();

                var stolenAmount = targetAmount.Clamp(max: availableMoney);
                targetInventory.Increment<Money>(-stolenAmount);

                var beneficiaryInventory = Index.GetEntity(beneficiarySide);
                beneficiaryInventory.Increment<Money>(stolenAmount);
            }
        }
    }
}