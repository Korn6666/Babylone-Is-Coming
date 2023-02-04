using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NombreDeGramme : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerInteract PlayerInteract;
    private int nbGrammes;

    // Update is called once per frame
    void Update()
    {        
        nbGrammes = PlayerInteract.PlayerGrammes;
        GetComponent<Text>().text = "Nombre de grammes:  " + nbGrammes;

    }
}
