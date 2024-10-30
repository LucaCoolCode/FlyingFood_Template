using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] private float foodSpeed = 30;
    [SerializeField] private GameObject food;
    [SerializeField] private Transform ShootPoint;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {


            Shoot();


        }
    }

    private void Shoot()
    {
        Instantiate(food, ShootPoint.position, Random.rotation);
        
    }
}
