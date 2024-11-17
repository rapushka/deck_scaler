using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class Portrait : ValueComponent<SpriteRenderer>, IInScope<Game> { }

    public sealed class CardBackground : ValueComponent<SpriteRenderer>, IInScope<Game> { }
}