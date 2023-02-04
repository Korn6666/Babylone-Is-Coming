using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuage : MonoBehaviour
{

    public Collider HitBoxChampignon;
    public float timeRemaining = 3f;
    // Update is called once per frame
    public int damageChampi;
    public float slowforce;
    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            object[] tableau = new object[2];
            tableau[0]=damageChampi;
            tableau[1]=slowforce;
            enemy.gameObject.SendMessage("Convert", tableau);
        }
    }

    void Update()
    {
        if (timeRemaining >1 && timeRemaining<1.2)
        {
            HitBoxChampignon.enabled = false;
        }
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining =3f;
            HitBoxChampignon.enabled=true;
        }

    }
}
