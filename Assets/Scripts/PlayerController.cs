using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 20.0F;
    float rotationSpeed = 90.0F;

    public Joystick joystick;
    private GameController game_controller;
    private int turn;

    private void Awake()
    {
        game_controller = GameObject.FindObjectOfType<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        turn = game_controller.GetTurn();

    }
    public bool IsMyTurn()
    {
        if (turn == game_controller.PLAYER)
        {

            return true;
        }
        return false;
    }
    public void SwitchTurn()
    {
        if (IsMyTurn())
        {
            turn = game_controller.AI_PLAYER;
        }
        else
        {
            turn = game_controller.PLAYER;
        }
        game_controller.SetTurn(turn);
    }
    // Update is called once per frame
    void Update()
    {
        float translation = joystick.Vertical * speed;
        float rotation = joystick.Horizontal * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}
