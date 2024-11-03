using System.Collections.Generic;
using System.Linq;
using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Ui.Views.GameplayHUD;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class SetupPlayerCardView : ReactiveSystem<Entity<Model>>
    {
        public SetupPlayerCardView() : base(Contexts.Instance.Get<Model>()) { }

        private static GameplayHUD HUD => Services.Get<UI>().GetView<GameplayHUD>();

        protected override ICollector<Entity<Model>> GetTrigger(IContext<Entity<Model>> context)
            => context.CreateCollector(ScopeMatcher<Model>.Get<PlayerCard>().Added());

        protected override bool Filter(Entity<Model> entity) => true;

        protected override void Execute(List<Entity<Model>> entities)
        {
            foreach (var view in entities.Select(e => e.Get<ViewEntity>().Value))
                view.Add<Parent, Transform>(HUD.CardsHolder.Root);
        }
    }
}