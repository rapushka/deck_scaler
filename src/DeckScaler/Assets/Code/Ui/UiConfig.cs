using System;
using UnityEngine;

namespace DeckScaler.Service
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UiConfig))]
    public class UiConfig : ScriptableObject
    {
        [field: SerializeField] public UiCanvas CanvasPrefab { get; private set; }

        [field: SerializeField] public ScreensMap Screens { get; private set; }

        [Serializable]
        public class ScreensMap : Map<Type, BaseUiScreen>
        {
            protected override Type SelectKey(BaseUiScreen value) => value.GetType();

            public TScreen Get<TScreen>()
                where TScreen : BaseUiScreen
                => (TScreen)this[typeof(TScreen)];
        }
    }
}