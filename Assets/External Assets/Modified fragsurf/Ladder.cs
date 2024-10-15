using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Empty class for defining objects as ladders
    // Probably inefficient, but I didn't want to use tags or layers

    [SerializeField] private bool requiresVisibility = true;

    [SerializeField] private float visibilityAngle = 30f;

    private Transform cameraTsfm;

    private void Start()
    {
        var playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO != null)
        {
            cameraTsfm = playerGO.transform; // PlayerCameraTransform.Instance;
        }
        else
        {
            Debug.LogError("No GameObject tagged Player in scene");
        }
    }

    public bool IsUsable()
    {
        if (requiresVisibility)
        {
            Vector3 dir = transform.position - cameraTsfm.position;
            dir.y = 0;
            Vector3 lookDir = cameraTsfm.forward;
            lookDir.y = 0f;


            if (Vector3.Angle(dir, lookDir) > visibilityAngle)
            {
                Debug.DrawLine(cameraTsfm.position, transform.position + Vector3.up * cameraTsfm.position.y,
                    Color.red);
                return false;
            }

            Debug.DrawLine(cameraTsfm.position, transform.position + Vector3.up * cameraTsfm.position.y, Color.green);
        }

        return true;
    }
}