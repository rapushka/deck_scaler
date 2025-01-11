using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ApplyStealMoneyAffect : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _affects
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StealMoneyAffect>()
                    .And<AffectValue>()
                    .And<SenderID>()
                    .And<TargetID>()
                    .Build()
            );

        private static PrimaryEntityIndex<Game, Inventory, Side> Index
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<Inventory, Side>();

        public void Execute()
        {
            foreach (var affect in _affects)
            {
                var sender = affect.GetByID<SenderID>();
                var target = affect.GetByID<TargetID>();
                var targetAmount = affect.Get<AffectValue>().Value;

                var targetSide = target.Get<OnSide, Side>();
                var beneficiarySide = sender.Get<OnSide, Side>();

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