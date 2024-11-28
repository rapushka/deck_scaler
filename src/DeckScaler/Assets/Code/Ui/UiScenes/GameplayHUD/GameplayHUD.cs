using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class GameplayHUD : UiScene
    {
        [field: SerializeField] public EntityBehaviour<Game> TeamRoot   { get; private set; }
        [field: SerializeField] public EntityBehaviour<Game> TeamScroll { get; private set; }
    }
}