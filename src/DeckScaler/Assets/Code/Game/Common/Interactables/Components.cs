using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class ViewCollider : ValueComponent<Collider2D>, IInScope<Game> { }

    public sealed class EnableOnlyInPlayerPrepare : FlagComponent, IInScope<Game> { }

    public sealed class UiButton : ValueComponent<UnityEngine.UI.Button>, IInScope<Game> { }

    public sealed class Interactable : FlagComponent, IInScope<Game> { }
}