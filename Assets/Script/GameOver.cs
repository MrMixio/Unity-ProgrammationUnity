using UnityEngine;

namespace Script
{
    public class GameOver : State
    {
        public override void Enter()
        { 
            Debug.Log("Enter Game Over");
        }

        public override void Tick()
        {
            Debug.Log("Tick Game Over");
        }

        public override void Exit()
        { 
            Debug.Log("Exit Game Over");
        }
    }
}
