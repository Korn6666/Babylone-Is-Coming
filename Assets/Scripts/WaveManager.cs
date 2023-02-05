using System.Collections;
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
    public int currentWave; // Numero de la vague
    public GameObject Enemy1;
    private GameObject[] EnemyList;

    private float meteo;

    public GameObject PlantsPapa;
    public List<GameObject> PlantsList;

    public GameObject player;

    public GameObject CanvasBuild;
    [SerializeField] private GameObject Plane;
    [SerializeField] private GameObject Gaz;
    [SerializeField] private GameObject Pluie;


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
                ResetCanvas();
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

            // Phase de preparation
            preparation = true;
            preparationTimeTimer = preparationTime;     

            while (preparation)
            {
                yield return null;
            }    

            //Meteo pour une vague
            meteo = Random.Range(0f,1.0f);
            if (meteo<0.2f)
            {
                Pluie.SetActive(true);                
            }
            if (meteo>0.8)
            {
                Plane.SetActive(true);
                yield return new WaitForSeconds(3);
                Plane.SetActive(false);
                Gaz.SetActive(true);
                //LANCER LES AVIONS
            }

            //Vague suivante
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


            //Effets de la meteo
            foreach (Transform child in PlantsPapa.transform)
            { 
                child.gameObject.SendMessage("Grow");
                if (meteo<0.2f)
                {
                    Pluie.SetActive(false);
                    child.gameObject.SendMessage("Pluie");
                }
                if (meteo>0.8)
                {
                    Gaz.GetComponent<Animator>().SetTrigger("EndGaz");
                    yield return new WaitForSeconds(1);
                    Gaz.SetActive(false);
                    child.gameObject.SendMessage("Jardined");
                }
            }

            
        }
    }


    public void ResetCanvas()
    {
        CanvasBuild.transform.GetChild(0).gameObject.SetActive(false);
        CanvasBuild.transform.GetChild(1).gameObject.SetActive(false);
        CanvasBuild.transform.GetChild(2).gameObject.SetActive(false);
        CanvasBuild.transform.GetChild(3).gameObject.SetActive(false);
        CanvasBuild.transform.GetChild(4).gameObject.SetActive(false);
        CanvasBuild.transform.GetChild(5).gameObject.SetActive(false);            
        CanvasBuild.transform.GetChild(6).gameObject.SetActive(false);
        CanvasBuild.transform.GetChild(7).gameObject.SetActive(false);
        CanvasBuild.transform.GetChild(8).gameObject.SetActive(false);
        }

}
