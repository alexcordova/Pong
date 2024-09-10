using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreRight_txt, scoreLeft_txt;
    [SerializeField] private Transform paddle1, paddle2, ball;

    private int scoreRight, scoreLeft;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void ScoredRight()
    {
        scoreRight++;
        scoreRight_txt.text = scoreRight.ToString();
    }

    public void ScoredLeft()
    {
        scoreLeft++;
        scoreLeft_txt.text = scoreLeft.ToString();
    }

    public void Restart()
    {
        paddle1.position = new Vector2(paddle1.position.x, 0);
        paddle2.position = new Vector2(paddle2.position.x, 0);
        ball.position = new Vector2(0, 0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
