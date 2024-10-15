using UnityEngine;

public class Game : State
{
    public override void Enter()
    {
        Debug.Log("Enter Game");
    }

    public override void Tick()
    {
        Debug.Log("Tick Game");
    }

    public override void Exit()
    {
        Debug.Log("Exit Game");
    }
}