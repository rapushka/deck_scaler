using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class PlaceTrinketsInShop : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RestockShop>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _trinkets
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TrinketInShop>()
                    .Without<Destroy>()
                    .Build()
            );

        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Execute()
        {
            foreach (var _ in _stages)
            {
                var root = HUD.ShopStageView.TrinketsRoot;
                var spacing = HUD.ShopStageView.TrinketsSpacing;

                var currentY = -spacing * (_trinkets.count - 1) / 2f;

                foreach (var trinket in _trinkets)
                {
                    var position = root.position.Add(y: currentY);

                    trinket
                        .Add<AnimateMovement>()
                        .Replace<TargetPosition, Vector2>(position)
                        ;

                    currentY += spacing;
                }
            }
        }
    }
}