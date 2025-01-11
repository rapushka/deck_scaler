namespace DeckScaler
{
    internal static class MoneyExtensions
    {
        public static bool IsEnough(this int current, int needed) => current >= needed;
    }
}