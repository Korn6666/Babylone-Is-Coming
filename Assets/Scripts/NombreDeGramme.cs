using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NombreDeGramme : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerInteract PlayerInteract;
    private int nbGrammes;

    // Update is called once per frame
    void Update()
    {        
        nbGrammes = PlayerInteract.PlayerGrammes;
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = nbGrammes.ToString();

    }
}
