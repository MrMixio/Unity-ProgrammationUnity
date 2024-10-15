using UnityEngine;

public class Menu : State
{
    public override void Enter()
    {
        Debug.Log("Enter Menu");
        
        
    }

    public override void Tick()
    {
        Debug.Log("Tick Menu");
    }

    public override void Exit()
    {
        Debug.Log("Exit Menu");
    }
}