using System;
using System.Collections.Generic;
using DeckScaler.Utils;

namespace DeckScaler
{
	public class GameStateMachine
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