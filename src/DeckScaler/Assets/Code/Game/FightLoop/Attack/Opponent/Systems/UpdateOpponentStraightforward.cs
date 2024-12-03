using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    // public class UpdateOpponentStraightforward : IExecuteSystem
    // {
    //     private readonly IGroup<Entity<Game>> _events
    //         = Contexts.Instance.GetGroup(
    //             MatcherBuilder<Game>
    //                 .With<RecalculateOpponents>()
    //                 .Build()
    //         );
    //     private readonly IGroup<Entity<Game>> _units
    //         = Contexts.Instance.GetGroup(
    //             MatcherBuilder<Game>
    //                 .With<UnitID>()
    //                 .Without<Opponent>()
    //         );
    //     private readonly List<Entity<Game>> _buffer = new(128);
    //
    //     public void Execute()
    //     {
    //         foreach (var _ in _events)
    //         foreach (var unit in _units.GetEntities(_buffer))
    //         {
    //             if (!unit.TryGetOpponent(out var opponentID))
    //                 continue;
    //
    //             if (!opponentID.IsEntityDead())
    //                 unit.Add<Opponent, EntityID>(opponentID);
    //         }
    //     }
    // }
}