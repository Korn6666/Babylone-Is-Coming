using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{

    public Transform[] RoadSprites;
    void Awake()
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
