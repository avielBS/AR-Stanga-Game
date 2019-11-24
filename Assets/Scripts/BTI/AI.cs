using Panda;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform other_player;
    public Transform ball;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    

    [Task]
    public void GoToBall()
    {
        Vector3 target = ball.transform.position;
        agent.SetDestination(target);
        if (Task.isInspected)
            Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            Task.current.Succeed();
        }

    }
   
}
