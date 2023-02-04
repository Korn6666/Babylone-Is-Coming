using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxConversion;
    private float conversion;
    [SerializeField] private EnemyMovement EnemyMovement;
    private WaveManager WaveManager;
    private bool converted;

    void Start()
    {
        WaveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();
        conversion = 0;
    }

    //Pour qu'il se fasse SendMessage("Convert") quand il prend un hit
    void Convert()
    {
        conversion += 1;
        Debug.Log(conversion);
    } 

    // Update is called once per frame
    void Update()
    {
        

        if (conversion >= maxConversion && !converted) 
        {
            EnemyMovement.speed *= 1.5f;
            converted = true;
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

    public void TakeConversion( float conversionToken )
    {
        conversion += conversionToken;
    }
}
