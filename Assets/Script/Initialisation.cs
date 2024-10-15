using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Initialisation : State
{
    public SceneReference sceneToLoad;
    private AsyncOperation async;
    
    public override void Enter()
    {
        // SceneManager.LoadScene("Menu");
        async = SceneManager.LoadSceneAsync(sceneToLoad.BuildIndex);
    }

    public override void Tick()
    {
        Debug.Log("Tick Initialisation");
        
        if (async.progress >= 1f)
        {
            //  Transition : 
            GetComponent<StateMachine>().ChangeState(GetComponent<Menu>());
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Initialisation");
    }
}