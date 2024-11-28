using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class SetupTeamSlotToTeamRoot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _slots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TeamSlot>()
                    .Without<ParentTransform>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _teamRoots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TeamRoot>()
                    .And<ViewTransform>()
                    .Build()
            );

        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var teamSlot in _slots.GetEntities(_buffer))
            foreach (var root in _teamRoots)
            {
                var rootTransform = root.Get<ViewTransform>().Value;
                teamSlot.Add<ParentTransform, Transform>(rootTransform);
            }
        }
    }
}