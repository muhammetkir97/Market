using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals Instance;

    public Color[] OutlineColors;

    int CurrentLevel = 0;
    float BaseSpawnSpeed = 1.5f;
    float MultiplierSpawnSpeed = 1.02f;

    float BaseObjectSpeed = 1;
    float MultiplierObjectSpeed = 1.02f;

    float BarcodeTime = 0.2f;
    float WrongObjectRatio = 0.3f;



    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentLevel()
    {
        return CurrentLevel;
    }

    public float GetSpawnSpeed()
    {
        float speed = BaseSpawnSpeed;

        for(int i=0; i<GetCurrentLevel(); i++)
        {
            speed = speed * (2 - MultiplierSpawnSpeed);
        }

        return speed;

    }

    public float GetObjectSpeed()
    {
        float speed = BaseObjectSpeed;

        for(int i=0; i<GetCurrentLevel(); i++)
        {
            speed = speed * MultiplierObjectSpeed;
        }

        return speed;
    }

    public float GetBarcodeTime()
    {
        return BarcodeTime;
    }

    public float GetWrongObjectRatio()
    {
        return WrongObjectRatio;
    }
}
