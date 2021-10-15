using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketObject : MonoBehaviour
{
    Rigidbody ObjectRigidbody;
    Outline ObjectOutline;
    bool IsEnabled = false;
    bool IsReaded = false;
    bool IsReading = false;
    bool IsWrong = false;
    float ReadStartTime = 0;
    float Speed = 3;
    float ReadSpeed = 1;

    void Awake()
    {
        ObjectRigidbody = transform.GetComponent<Rigidbody>();
        ObjectOutline = transform.GetComponent<Outline>();
    }

    void Start()
    {
        Speed = Globals.Instance.GetObjectSpeed();
        ReadSpeed = Globals.Instance.GetBarcodeTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ObjectControl();
        if(!IsReaded && IsReading) TimeControl();
    }

    void TimeControl()
    {
        if(Time.time - ReadStartTime > ReadSpeed)
        {
            ObjectOutline.OutlineColor = Globals.Instance.OutlineColors[0];
            IsReading = false;
            IsReaded = true;
        }
    }

    void ObjectControl()
    {
        if(IsEnabled)
        {
            int layerMask = 1 << 8;
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up,Vector3.down, out hit, 1.5f, layerMask))
            {
                
                if(hit.transform.name == "Band")
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * Speed,Space.World);
                }
            }

            

        }
        
    }

    public bool GetStatus()
    {
        return IsEnabled;
    }

    public void SetStatus(bool isEnabled)
    {
        
        ObjectRigidbody.isKinematic = !isEnabled;
        IsEnabled = isEnabled;

        if(isEnabled)
        {
            bool isWrong = Random.Range(0,1f) < Globals.Instance.GetWrongObjectRatio();
            IsWrong = isWrong;
            if(IsWrong)
            {
                ObjectOutline.OutlineColor = Globals.Instance.OutlineColors[1];
            }
        }
    }

    public void StartBarcodeReading()
    {
        if(!IsReaded)
        {
            ReadStartTime = Time.time;
            IsReading = true;
            
        }

    }

    public void StopBarcodeReading()
    {
        if(!IsReaded)
        {
            IsReading = false;
        }
        
    }
}
