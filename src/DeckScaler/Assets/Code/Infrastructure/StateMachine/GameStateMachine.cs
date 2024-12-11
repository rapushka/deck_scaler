using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DeckScaler.Service;

namespace DeckScaler
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState>() where TState : GameState, new();

        void Enter<TState, TData>(TData data) where TState : GameState, IPayload<TData>, new();
    }

    public class GameStateMachine : IGameStateMachine, IUpdatable
    {
        private readonly Dictionary<Type, GameState> _states = new();

        private GameState _pendingState;
        private GameState _currentState;

        public void Enter<TState>()
            where TState : GameState, new()
        {
            if (_pendingState is not null)
                throw new InvalidOperationException("State Machine Already has pending State!");

            _pendingState = GetState<TState>();

            if (_currentState is null)
                TransferToPendingState();
        }

        public void Enter<TState, TData>(TData data)
            where TState : GameState, IPayload<TData>, new()
        {
            if (_pendingState is not null)
                throw new InvalidOperationException("State Machine Already has pending State!");

            _pendingState = GetState<TState>();
            ((TState)_pendingState).SetData(data);

            if (_currentState is null)
                TransferToPendingState();
        }

        private GameState GetState<TState>()
            where TState : GameState, new()
            => _states.GetOrAdd(typeof(TState), () => GameState.Create<TState>(this));

        public void UpdateManually() => ProcessUpdate().Forget();

        private async UniTaskVoid ProcessUpdate()
        {
            await _currentState.Update();

            if (_pendingState is not null)
                TransferToPendingState();
        }

        private void TransferToPendingState()
        {
            _currentState?.Exit();

            _currentState = _pendingState;
            _pendingState = null;

            _currentState.Enter();
        }
    }
}