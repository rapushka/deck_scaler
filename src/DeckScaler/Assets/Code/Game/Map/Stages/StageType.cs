using System;

namespace DeckScaler
{
    public enum StageType
    {
        Unknown = 0,
        Fight = 1,
        Recruitment = 2,
        Shop = 3,
    }

    public static class StageTypeExtensions
    {
        public static void Visit(
            this StageType @this,
            Action onFight,
            Action onRecruitment,
            Action onShop
        )
        {
            if (@this is StageType.Fight)
                onFight.Invoke();
            else if (@this is StageType.Recruitment)
                onRecruitment.Invoke();
            else if (@this is StageType.Shop)
                onShop.Invoke();
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}