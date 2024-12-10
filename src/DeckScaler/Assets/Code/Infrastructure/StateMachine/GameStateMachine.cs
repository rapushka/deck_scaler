using System;
using System.Collections.Generic;
using DeckScaler.Service;

namespace DeckScaler
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState>()
            where TState : GameState, new();
    }

    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, GameState> _states = new();
        private GameState _currentState;

        public void Enter<TState>()
            where TState : GameState, new()
        {
            var nextState = _states.GetOrAdd(typeof(TState), NewState<TState>);

            _currentState?.Exit();
            _currentState = nextState;
            _currentState.Enter();
        }

        private TState NewState<TState>()
            where TState : GameState, new()
            => GameState.Create<TState>(this);
    }
}