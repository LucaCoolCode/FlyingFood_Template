using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfMap : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject[] maps;
    private Vector3 lastStartPos;
    

    // Start is called before the first frame update
    void Start()
    {
        lastStartPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < lastStartPos.y - 50)
        {
            print("Unternehmensversicherung");
            lastStartPos = player.transform.position;
            Instantiate(maps[Random.Range(0,maps.Length)],player.transform.position-Vector3.up*10,Quaternion.identity);
        }
    }
}
