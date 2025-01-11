using System;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class GameplayHUD : BaseUiScreen, IDisposable
    {
        [field: SerializeField] public EntityBehaviour<Game>[] Behaviours { get; private set; }

        [field: SerializeField] public MapView              MapView              { get; private set; }
        [field: SerializeField] public RecruitmentStageView RecruitmentStageView { get; private set; }
        [field: SerializeField] public ShopStageView        ShopStageView        { get; private set; }

        private static IFactories Factory => ServiceLocator.Resolve<IFactories>();

        public override void Initialize()
        {
            base.Initialize();

            RegisterEntityBehaviours();
            MapView.Hide();
            RecruitmentStageView.Hide();
            ShopStageView.Hide();
        }

        private void RegisterEntityBehaviours()
        {
            foreach (var entityBehaviour in Behaviours)
                Factory.EntityBehaviour.Register(entityBehaviour);
        }

        public void Dispose()
        {
            MapView.Dispose();
        }
    }
}