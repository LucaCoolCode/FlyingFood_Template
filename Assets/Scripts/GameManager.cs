using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score;

    public void IncreaseScore()
    {
        score++;
        print(score);
    }

    private void Awake()
    {
        instance = this;
    }
}
