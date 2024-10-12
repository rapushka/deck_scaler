using UnityEngine;

namespace DeckScaler
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private ServicesConfig _servicesConfig;

		private void Awake()
		{
			Services.Init(_servicesConfig);

			var gameStateMachine = new StateMachine();
			gameStateMachine.Enter<State.Bootstrap>();
		}
	}
}