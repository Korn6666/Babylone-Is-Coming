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
    [SerializeField] private Animator FougereAnimator;
    private GameObject enemyToHit;
    private bool caresse;

    [SerializeField]private float WaitForAnimationTime = 0.3f;

    private float WaitForAnimationTimer = 0;

    private bool IsGonnaGrow;
    [SerializeField] private float tailleFinale;

    void Start()
    {
        IsGonnaGrow = true;
    }




    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy" && CooldownIsUp)
        {
            enemyToHit = enemy.gameObject;
            FougereAnimator.SetTrigger("Caresse");
            WaitForAnimationTimer = WaitForAnimationTime;
            caresse = true;
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
        if ( WaitForAnimationTimer >= 0)
        {
            WaitForAnimationTimer -= Time.deltaTime;
        }

        if (IsGonnaGrow)
        {
            gameObject.transform.localScale += new Vector3(0.01f,0.01f,0.01f);
            if (gameObject.transform.localScale.magnitude > tailleFinale)
            {
                IsGonnaGrow = false;
            } 
        }



        if (caresse)
        {
            if ( WaitForAnimationTimer < 0)
            {
                object[] tableau = new object[2];
                tableau[0]=damageFougere;
                tableau[1]=slowforce;
                enemyToHit.SendMessage("Convert", tableau);
                caresse = false;
            }
        }
    }
}
