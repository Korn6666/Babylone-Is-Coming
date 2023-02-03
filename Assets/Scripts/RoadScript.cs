using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{

    private Transform[] RoadSprites;
    void Start()
    {
        RoadSprites = gameObject.GetComponentsInChildren<Transform>();
        // foreach(Transform RoadSprite in RoadSprites)
        // {
        //     Debug.Log(RoadSprite.gameObject.name);
        // }
    }

    void Update()
    {
        
    }

}
