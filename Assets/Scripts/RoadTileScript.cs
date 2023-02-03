using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTileScript : MonoBehaviour
{

    
    private void OnTriggerEnter( Collider Entity)
    {
        // if (Entity.tag == "Enemy")
        // {
        //     //Entity.GetComponent<EnemyMovement>().MoveNextTile = true;
        // }
        Debug.Log("ya");
    }
}
