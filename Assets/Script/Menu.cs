using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Menu : State
    {
        private StateMachine stateMachine;
        public Button startGameButton;
    
        public override void Enter()
        {
            Debug.Log("Enter Menu");
            startGameButton = GameObject.Find("StartButton").GetComponent<Button>();
            stateMachine = FindObjectOfType<StateMachine>();
            startGameButton.onClick.AddListener(StartGame);
        }

        public override void Tick()
        {
            Debug.Log("Tick Menu");
        }

        public override void Exit()
        {
            Debug.Log("Exit Menu");
        }
    
        public void StartGame()
        {
            GetComponent<StateMachine>().ChangeState(GetComponent<LoadGame>());
        }
    }
}