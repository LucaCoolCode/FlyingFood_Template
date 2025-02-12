<<<<<<< Updated upstream
using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] private float shootSpeed = 30;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject food;

    private void Shoot()
    {
        GameObject newFood = Instantiate(food, shootPoint.position, Random.rotation);
        newFood.GetComponent<Rigidbody>().velocity = shootPoint.forward * shootSpeed;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
=======
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
>>>>>>> Stashed changes
