using System;
using System.Collections.Generic;
using DeckScaler.Utils;

namespace DeckScaler
{
	public class StateMachine
	{
		private readonly Dictionary<Type, BaseState> _states = new();
		private BaseState _currentState;

		public void Enter<TState>()
			where TState : BaseState, new()
		{
			var nextState = _states.GetOrAdd(typeof(TState), NewState<TState>);

			_currentState?.Exit();
			_currentState = nextState;
			_currentState.Enter();
		}

		private TState NewState<TState>()
			where TState : BaseState, new()
			=> BaseState.Create<TState>(this);
	}
}