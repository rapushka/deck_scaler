using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public class EnableOnlyInPlayerPrepareComponentBehaviour : ComponentBehaviour<Game, Component.EnableOnlyOnPlayerTurn> { }
}