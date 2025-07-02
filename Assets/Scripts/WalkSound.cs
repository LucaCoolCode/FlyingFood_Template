using System.Collections;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    private AudioSource walkSound;
    private PlayerMovement movement;

    private void Start() 
    {
        walkSound = GetComponent<AudioSource>();
        movement = GetComponent<PlayerMovement>();
        StartCoroutine(PlaySounds());
    }

    IEnumerator PlaySounds()
    {
        while (true)
        {
            if (movement.isWalking)
            {
                walkSound.Play();
                yield return new WaitForSeconds(0.5f);
            }

        }
    }
}
