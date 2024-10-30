using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject destroyEffect;

    private void SelfDestroy()
    {
        Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SelfDestroy();
    }
}
