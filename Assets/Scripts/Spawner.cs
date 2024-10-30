using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    [SerializeField] private Transform target;
    [SerializeField] private GameObject appearEffect;
    [SerializeField] private GameObject hitEffect;
    private Transform[] spawnPoints;

    public void Respawn()
    {
        Instantiate(hitEffect, target.position, target.rotation);

        Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        target.SetPositionAndRotation(randomSpawn.position, randomSpawn.rotation);
        target.parent = randomSpawn;

        Instantiate(appearEffect, target.position, target.rotation);
    }

    private void GetSpawnPoints()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            print(i);
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    private void Awake()
    {
        instance = this;
        GetSpawnPoints();
    }
}
