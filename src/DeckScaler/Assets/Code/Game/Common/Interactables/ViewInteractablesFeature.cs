using DeckScaler.Systems;

namespace DeckScaler.Component
{
    public sealed class ViewInteractablesFeature : Feature
    {
        public ViewInteractablesFeature()
            : base(nameof(ViewInteractablesFeature))
        {
            Add(new ActivateAllInteractables());

            Add(new BlockInteractablesDuringAnimations());
            Add(new BlockInteractablesDuringEnemyTurn());
            Add(new BlockInteractablesOnDragging());
            Add(new BlockInteractablesOnGameOver());
            Add(new BlockInteractablesOnAbilitiesUsage());
        }
    }
}