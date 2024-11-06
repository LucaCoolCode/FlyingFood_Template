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
        GameObject newFood = Instantiate(food, ShootPoint.position, Random.rotation);
        newFood.GetComponent<Rigidbody>().velocity = ShootPoint.forward * foodSpeed;
        
    }
}
