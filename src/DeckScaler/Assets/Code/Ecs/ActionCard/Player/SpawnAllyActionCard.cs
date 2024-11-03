using System.Collections.Generic;
using System.Linq;
using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Ui.Views.GameplayHUD;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<DeckScaler.Model>;

namespace DeckScaler.Systems
{
    public sealed class SpawnAllyActionCard : ReactiveSystem<Entity<Model>>
    {
        public SpawnAllyActionCard() : base(Contexts.Instance.Get<Model>()) { }

        private static Configs     Configs => Services.Get<Configs>();
        private static GameplayHUD HUD     => Services.Get<UI>().GetView<GameplayHUD>();

        protected override ICollector<Entity<Model>> GetTrigger(IContext<Entity<Model>> context)
            => context.CreateCollector(Get<UnitID>().Added());

        protected override bool Filter(Entity<Model> entity) => entity.Is<Ally>();

        protected override void Execute(List<Entity<Model>> entities)
        {
            foreach (var unitID in entities.Select(e => e.Get<UnitID>().Value))
            foreach (var cardID in Configs.Units.UnitConfigs[unitID].RelatedCards)
            {
                var e = Contexts.Instance.Get<Model>()
                                .CreateEntity()
                                .Add<Name, string>("card")
                                .Is<PlayerCard>(true)
                    ;

                Configs.ActionCards.LoadView(cardID)
                       .Entity
                       .Add<Parent, Transform>(HUD.CardsHolder.Root)
                       .AddModel(e)
                    ;
            }
        }
    }
}