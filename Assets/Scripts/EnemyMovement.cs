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
    public Vector3 direction2D;
    public float speed;
    [SerializeField] private GameObject BlackFade;
    private Vector3 offSet;

    void Start()
    {
        offSet = gameObject.GetComponent<BoxCollider>().center;
        RoadScript = GameObject.FindGameObjectWithTag("Road").GetComponent<RoadScript>();
        RoadSprites = RoadScript.RoadSprites;
        tileRoadNumber = 1;
        destination = RoadSprites[tileRoadNumber];
        Vector3 direction = (destination.position - transform.position - offSet).normalized;
        direction2D =  new Vector3(direction.x, direction.y, 0);
    }

    void Update()
    {

        transform.Translate( direction2D * speed * Time.deltaTime);

        if (transform.position.z > -2.1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.2f);
        }

    }

    private void OnTriggerEnter (Collider Entity)
    {
        if (Entity.gameObject.tag == "RoadTile")
        {
            
            if (tileRoadNumber == RoadSprites.Length - 2)
            {
                Instantiate( BlackFade, Vector3.zero, Quaternion.identity);
                gameObject.SetActive(false);
            }
            tileRoadNumber += 1;
            destination = RoadSprites[tileRoadNumber];
            Debug.Log(destination.gameObject.name);
            Vector3 direction = (destination.position- transform.position - offSet).normalized;
            direction2D =  new Vector3(direction.x, direction.y, 0);
        }
    }
}
