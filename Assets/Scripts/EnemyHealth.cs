using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxConversion;
    public float conversion;
    [SerializeField] private EnemyMovement EnemyMovement;
    private WaveManager WaveManager;
    private bool converted;

    //slow
    public bool slowed;
    private float cooldown;
    public float maxCooldown;
    private float previousSpeed;
    //
    //Variables envoyés par nuage de champignon
    private float slowforce;
    private int damage;
    
    //Post-Conversion
    private float deathCoolDown=10f;
    private bool needsToDie=false;

    void Start()
    {
        WaveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();
        conversion = 0;
        cooldown = maxCooldown;
    }

    //Pour qu'il se fasse SendMessage("Convert") quand il prend un hit
    void Convert(object[] tab)
    {
        
        damage = (int) tab[0];
        slowforce = (float) tab[1];

        conversion += damage;

        if (!slowed)
        {
            slowed=true;
            previousSpeed=EnemyMovement.speed;
            EnemyMovement.speed/=slowforce;
        }
        else 
        {
            cooldown=maxCooldown;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
        //Slow
        if (slowed==true)
        {
            cooldown-=Time.deltaTime;
            if (cooldown <0)
            {
                slowed=false;
                cooldown = maxCooldown;
                EnemyMovement.speed = previousSpeed;
        
            }
        }
       
       //Doit mourrir après conversion
       if (needsToDie)
       {
            deathCoolDown -= Time.deltaTime;

            if (deathCoolDown<0)
            {
                Destroy(gameObject);
            }

       }


        if (conversion >= maxConversion && !converted) 
        {
            EnemyMovement.speed *= 1.5f;
            converted = true;
            gameObject.GetComponent<BoxCollider>().enabled=false;
            EnemyMovement.direction2D = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0).normalized;
            needsToDie = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            conversion += 20;
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            WaveManager.activeEnemyCount -= 1;
            Debug.Log(WaveManager.activeEnemyCount);
            Destroy(gameObject);
        }
    }

}
