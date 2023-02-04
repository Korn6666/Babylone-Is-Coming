using System.Collections;
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
    
    void Start()
    {

    }
    void Update()
    {
        if (!WaveManager.preparation)
        {
            BaseDistance = (BaseTransform.position - transform.position).magnitude;
            if ( BaseDistance > 1 )
            {
                playerAnimator.SetBool("isMoving", true);
                BaseDirection = (BaseTransform.position - transform.position).normalized;
                transform.Translate( BaseDirection * Time.deltaTime * speed);
            }
            else 
            {
                playerAnimator.SetBool("isMoving", false);
            }

        }
        else 
        {
            horiz = Input.GetAxis("Horizontal");
            verti = Input.GetAxis("Vertical");

            if ( horiz != 0 || verti != 0)
            {
                transform.Translate(new Vector3(horiz,verti,0) * Time.deltaTime * speed);
                playerAnimator.SetBool("isMoving", true);

                //Interruption du canvas si mouvement
                CanvasBuild.SetActive(false);
            }
            else
            {
                playerAnimator.SetBool("isMoving", false);

                //Canvas apparait si immobile
                CanvasBuild.SetActive(true);
            }
     

        }

    }
}
