using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Game : State
    {
        public Button pauseButton;
        public Button gameOverButton;
        
        public override void Enter()
        { 
            Debug.Log("Enter Game");
            pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
            gameOverButton = GameObject.Find("GameOver").GetComponent<Button>();
            
            pauseButton.onClick.AddListener(PauseTheGame);
            gameOverButton.onClick.AddListener(GameOver);
            
        }

        public override void Tick()
        {
            Debug.Log("Tick Game");
        }

        public override void Exit()
        { 
            Debug.Log("Exit Game");
            
            pauseButton.onClick.RemoveListener(PauseTheGame);
            gameOverButton.onClick.RemoveListener(GameOver);
        }

        public void PauseTheGame()
        {
            Debug.Log("Pause Game");
            
            GetComponent<StateMachine>().ChangeState(GetComponent<PauseGame>());
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            
            GetComponent<StateMachine>().ChangeState(GetComponent<GameOver>());
        }
    }
}
