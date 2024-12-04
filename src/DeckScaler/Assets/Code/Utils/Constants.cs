using UnityEngine;

namespace DeckScaler
{
    public static class Constants
    {
        public const int TeamSlotsStartingIndex = 0;

        public const string MenuPrefix = "375/Deck Scaler/";

        public static class TableID
        {
            public const string Table = "ID List";

            // # Categories
            public const string Units = "Units/";
            public const string Allies = Units + "Ally/";
            public const string Enemies = Units + "Enemy/";
        }

        public static class Animation
        {
            public const float DefaultDuration = 0.3f;

            public static readonly AnimationCurve LinearEasing = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        }

        public static class Sign
        {
            public const int Left = -1;
            public const int Center = 0;
            public const int Right = 1;
        }
    }
}