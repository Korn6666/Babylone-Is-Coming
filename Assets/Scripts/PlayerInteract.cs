using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Ressource
    public int PlayerGrammes;
    private recolte scriptRecolte; 

    //Tile avec qui interact
    public GameObject currentTile;
    private Vector3 TilePosition;
    
    //Canvas 
    public GameObject CanvasBuild;

    //Tours
    public GameObject TourChampignon;
    public int CoutTourChampignon;
    
    //Detection de la tile
    void OnTriggerEnter(Collider tile)
    {
        if (tile.gameObject.tag=="Plants")
            {
                currentTile=tile.gameObject;
            }
        if (tile.gameObject.tag == "Plots")
        {
                currentTile=tile.gameObject;
        }

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Recolte de ressources
            if (currentTile.tag == "Plants")
            {

                scriptRecolte = currentTile.GetComponent<recolte>();

                PlayerGrammes += scriptRecolte.grammes;
                scriptRecolte.grammes=0;
            }

            //Build (canvas)
            if (currentTile.tag == "Plots")
            {
                CanvasBuild.transform.GetChild(0).gameObject.SetActive(true);
            }


        }
    }

    //Build (tours)
    public void BuildTourChampi()
    {
        if (CoutTourChampignon <= PlayerGrammes)
        {
            PlayerGrammes-=CoutTourChampignon;
        
            TilePosition = currentTile.transform.position;
            TilePosition.z-=1;
            Instantiate(TourChampignon, TilePosition, Quaternion.identity);
            CanvasBuild.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            CanvasBuild.transform.GetChild(0).gameObject.SetActive(false);
            CanvasBuild.transform.GetChild(1).gameObject.SetActive(true);
        }

    }

}
