using System;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class GameplayHUD : BaseUiScreen, IDisposable
    {
        [field: SerializeField] public EntityBehaviour<Game>[] Behaviours { get; private set; }

        [field: SerializeField] public MapView              MapView              { get; private set; }
        [field: SerializeField] public RecruitmentStageView RecruitmentStageView { get; private set; }

        public void Dispose()
        {
            MapView.Dispose();
        }
    }
}