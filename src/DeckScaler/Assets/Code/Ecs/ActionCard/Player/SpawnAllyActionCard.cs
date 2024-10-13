using System.Collections.Generic;
using System.Linq;
using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Ui.Views.GameplayHUD;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<DeckScaler.Scope>;

namespace DeckScaler.Systems
{
    public sealed class SpawnAllyActionCard : ReactiveSystem<Entity<Scope>>
    {
        public SpawnAllyActionCard() : base(Contexts.Instance.Scope()) { }

        private static Configs     Configs => Services.Get<Configs>();
        private static GameplayHUD HUD     => Services.Get<UI>().GetView<GameplayHUD>();

        protected override ICollector<Entity<Scope>> GetTrigger(IContext<Entity<Scope>> context)
            => context.CreateCollector(Get<UnitID>().Added());

        protected override bool Filter(Entity<Scope> entity) => entity.Is<Ally>();

        protected override void Execute(List<Entity<Scope>> entities)
        {
            foreach (var unitID in entities.Select(e => e.Get<UnitID>().Value))
            foreach (var cardID in Configs.Units.UnitConfigs[unitID].RelatedCards)
            {
                Configs.ActionCards.Load(cardID)
                       .Entity
                       .Is<PlayerCard>(true)
                       .Add<Parent, Transform>(HUD.CardsHolder.Root)
                    ;
            }
        }
    }
}