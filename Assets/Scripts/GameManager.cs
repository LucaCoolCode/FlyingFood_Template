using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int timer = 12;

    private void CountDown()
    {
        timer--;
        print(timer);

        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(CountDown),1,1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
