using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolte : MonoBehaviour
{

    public GameObject Jardinier;
    public GameObject WaveManager;
    public int grammes;
    public int tourSansRecolte;


    // Update is called once per frame
    void Grow()
    {
        tourSansRecolte +=1;
        grammes+= 10*tourSansRecolte;
        Debug.Log("oui");
    }

    void Jardined()
        {
            grammes=0;
        }


}
