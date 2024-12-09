using System;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public static class CurrentTurnExtensions
    {
        public static bool IsPlayerTurn(this Entity<Game> turnTracker) => IsSideTurn(turnTracker, Side.Player);

        public static bool IsEnemyTurn(this Entity<Game> turnTracker) => IsSideTurn(turnTracker, Side.Enemy);

        private static bool IsSideTurn(Entity<Game> turnTracker, Side turn)
        {
#if UNITY_EDITOR
            if (!turnTracker.Is<TurnTracker>())
                throw new InvalidOperationException("This extension must be called only on Turn Tracker");
#endif

            return turnTracker.Get<CurrentTurn, Side>() == turn;
        }
    }
}