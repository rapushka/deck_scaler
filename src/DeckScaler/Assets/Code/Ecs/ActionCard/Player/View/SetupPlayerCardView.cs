using System;
using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Ui.Views.GameplayHUD;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class SetupPlayerCardView : ReactiveSystem<Entity<Scope>>
    {
        public SetupPlayerCardView() : base(Contexts.Instance.Scope()) { }

        private static GameplayHUD HUD => Services.Get<UI>().GetView<GameplayHUD>();

        protected override ICollector<Entity<Scope>> GetTrigger(IContext<Entity<Scope>> context)
            => context.CreateCollector(ScopeMatcher<Scope>.Get<PlayerCard>().Added());

        protected override bool Filter(Entity<Scope> entity) => true;

        protected override void Execute(List<Entity<Scope>> entities)
        {
            foreach (var e in entities)
                e.Add<Parent, Transform>(HUD.CardsHolder.Root);
        }
    }
}