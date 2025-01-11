using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class PlaceUnitsInShop : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RestockShop>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitInShop>()
                    .Without<Destroy>()
                    .Build()
            );

        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Execute()
        {
            foreach (var _ in _stages)
            {
                var unitsRoot = HUD.ShopStageView.UnitsRoot;
                var spacing = HUD.ShopStageView.UnitsSpacing;

                var currentX = -spacing * (_units.count - 1) / 2f;

                foreach (var recruit in _units)
                {
                    var unitPosition = unitsRoot.position.Add(x: currentX);

                    recruit
                        .Add<AnimateMovement>()
                        .Replace<TargetPosition, Vector2>(unitPosition)
                        ;

                    currentX += spacing;
                }
            }
        }
    }
}