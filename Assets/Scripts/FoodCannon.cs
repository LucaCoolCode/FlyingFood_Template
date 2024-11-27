using System.Collections.Generic;
using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] private float foodSpeed = 30;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private GameObject ShootEffect;
    [SerializeField] private List<GameObject> FoodList;
     
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {


            Shoot();


        }
    }

    private void Shoot()
    {
        GameObject randomFood = FoodList[Random.Range(0, FoodList.Count)];
        GameObject newFood = Instantiate(randomFood, ShootPoint.position, Random.rotation);
        newFood.GetComponent<Rigidbody>().velocity = ShootPoint.forward * foodSpeed;
        Instantiate(ShootEffect, ShootPoint.position, Quaternion.identity);
    }
}
