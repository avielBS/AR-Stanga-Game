using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PausePhysics : MonoBehaviour
{
    public ImageTargetBehaviour my_target;
    private float originalTimeScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        originalTimeScale = Time.timeScale;


    }

    // Update is called once per frame
    void Update()
    {
        if (my_target.CurrentStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Time.timeScale = 0f;
        }
        else
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = originalTimeScale;
            }
        }
        
    }
}
