﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TimeBar TimeBar;
    [SerializeField] private float preparationTime;
    private float preparationTimeTimer;
    public static bool preparation;
    private float waitnextspawn = 1f;
    public int activeEnemyCount;
    public int currentWave; // Numéro de la vague
    public GameObject Enemy1;
    private GameObject[] EnemyList;

    void Start()
    {
        EnemyList = new GameObject[] { Enemy1 };
        StartCoroutine(WavesRoutine());
        TimeBar.SetMaxTime(preparationTime);
    }

    void Update()
    {

        if (preparation)
        {
            TimeBar.gameObject.SetActive(true);
            TimeBar.SetTime(preparationTimeTimer);
            if (preparationTimeTimer > 0)
            {
                preparationTimeTimer -= Time.deltaTime;
            }else 
            {
                TimeBar.gameObject.SetActive(false);
                preparation = false;
            }
        }


    }

    private IEnumerator SpawnanEnemy()
    {
        int index = Random.Range(0, EnemyList.Length);
        GameObject EnemyToSpawn = EnemyList[index];
        yield return new WaitForSeconds(0f);
        Instantiate(EnemyToSpawn, transform.position, Quaternion.identity);
    }

    private IEnumerator WavesRoutine()
    {
        int tampo = 1;
        int Wavetampon = 1;
        int currentWaveNbEnemy = 1;
        currentWave = 0;
        while (true)
        {
            currentWave += 1;
            for (int i=1; i<=currentWaveNbEnemy; i++)
            {
                StartCoroutine(SpawnanEnemy()); 
                activeEnemyCount += 1;
                yield return new WaitForSeconds(waitnextspawn);
            }

            tampo = currentWaveNbEnemy;
            currentWaveNbEnemy = currentWaveNbEnemy + Wavetampon; 
            Wavetampon = tampo;


            while (activeEnemyCount > 0)
            {
                yield return null;
            }

            // Phase de preparation
            preparation = true;
            preparationTimeTimer = preparationTime;     

            while (preparation)
            {
                yield return null;
            }    
        }
    }
}
