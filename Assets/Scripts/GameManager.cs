using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private int timer = 30;

    private void CountDown()
    {
        timer--;
        timerText.text = timer.ToString();

        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        timerText.text = timer.ToString();

        InvokeRepeating(nameof(CountDown),1,1);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
