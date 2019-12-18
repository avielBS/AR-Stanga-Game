using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using Vuforia;
using Panda.Examples.PlayTag;

public class init : MonoBehaviour
{
    public ImageTargetBehaviour my_target;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (my_target.CurrentStatus != TrackableBehaviour.Status.NO_POSE && counter==0)
        {
            //gameObject.AddComponent<PandaBehaviour>();
           PandaBehaviour p= gameObject.GetComponent<PandaBehaviour>();
           p.enabled = true;

 
            counter++;
        }
    }
}
