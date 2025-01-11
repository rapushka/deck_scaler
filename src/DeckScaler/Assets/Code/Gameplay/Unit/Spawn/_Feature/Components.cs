using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SpawnUnitRequest : ValueComponent<UnitIDRef>, IInScope<Game> { }
}