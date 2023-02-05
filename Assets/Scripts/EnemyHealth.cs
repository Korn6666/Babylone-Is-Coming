using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxConversion;
    public float conversion;
    [SerializeField] private EnemyMovement EnemyMovement;
    private WaveManager WaveManager;
    public bool converted;

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
    [SerializeField] private Animator bizAnimator;
    private string[] color;
    private int colorIndex;

    void Start()
    {
        WaveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();
        conversion = 0;
        cooldown = maxCooldown;
        color = new string[] { "Convert1", "Convert2", "Convert3"};
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

    void OnTriggerEnter(Collider wall)
    {
        if (wall.gameObject.name == "WallColliders")
        {
            Destroy(gameObject);
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
       
    //    //Doit mourrir après conversion
    //    if (needsToDie)
    //    {
    //         deathCoolDown -= Time.deltaTime;

    //         if (deathCoolDown<0)
    //         {
    //             Destroy(gameObject);
    //         }
    //    }


        if (conversion >= maxConversion && !converted) 
        {
            colorIndex = Random.Range(0, 3);
            bizAnimator.SetTrigger(color[colorIndex]);
            EnemyMovement.speed *= 1.5f;
            converted = true;
            WaveManager.activeEnemyCount -= 1;
            gameObject.tag = "Untagged";
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
            Destroy(gameObject);
        }
    }

}
