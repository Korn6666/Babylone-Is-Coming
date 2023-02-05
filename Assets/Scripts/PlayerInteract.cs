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
    private GameObject fougere;
    public GameObject TourFougere;
    public GameObject TourPissenlit;
    public int CoutTourPissenlit;
    public int CoutTourFougere;

    //Occupation de la tile
    private bool peutConstruire;
    public Occupe Occupe;

    private bool busy;
    private float busycd; 

    private bool moving;
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
        if (busy)
        {
            busycd-=Time.deltaTime;
        }
        else
        {
            busycd=0.2f;
            busy=false;
        }

        if ( gameObject.GetComponent<Playermove>().isMoving )
        {
            currentTile.transform.GetChild(0).gameObject.SetActive(false);
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (Input.GetButtonDown("Fire1") && !busy && !moving)
        {
            peutConstruire = !currentTile.GetComponent<Occupe>().boolOccupe;
            currentTile.transform.GetChild(0).gameObject.SetActive(true);
                
                //Recolte de ressources
            if (currentTile.tag == "Plants")
            {
                scriptRecolte = currentTile.GetComponent<recolte>();

                PlayerGrammes += scriptRecolte.grammes;
                currentTile.GetComponent<recolte>().Recolte();
            }

                //Build (canvas)
            if (currentTile.tag == "Plots" && peutConstruire)
            {
                CanvasBuild.transform.GetChild(0).gameObject.SetActive(true);
                CanvasBuild.transform.GetChild(2).gameObject.SetActive(true);
            }
            
            else
            {
                if (currentTile.tag == "Plots")
                {
                    CanvasBuild.transform.GetChild(7).gameObject.SetActive(true);
                }
                if (currentTile.tag == "Plants")
                {
                    CanvasBuild.transform.GetChild(8).gameObject.SetActive(true);
                }
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
            currentTile.GetComponent<Occupe>().boolOccupe = true;
            ResetCanvas();
           
        }
        else
        {
            ResetCanvas();
            CanvasBuild.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void BuildTourFougereOrientation()
        {
        if (CoutTourFougere <= PlayerGrammes)
        {
            PlayerGrammes-=CoutTourFougere;
            ResetCanvas();
            busy=true;
        }
        else
        {
            ResetCanvas();
            CanvasBuild.transform.GetChild(1).gameObject.SetActive(true);
        }

    }

    public void BuildTourFougere(float orientation)
    {
        ResetCanvas();
        TilePosition = currentTile.transform.position;
        TilePosition.z-=1;
        fougere = Instantiate(TourFougere, TilePosition, Quaternion.identity);
        currentTile.GetComponent<Occupe>().boolOccupe = true;
        fougere.transform.Rotate(new Vector3(0,0,orientation));
        busy=false;

    }

    public void BuildTourPissenlit()
    {
        if (CoutTourPissenlit <= PlayerGrammes)
        {
            PlayerGrammes-=CoutTourPissenlit;
        
            TilePosition = currentTile.transform.position;
            TilePosition.z-=1;
            Instantiate(TourPissenlit, TilePosition, Quaternion.identity);
            currentTile.GetComponent<Occupe>().boolOccupe = true;
            ResetCanvas();
           
        }
        else
        {
            ResetCanvas();
            CanvasBuild.transform.GetChild(1).gameObject.SetActive(true);
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
