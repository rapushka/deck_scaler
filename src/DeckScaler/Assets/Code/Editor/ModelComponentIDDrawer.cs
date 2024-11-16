using Entitas.Generic;
using UnityEditor;

namespace DeckScaler.Editor
{
    [CustomPropertyDrawer(typeof(ModelComponentID))]
    public class ModelComponentIDDrawer : ComponentIDDrawer<Game> { }
}