using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcodeZone : MonoBehaviour
{
    float BarcodeTime = 1;
    
    void Start()
    {
        BarcodeTime = Globals.Instance.GetBarcodeTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        MarketObject temp = other.GetComponent<MarketObject>();
        if(temp != null)
        {
            temp.StartBarcodeReading();
        }
    }

    void OnTriggerStay(Collider other)
    {
        
        
    }

    void OnTriggerExit(Collider other)
    {
        MarketObject temp = other.GetComponent<MarketObject>();
        if(temp != null)
        {
            temp.StopBarcodeReading();
        }
        
    }
}
