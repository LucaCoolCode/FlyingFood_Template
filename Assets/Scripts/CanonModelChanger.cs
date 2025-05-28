using UnityEngine;

public class CanonModelChanger : MonoBehaviour
{
    private int currentModelIndex = 0;

    private void Start()
    {
        InvokeRepeating(nameof(PickNextModel), 0, 0.01f);
    }

    private void PickNextModel()
    {
        transform.GetChild(currentModelIndex).gameObject.SetActive(false);
        currentModelIndex++;
        if (currentModelIndex >= transform.childCount)
        {
            currentModelIndex = 0;
        }
        transform.GetChild(currentModelIndex).gameObject.SetActive(true);
    }
}
