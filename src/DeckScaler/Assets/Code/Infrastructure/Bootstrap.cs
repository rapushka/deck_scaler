using UnityEngine;

namespace DeckScaler
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private ServicesConfig _servicesConfig;

		private void Awake()
		{
			var gameStateMachine = new GameStateMachine();
			Services.Init(_servicesConfig, gameStateMachine);

			gameStateMachine.Enter<States.BootstrapState>();
		}
	}
}