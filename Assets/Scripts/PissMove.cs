using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissMove : MonoBehaviour
{
    public int damagePiss;
    public float slowforcePiss;
    public Vector3 dir;
    public float pisspeed;
    public TourPissenlitBehavior TourPissenlitBehaviorScript;
    private float cdDeath=5f;
    // Start is called before the first frame update
    void Start()
    {
        dir=TourPissenlitBehaviorScript.direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir*Time.deltaTime*pisspeed);
        if (cdDeath<0)
        {
            Destroy(gameObject);
        }
        else
        {
            cdDeath-=Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            object[] tableau = new object[2];
            tableau[0]=damagePiss;
            tableau[1]=slowforcePiss;
            enemy.gameObject.SendMessage("Convert", tableau);
            Destroy(gameObject);
        }


    }

}
