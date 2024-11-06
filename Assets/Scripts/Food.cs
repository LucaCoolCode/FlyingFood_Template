using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
