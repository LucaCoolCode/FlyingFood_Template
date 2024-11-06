using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegner : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("hit");
    }
}
