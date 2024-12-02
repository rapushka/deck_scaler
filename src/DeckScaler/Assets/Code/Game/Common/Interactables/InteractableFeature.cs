using DeckScaler.Systems;

namespace DeckScaler.Component
{
    public sealed class InteractableFeature : Feature
    {
        public InteractableFeature()
            : base(nameof(InteractableFeature))
        {
            Add(new EnableInteractableOnPlayerPrepareEnter());
            Add(new DisableInteractableOnPlayerPrepareExit());
        }
    }
}