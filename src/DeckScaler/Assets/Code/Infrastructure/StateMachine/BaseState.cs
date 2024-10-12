namespace DeckScaler
{
	public abstract class BaseState
	{
		public static TState Create<TState>(StateMachine stateMachine)
			where TState : BaseState, new()
		{
			return new TState { StateMachine = stateMachine };
		}

		protected StateMachine StateMachine { get; private set; }

		public abstract void Enter();

		public virtual void Exit() { }
	}
}