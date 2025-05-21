using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveragePizzaEnjoyer: MonoBehaviour
{
    public bool isHungry;
    private void OnCollisionEnter(Collision collision)
    {

        if (isHungry && collision.gameObject.TryGetComponent(out Food food))
        {
            isHungry = false;
            GameManager.Instance.ScoreUpPizza();

        }

    }
}
