using DeckScaler.Service;

namespace DeckScaler
{
	public class Services
	{
		public static void Init(ServicesConfig config) => Instance = new Services(config);

		private Services(ServicesConfig config)
		{
			UI = new UI();
			Cameras = new Cameras(config.MainCamera, config.UiCamera);
		}

		public static Services Instance { get; private set; }

		public UI UI { get; }

		public Cameras Cameras { get; }
	}
}