using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TargetArrow arrowOfKnowlege;
    private int score = 0;
    private AveragePizzaEnjoyer[] enjoyers;

    public void ScoreUpPizza()
    {
        score++;
        scoreText.text = "Tips: " + score;
        ChangeEnjoyer();
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        enjoyers = GetComponentsInChildren<AveragePizzaEnjoyer>();
        ChangeEnjoyer();
    }

    private void ChangeEnjoyer()
    {
        AveragePizzaEnjoyer newEnjoyer;
        do
        {
            newEnjoyer = enjoyers[Random.Range(0, enjoyers.Length)];
        }
        while (arrowOfKnowlege.target == newEnjoyer.transform);
        
        arrowOfKnowlege.target = newEnjoyer.transform;
        newEnjoyer.isHungry = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
