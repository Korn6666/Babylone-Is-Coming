using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuage : MonoBehaviour
{

    public Collider HitBoxChampignon;
    public float timeRemaining = 3f;
    // Update is called once per frame
    public int damageChampi;
    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {

            enemy.gameObject.SendMessage("Convert", damageChampi);
        }
    }

    void Update()
    {
        if (timeRemaining >1 && timeRemaining<1.5)
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
