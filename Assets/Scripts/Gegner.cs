using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegner : MonoBehaviour
{
    [SerializeField] private Transform spawnPointHolder;

    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject appearEffect;
    private List<Transform> allSpawns = new List<Transform>();

    private void Awake()
    {
        foreach (Transform spawnPoint in spawnPointHolder)
        {
            allSpawns.Add(spawnPoint);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Respawn();
    }

    private void Respawn()
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
        Transform randomSpawn = allSpawns[Random.Range(0, allSpawns.Count)];
        transform.SetPositionAndRotation(randomSpawn.position, randomSpawn.rotation);
        Instantiate(appearEffect, transform.position, transform.rotation);


    }
}
