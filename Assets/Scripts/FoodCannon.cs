using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] private float foodSpeed = 10;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject[] food;

    private void Shoot()
    {
        GameObject newFood = Instantiate(food[0], shootPoint.position, Random.rotation);
        newFood.GetComponent<Rigidbody>().velocity = shootPoint.forward * foodSpeed;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
