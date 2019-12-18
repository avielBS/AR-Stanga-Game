using Panda;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public static Animator anim;
    public Transform other_player;
    public GameObject ball;
    public Transform enemy_gate;
    public Transform my_gate;
    public GameObject AI_player;
    private GameController game_controller;
    public int turn;
    float accuraty = 0.5f;
    const float FAR_AWAY =1f;
    const float CLOSE = 2.5f;
    const float FORCE = 200f;
    const float ROTATION_SPEED = 0.8f;
    float visibleRange = 2.0f;

    private void Awake()
    {
        game_controller = GameObject.FindObjectOfType<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
       turn = game_controller.GetTurn();
             
    }
    [Task]
   public bool IsMyTurn()
    {
        if (turn==game_controller.AI_PLAYER)
            return true;
        return false;
    }
    [Task]
   public void SwitchTurn()
    {
        if (IsMyTurn())
        {
           turn = game_controller.PLAYER;
        }
        else
        {
            turn = game_controller.AI_PLAYER;
        }
        game_controller.SetTurn(turn);
        Task.current.Succeed();
    }

    [Task]
    public void GoToBall()
    {
        //Vector3 target = ball.position;
        Vector3 target = new Vector3(ball.transform.position.x, AI_player.transform.position.y, ball.transform.position.z);
        if (Vector3.Distance(AI_player.transform.position, target) > accuraty)
            AI_player.transform.position=target;
      
        if (Task.isInspected) //debug
            Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);

        if (Vector3.Distance(AI_player.transform.position, target) <= accuraty)
            Task.current.Succeed();
        

    }  [Task]
    public void GoToEnemy()
    {
        //Vector3 target = ball.position;
        Vector3 target = new Vector3(other_player.transform.position.x, AI_player.transform.position.y, other_player.transform.position.z);
        if (Vector3.Distance(AI_player.transform.position, target) > accuraty)
            AI_player.transform.position=target;
      
        if (Task.isInspected) //debug
            Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);

        if (Vector3.Distance(AI_player.transform.position, target) <= accuraty)
            Task.current.Succeed();
        

    } [Task]
    public void GoToMyGate()
    {
        Vector3 target = new Vector3(my_gate.transform.position.x, AI_player.transform.position.y,my_gate.transform.position.z);
        if (Vector3.Distance(AI_player.transform.position, target) > accuraty)
            AI_player.transform.position=target;
      
        if (Task.isInspected) //debug
            Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);

        if (Vector3.Distance(AI_player.transform.position, target) <= accuraty)
            Task.current.Succeed();
        

    }
    [Task]
    public bool IsEnemyCloseToGate()
    {
        if (Vector3.Distance(other_player.transform.position, my_gate.transform.position) <= CLOSE)
            return true;
        return false;
      
    }

    [Task]
    public void LookAtTarget()
    {
        Vector3 direction = enemy_gate.transform.position- this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime *ROTATION_SPEED);
        if (Task.isInspected)
            Task.current.debugInfo = string.Format("angle={0}", Vector3.Angle(this.transform.forward, direction));

        if (Vector3.Angle(this.transform.forward, direction) < 5.0f)
            Task.current.Succeed();
    }

    [Task]
    bool SeePlayer()
    {
        Vector3 distance = other_player.transform.position - this.transform.position;

        RaycastHit hit;
        bool seeWall = false;

        Debug.DrawRay(this.transform.position, distance, Color.red);

        if (Physics.Raycast(this.transform.position, distance, out hit))
        {
            if (hit.collider.gameObject.tag == "wall")
            {
                seeWall = true;
            }
        }
        //debug draw line
        if (Task.isInspected)
            Task.current.debugInfo = string.Format("wall={0}", seeWall);

        if (distance.magnitude < visibleRange && !seeWall)
            return true;
        else
            return false;
    }

    [Task]
    public void KickToGate()
    {
        //anim.SetTrigger("isPass");
        ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * FORCE);
        Task.current.Succeed();
    }
    [Task]
    public void BlockEnemy()
    {
        anim.SetTrigger("isSidestep");
        Task.current.Succeed();

    }
    [Task]
    public void GateKeeper()
    {
        anim.SetTrigger("isGoalkeeper");
        Task.current.Succeed();

    }
}







