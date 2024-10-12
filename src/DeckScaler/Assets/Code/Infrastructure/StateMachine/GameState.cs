namespace DeckScaler
{
	public abstract class GameState
	{
		public static TState Create<TState>(GameStateMachine stateMachine)
			where TState : GameState, new()
		{
			return new TState { StateMachine = stateMachine };
		}

		protected GameStateMachine StateMachine { get; private set; }

		public abstract void Enter();

		public virtual void Exit() { }
	}
}