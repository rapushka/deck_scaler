using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class MapUtils
    {
        private readonly IGroup<Entity<Game>> _stages = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<StageIndex>()
                .Build()
        );

        private static PrimaryEntityIndex<Game, StageIndex, int> Index
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<StageIndex, int>();

        public IEnumerable<Entity<Game>> GetStagesInOrder()
        {
            for (var i = 0; i < _stages.count; i++)
                yield return Index.GetEntity(i);
        }
    }
}