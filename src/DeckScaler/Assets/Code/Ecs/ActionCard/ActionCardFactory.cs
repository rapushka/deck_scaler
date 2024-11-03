using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Ui.Views.GameplayHUD;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.ActionCard
{
    public class ActionCardFactory
    {
        private static GameplayHUD HUD => Services.Get<UI>().GetView<GameplayHUD>();

        public void Create(string cardID)
        {
            var e = Contexts.Instance.Get<Model>()
                            .CreateEntity()
                            .Add<Name, string>("card")
                            .Is<PlayerCard>(true)
                ;

            Services.Get<Configs>().ActionCards.LoadView(cardID)
                    .Entity
                    .Add<Parent, Transform>(HUD.CardsHolder.Root)
                    .AddModel(e)
                ;
        }
    }
}