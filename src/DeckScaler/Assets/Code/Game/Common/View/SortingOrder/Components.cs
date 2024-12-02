using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class SpriteSortOrder : ValueComponent<int>, IInScope<Game> { }

    public sealed class SortingGroupView : ValueComponent<UnityEngine.Rendering.SortingGroup>, IInScope<Game> { }
}