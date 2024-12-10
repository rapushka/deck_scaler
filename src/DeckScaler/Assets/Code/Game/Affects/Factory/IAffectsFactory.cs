using DeckScaler.Component;

namespace DeckScaler
{
    public interface IAffectsFactory
    {
        void Create(AffectData affectData, EntityID senderID, EntityID targetID);
    }

    public class AffectsFactory : IAffectsFactory
    {
        public void Create(AffectData affectData, EntityID senderID, EntityID targetID)
        {
            var type = affectData.Type;

            CreateEntity.OneFrame()
                .Add<Affect>()
                .Add<AffectID, AffectType>(type)
                .Add<AffectValue, int>(affectData.Value)
                .Add<SenderID, EntityID>(senderID)
                .Add<TargetID, EntityID>(targetID)

                // Flag Components
                .Is<DealDamageAffect>(type is AffectType.DealDamage)
                .Is<HealAffect>(type is AffectType.Heal)
                .Is<StealMoneyAffect>(type is AffectType.StealMoney)
                ;
        }
    }
}