using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuage : MonoBehaviour
{

    public Collider HitBoxChampignon;
    public float timeRemaining = 4f;
    // Update is called once per frame
    public int damageChampi;
    public float slowforce;
    [SerializeField] private Animator champAnimator;
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
            transform.GetChild(0).gameObject.SetActive(false);
        }
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            champAnimator.SetBool("Smoke", false);
        }
        else
        {
            champAnimator.SetBool("Smoke", true);
            timeRemaining =4f;
            HitBoxChampignon.enabled=true;
            transform.GetChild(0).gameObject.SetActive(true);
        }

    }
}
