﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{

    private float horiz;
    private float verti;
    public float speed;
    [SerializeField] private Transform BaseTransform;
    private Vector3 BaseDirection;
    private float BaseDistance;
    [SerializeField] private Animator playerAnimator;
    public GameObject CanvasBuild;
    public bool isMoving;
    private bool atHome;

    void Start()
    {

    }
    void Update()
    {
        if (!WaveManager.preparation)
        {
            isMoving = true;
            BaseDistance = (BaseTransform.position - transform.position).magnitude;
            if ( BaseDistance > 1 )
            {
                atHome = false;
                playerAnimator.SetBool("isMoving", true);
                BaseDirection = (BaseTransform.position - transform.position).normalized;
                transform.Translate( BaseDirection * Time.deltaTime * speed);
            }
            else 
            {
                atHome = true;
                playerAnimator.SetBool("isMoving", false);
            }
        }
        else 
        {
            atHome = false;
            horiz = Input.GetAxis("Horizontal");
            verti = Input.GetAxis("Vertical");

            if ( horiz != 0 || verti != 0)
            {
                isMoving = true;
                transform.Translate(new Vector3(horiz,verti,0) * Time.deltaTime * speed);
                playerAnimator.SetBool("isMoving", true);

                //Interruption du canvas si mouvement
                ResetCanvas();

            
            }
            else
            {
                isMoving = false;
                playerAnimator.SetBool("isMoving", false);

                //Canvas apparait si immobile
                CanvasBuild.SetActive(true);
            }
        }

        if (atHome)
        {
            Debug.Log("atHome");
            BaseTransform.GetChild(0).gameObject.SetActive(false);
            BaseTransform.GetChild(1).gameObject.SetActive(true);
        }else 
        {
            Debug.Log("NotatHome");
            BaseTransform.GetChild(0).gameObject.SetActive(true);
            BaseTransform.GetChild(1).gameObject.SetActive(false);
        }
    }

    void ResetCanvas()
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
