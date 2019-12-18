using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int PLAYER = 0;
    public int AI_PLAYER = 1;
    public Text AI_score_txt;
    public Text player_score_txt;
    private int turn;
    private int player_score;
    private int AI_score;
    void Start()
    {
        turn = PLAYER;
        Debug.Log("************ *******turn:"+turn+"******* **************");
        player_score = 0;
        AI_score = 0;
    }

   public void UpdateScore(int score,int player)
    {
        if(player == PLAYER)
        {
            player_score = player_score + score;
            player_score_txt.text = "score: " + player_score.ToString();
        }
        else if (player == AI_PLAYER)
        {
            AI_score = AI_score + score;
            AI_score_txt.text = "score: " + AI_score.ToString();

        }
    }


    public int GetTurn()
    {
        return turn;
    }
    public void SetTurn(int player_turn)
    {
        turn = player_turn;
    }
}
