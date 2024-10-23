using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class PauseGame : State
    {
        public Button pauseButton;
        
        public override void Enter()
        { 
            Debug.Log("Enter Pause");
            
            pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
            pauseButton.onClick.AddListener(UnPauseTheGame);
        }

        public override void Tick()
        {
            Debug.Log("Tick Pause");
        }

        public override void Exit()
        { 
            Debug.Log("Exit Pause");
        }
        
        public void UnPauseTheGame()
        {
            Debug.Log("Pause Game");
            
            GetComponent<StateMachine>().ChangeState(GetComponent<Game>());
        }
    }
}
