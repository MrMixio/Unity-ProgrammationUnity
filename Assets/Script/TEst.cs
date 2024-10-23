using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class TEst : MonoBehaviour
{
    public Game gameScript; 
    
    // Start is called before the first frame update
    void Start()
    {
        gameScript = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameScript != null)
        {
            Debug.Log("gameScript is found");
        }
    }
}
