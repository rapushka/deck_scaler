using System;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

// ReSharper disable SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault - Fuck you.

namespace DeckScaler
{
    public interface IAffectsFactory
    {
        Entity<Game> Create(AffectData data, EntityID senderID, EntityID targetID);
    }

    public class AffectsFactory : IAffectsFactory
    {
        public Entity<Game> Create(AffectData data, EntityID senderID, EntityID targetID)
        {
            var type = data.Type;

            return type switch
            {
                AffectType.DealDamage => CreateDealDamage(data.Value, senderID, targetID),
                AffectType.Heal       => CreateHeal(data.Value, senderID, targetID),
                AffectType.StealMoney => CreateStealMoney(data.Value, senderID, targetID),
                _                     => throw new ArgumentOutOfRangeException(),
            };
        }

        private Entity<Game> CreateDealDamage(int value, EntityID senderID, EntityID targetID)
            => CreateBaseAffect(AffectType.DealDamage, value)
                .Is<DealDamageAffect>(true)
                .Add<SenderID, EntityID>(senderID)
                .Add<TargetID, EntityID>(targetID)
                .Bump();

        private Entity<Game> CreateHeal(int value, EntityID senderID, EntityID targetID)
            => CreateBaseAffect(AffectType.Heal, value)
                .Is<HealAffect>(true)
                .Add<SenderID, EntityID>(senderID)
                .Add<TargetID, EntityID>(targetID)
                .Bump();

        private Entity<Game> CreateStealMoney(int value, EntityID senderID, EntityID targetID)
            => CreateBaseAffect(AffectType.Heal, value)
                .Is<StealMoneyAffect>(true)
                .Add<SenderID, EntityID>(senderID)
                .Add<TargetID, EntityID>(targetID)
                // .Add<StealMoneyFrom, Side>(side.Flip()) TODO: mb??
                .Bump();

        private Entity<Game> CreateBaseAffect(AffectType type, int value)
            => CreateEntity.OneFrame()
                .Add<Affect>()
                .Add<AffectID, AffectType>(type)
                .Add<AffectValue, int>(value)
                .Bump();
    }
}