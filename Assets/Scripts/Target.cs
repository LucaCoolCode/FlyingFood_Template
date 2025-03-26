using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform spawnPointHolder;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject appearEffect;
    [SerializeField] private TMP_Text pointsText;
    private int points = 0;
    private List<Transform> allSpawns = new List<Transform>();

    private void GetSpawns()
    {
        foreach (Transform spawnPoint in spawnPointHolder)
        {
            allSpawns.Add(spawnPoint);
        }
    }

    private void Respawn()
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
        Transform randomSpawn = allSpawns[Random.Range(0, allSpawns.Count)];
        transform.SetPositionAndRotation(randomSpawn.position, randomSpawn.rotation);
        Instantiate(appearEffect, transform.position, transform.rotation);
    }

    private void Awake()
    {
        GetSpawns();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Respawn();
        points++;
        pointsText.text = "points: "+points.ToString();
    }
}

//public class Target : MonoBehaviour
//{
//    [SerializeField] private Transform spawnPointHolder;
//    private List<Transform> allSpawns = new List<Transform>();

//    private void GetSpawns()
//    {
//        foreach (Transform spawnPoint in spawnPointHolder.transform)
//        {
//            allSpawns.Add(spawnPoint);
//        }
//    }

//    private void Respawn()
//    {
//        print(allSpawns.Count);
//        Transform randomSpawn = allSpawns[Random.Range(0, allSpawns.Count)];
//        transform.SetPositionAndRotation(randomSpawn.position, randomSpawn.rotation);
//    }

//    private void Awake()
//    {
//        GetSpawns();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        Respawn();
//    }
//}



//private void Respawn()
//{


//    Transform randomSpawn = allSpawns[Random.Range(0, allSpawns.Length)];
//    transform.SetPositionAndRotation(randomSpawn.position, randomSpawn.rotation);
//    transform.parent = randomSpawn;


//}