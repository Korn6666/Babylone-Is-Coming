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
    public GameObject TourTest;
    
    
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
                CanvasBuild.SetActive(true);
            }

        }
    }

    //Build (tours)
    public void BuildTowerTest()
    {
        TilePosition = currentTile.transform.position;
        TilePosition.z-=1;
        Instantiate(TourTest, TilePosition, Quaternion.identity);

    }

}
