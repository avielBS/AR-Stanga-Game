using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2, 0.5f);
    }

   void Spawn()
    {
        GameObject obj = Instantiate(ball, this.transform.position, Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
