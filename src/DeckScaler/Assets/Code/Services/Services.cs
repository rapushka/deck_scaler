using DeckScaler.Service;

namespace DeckScaler
{
	public class Services
	{
		public static void Init(ServicesConfig config, GameStateMachine stateMachine)
			=> Instance = new Services(config, stateMachine);

		private Services(ServicesConfig config, GameStateMachine stateMachine)
		{
			UI = new UI();
			Cameras = new Cameras(config.MainCamera, config.UiCamera);
			StateMachine = stateMachine;
		}

		public static Services Instance { get; private set; }

		public UI UI { get; }

		public Cameras Cameras { get; }

		public GameStateMachine StateMachine { get; }
	}
}