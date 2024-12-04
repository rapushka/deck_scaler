using System;
using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class SlotPositionPrimaryIndex
    {
        public const string SlotPosition = nameof(SlotPosition);

        private readonly ScopeContext<Game> _context;

        public SlotPositionPrimaryIndex(ScopeContext<Game> context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.AddEntityIndex(
                new PrimaryEntityIndex<Entity<Game>, PositionKey>(
                    name: SlotPosition,
                    group: _context.GetGroup(
                        MatcherBuilder<Game>
                            .With<UnitID>()
                            .And<OnSide>()
                            .And<SlotIndex>()
                            .Build()
                    ),
                    getKey: GetKey,
                    comparer: new Comparer()
                )
            );
        }

        private PositionKey GetKey(Entity<Game> entity, IComponent component)
            => new(
                side: (component as OnSide)?.Value ?? entity.Get<OnSide>().Value,
                index: (component as SlotIndex)?.Value ?? entity.Get<SlotIndex>().Value
            );

        private class Comparer : IEqualityComparer<PositionKey>
        {
            public bool Equals(PositionKey x, PositionKey y)
                => x.Side == y.Side
                    && x.Index == y.Index;

            public int GetHashCode(PositionKey obj)
                => HashCode.Combine((int)obj.Side, obj.Index);
        }
    }

    public static class SlotPositionIndexExtension
    {
        public static bool TryGetUnitFromSlot(this ScopeContext<Game> context, Side side, int index, out Entity<Game> unit)
        {
            unit = context.GetUnitFromSlotOrDefault(side, index);
            return unit is not null;
        }

        public static Entity<Game> GetUnitFromSlotOrDefault(this ScopeContext<Game> context, Side side, int index)
        {
            var entityIndex = context.GetEntityIndex(SlotPositionPrimaryIndex.SlotPosition);
            var gameIndex = (PrimaryEntityIndex<Entity<Game>, PositionKey>)entityIndex;

            return gameIndex.GetEntity(new(side, index));
        }
    }
}