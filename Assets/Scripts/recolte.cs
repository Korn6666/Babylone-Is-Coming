using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolte : MonoBehaviour
{

    public GameObject Jardinier;
    public GameObject WaveManager;
    public int grammes;
    public int tourSansRecolte;
    [SerializeField] private Animator FleuriOuNon;


    // Update is called once per frame
    public void Grow()
    {
        FleuriOuNon.SetBool("Fleuri", true);
        tourSansRecolte +=1;
        grammes+= 10*tourSansRecolte;
        Debug.Log("oui");
    }

    void Jardined()
        {
            FleuriOuNon.SetBool("Fleuri", false);
            grammes=0;
        }

    public void Recolte()
    {
        FleuriOuNon.SetBool("Fleuri", false);
        grammes = 0;
        tourSansRecolte = 0;
    }
}
