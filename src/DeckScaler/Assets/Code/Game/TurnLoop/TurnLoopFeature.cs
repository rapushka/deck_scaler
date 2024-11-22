using DeckScaler.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class TurnLoopFeature : Feature
    {
        public TurnLoopFeature()
            : base(nameof(TurnLoopFeature))
        {
            Add(new TestTurnEnd());
        }

        private class TestTurnEnd : IExecuteSystem
        {
            private readonly IGroup<Entity<Game>> _entities = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<EndTurn>()
                    .Build()
            );

            public void Execute()
            {
                foreach (var entity in _entities)
                {
                    Debug.Log("end turn indeed!");
                }
            }
        }
    }
}