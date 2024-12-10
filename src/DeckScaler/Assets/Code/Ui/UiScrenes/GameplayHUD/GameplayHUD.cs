using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class GameplayHUD : BaseUiScreen
    {
        [field: SerializeField] public EntityBehaviour<Game>[] Behaviours { get; private set; }
    }
}