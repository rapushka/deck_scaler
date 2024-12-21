using System;

namespace DeckScaler
{
    public enum StageType
    {
        Unknown = 0,
        Fight = 1,
        Recruitment = 2,
    }

    public static class StageTypeExtensions
    {
        public static void Visit(
            this StageType @this,
            Action onFight,
            Action onRecruitment
        )
        {
            if (@this is StageType.Fight)
                onFight.Invoke();
            else if (@this is StageType.Recruitment)
                onRecruitment.Invoke();
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}