using UnityEngine;

namespace DeckScaler
{
    public class GameVictoryState : GameState
    {
        public override void Enter()
        {
            Debug.Log("You've won, hooray!");
            StateMachine.Enter<EndRunState>();
        }
    }
}