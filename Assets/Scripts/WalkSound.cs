using System.Collections;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    private AudioSource walkSound;

    private void Start() 
    {
        walkSound = GetComponent<AudioSource>();
        StartCoroutine(PlaySounds());
    }

    IEnumerator PlaySounds()
    {
        while (true)
        {
            walkSound.Play();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
