using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public int PlayerGrammes;
    public GameObject currentTile;
    private recolte scriptRecolte; 


    void OnTriggerEnter(Collider tile)
    {
        if (tile.gameObject.tag=="Plants")
            {
                currentTile=tile.gameObject;
                Debug.Log("Oui");
            }


    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentTile.tag == "Plants")
            {

                scriptRecolte = currentTile.GetComponent<recolte>();

                PlayerGrammes += scriptRecolte.grammes;
                scriptRecolte.grammes=0;
            }

        }
    }
}
