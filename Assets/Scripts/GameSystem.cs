using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [Header("Spawn Market Objects")]
    [SerializeField] private Transform SpawnPoint;
    Vector3 SpawnPosition;
    [SerializeField] private Transform MarketObjectParent;
    int MarketObjectCount;




    void Start()
    {
        SpawnPosition = SpawnPoint.position;
        MarketObjectCount = MarketObjectParent.childCount;

        float spawnSpeed = Globals.Instance.GetSpawnSpeed();
        InvokeRepeating("SpawnMarketObjects",1,spawnSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMarketObjects()
    {
        int randomObject = Random.Range(0,MarketObjectCount);
        GameObject selectedObject = MarketObjectParent.GetChild(randomObject).gameObject;
        GameObject cloneObject = Instantiate(selectedObject,SpawnPosition,selectedObject.transform.rotation);
        cloneObject.GetComponent<MarketObject>().SetStatus(true);
    }
}
