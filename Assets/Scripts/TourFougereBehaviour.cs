using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourFougereBehaviour : MonoBehaviour
{
    public float slowforce;
    public int damageFougere;
    private bool CooldownIsUp;
    private float Cooldown;
    public float MaxCooldown;

   void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy" && CooldownIsUp)
        {
            object[] tableau = new object[2];
            tableau[0]=damageFougere;
            tableau[1]=slowforce;
            enemy.gameObject.SendMessage("Convert", tableau);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Cooldown < 0)
        {
            CooldownIsUp = true;
            Cooldown = MaxCooldown;
        }
        else
        {
            Cooldown -= Time.deltaTime;
        }
    }
}
