using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MarkerController : MonoBehaviour

{
   
    private void OnTrackingFound()
    {
        
            var rigidBody = GetComponentsInChildren<Rigidbody>(true);

            foreach (var component in rigidBody)
            {
                if (component.name == "Soccer Ball")
                    component.useGravity = true;
            }
       

     

    }

    
}
