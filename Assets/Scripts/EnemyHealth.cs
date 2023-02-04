using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float maxConversion;
    private float conversion;
    [SerializeField] EnemyMovement EnemyMovement;
    void Start()
    {
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
        

        if (conversion >= maxConversion)
        {
            EnemyMovement.speed *= 1.5f;
            conversion = 0;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            conversion += 20;
        }
    }

    public void TakeConversion( float conversionToken )
    {
        conversion += conversionToken;
    }
}
