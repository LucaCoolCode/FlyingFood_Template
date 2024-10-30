using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.IncreaseScore();
        Spawner.instance.Respawn();
    }
}
