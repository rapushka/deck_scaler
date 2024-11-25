using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEditor;

namespace DeckScaler.Editor
{
    [CustomPropertyDrawer(typeof(GameComponentID))]
    public class GameComponentIDDrawer : ComponentIDDrawer<Game> { }
}