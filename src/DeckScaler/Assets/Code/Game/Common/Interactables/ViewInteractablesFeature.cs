using DeckScaler.Systems;

namespace DeckScaler.Component
{
    public sealed class ViewInteractablesFeature : Feature
    {
        public ViewInteractablesFeature()
            : base(nameof(ViewInteractablesFeature))
        {
            Add(new EnableInteractableOnPlayerPrepareEnter());
            Add(new DisableInteractableOnPlayerPrepareExit());

            Add(new OnPlayerPrepareStepEnsureInteractableAllies());
        }
    }
}