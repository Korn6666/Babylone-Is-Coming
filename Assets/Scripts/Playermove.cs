using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{

    private float horiz;
    private float verti;
    public float speed;

    void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        verti = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horiz,verti,0) * Time.deltaTime * speed);
    }
}
