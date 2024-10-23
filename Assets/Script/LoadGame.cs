using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Script
{
    public class LoadGame : State
    {
        private AsyncOperation async;
        
        public override void Enter()
        {
            async = SceneManager.LoadSceneAsync(2);
        }

        public override void Tick()
        { 
            Debug.Log("Tick LoadGame");

            if (async.progress >= 1f)
            {
                GetComponent<StateMachine>().ChangeState(GetComponent<Game>());
            }
            
        }
        public override void Exit() 
        {
            Debug.Log("Exiting LoadGame"); 
        }
    }
}
