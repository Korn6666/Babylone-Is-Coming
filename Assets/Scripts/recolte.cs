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
        FleuriOuNon.SetTrigger("Fleur");
        tourSansRecolte +=1;
        grammes+= 10*tourSansRecolte;
        Debug.Log("oui");
    }

    void Jardined()
        {
            FleuriOuNon.SetTrigger("Récolte");
            grammes=0;
        }

    public void Recolte()
    {
        FleuriOuNon.SetTrigger("Récolte");
        grammes = 0;
        tourSansRecolte = 0;
    }
}
