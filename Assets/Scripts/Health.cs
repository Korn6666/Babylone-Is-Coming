using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;

    //public HealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //healthBar.SetHealth(health);

        if (health <= 0f) //condition de destruction 
        {
            Destroy(gameObject); //Détruis l'objet
        }

        if(health > maxHealth) //Empêcher 
        {
            health = maxHealth;
        }
    }
}
