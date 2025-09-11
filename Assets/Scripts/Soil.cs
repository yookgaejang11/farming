using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public Crop crop;
    public bool canGet = false;
    public bool canSet = true;
    public int watering = 50;

    // Start is called before the first frame update
    void Start()
    {
        watering = Mathf.Clamp(watering, 0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
