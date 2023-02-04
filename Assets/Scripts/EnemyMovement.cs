using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private int tileRoadNumber; // Numéro de la tile à suivre
    private RoadScript RoadScript;
    private Transform[] RoadSprites;
    private Transform destination;
    private Vector3 direction2D;
    public float speed;

    void Start()
    {
        RoadScript = GameObject.FindGameObjectWithTag("Road").GetComponent<RoadScript>();
        RoadSprites = RoadScript.RoadSprites;
        tileRoadNumber = 1;
        destination = RoadSprites[tileRoadNumber];
        Vector3 direction = (destination.position - transform.position).normalized;
        direction2D =  new Vector3(direction.x, direction.y, 0);
    }

    void Update()
    {

        transform.Translate( direction2D * speed * Time.deltaTime);

    }

    private void OnTriggerEnter (Collider Entity)
    {
        if (Entity.gameObject.tag == "RoadTile")
        {
            if (tileRoadNumber == RoadSprites.Length - 2)
            {
                gameObject.SetActive(false);
            }
            tileRoadNumber += 1;
            destination = RoadSprites[tileRoadNumber];
            direction2D = (destination.position - transform.position).normalized;
        }
    }
}
