using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{   
    [SerializeField] private TargetArrow arrowOfKnowlege;
    private AveragePizzaEnjoyer[] enjoyers;
    
    // Start is called before the first frame update
    void Start()
    {
        enjoyers = GetComponentsInChildren<AveragePizzaEnjoyer>();
        arrowOfKnowlege.target = enjoyers [Random.Range(0,enjoyers.Length)].transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
