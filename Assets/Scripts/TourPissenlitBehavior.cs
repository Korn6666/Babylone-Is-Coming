using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourPissenlitBehavior : MonoBehaviour
{

    private GameObject enemyGameObject;
    public List<GameObject> listEnemy = new List<GameObject>();
    public Vector3 direction;
    public GameObject projectile;
    private float coolDownPiss=0.5f;
    public float maxRange;
    private GameObject proj;
    [SerializeField] private Animator pissAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            enemyGameObject=enemy.gameObject;
            listEnemy.Add(enemyGameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (listEnemy.Count>0)
        {
            if (listEnemy[0].GetComponent<EnemyHealth>().converted || Distance(listEnemy[0]) > maxRange)
            {
                listEnemy.RemoveAt(0);
            }
    
            else
            {
                if (coolDownPiss <0)
                {
                    pissAnimator.SetTrigger("Fiou");
                    ThrowProjectile(listEnemy[0]);
                    coolDownPiss=0.5f;
                }
                else
                {
                    coolDownPiss-=Time.deltaTime;
                }
            }
        }
    }

    void ThrowProjectile(GameObject enemy)
    {
        direction = (enemy.transform.position - transform.position - new Vector3(0,1,0)).normalized;
        proj=Instantiate(projectile, transform.position + new Vector3(0,1,0), Quaternion.identity);
        proj.GetComponent<PissMove>().TourPissenlit = gameObject;
    }

    float Distance(GameObject enemy)
    {
        return ((transform.position - enemy.transform.position).magnitude);
    }
}

