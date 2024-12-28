using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public class UnitsUtil
    {
        public Entity<Game> TakeToTeam(Entity<Game> unit)
            => ToAlly(
                unit
                    // from recruit
                    .Is<RecruitmentCandidate>(false)
                    .Is<TakeToTeam>(false)
            );

        public Entity<Game> ToAlly(Entity<Game> unit)
            => unit
                // add components, that makes him the teammate
                .Is<Draggable>(true)
                .Is<Teammate>(true)
                .Is<Ally>(true)
                .Add<OnSide, Side>(Side.Player)
                .Bump();
    }
}