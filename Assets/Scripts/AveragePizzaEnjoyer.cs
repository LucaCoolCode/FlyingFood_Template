using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveragePizzaEnjoyer: MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out Food food))
        {
            print("Unternehmensrechtschutzversicherung");
        }
        
    }
}
