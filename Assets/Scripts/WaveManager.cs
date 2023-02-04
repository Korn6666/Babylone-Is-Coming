using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float waitnextwave=5f;
    private float waitnextspawn = 1f;
    public int activeEnemyCount;
    public int currentWave; // Numéro de la vague
    public GameObject Enemy1;
    private GameObject[] EnemyList;

    void Start()
    {

        EnemyList = new GameObject[] { Enemy1 };
        StartCoroutine(WavesRoutine());
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

            yield return new WaitForSeconds(waitnextwave);
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
        }
    }
}
