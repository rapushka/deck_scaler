using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class SetupTeamSlotToTeamContainer : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _slots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TeamSlot>()
                    .Without<ParentTransform>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        private GameplayHUD _gameplayHUD;
        private GameplayHUD GameplayHUD => _gameplayHUD ??= Services.Get<IUI>().GetScene<GameplayHUD>();

        public void Execute()
        {
            foreach (var teamSlot in _slots.GetEntities(_buffer))
                teamSlot.Add<ParentTransform, Transform>(GameplayHUD.TeamContainer);
        }
    }
}