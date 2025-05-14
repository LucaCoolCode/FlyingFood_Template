using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void ScoreUpPizza()
    {
        score++;
        scoreText.text = "Tips: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
