using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInput : MonoBehaviour
{

    public float speed = .2f;
    public float rotateFactor = 2000;
   

    
    void Start ()
    {
        
	}
	
	
	void Update ()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        if(Input.GetButton("RotateDown"))
        {
            transform.Rotate(Vector3.back, rotateFactor * Time.deltaTime);
        }
        if (Input.GetButton("RotateUp"))
        {
            transform.Rotate(Vector3.forward, rotateFactor * Time.deltaTime);
        }



    }

    void FixedUpdate()
    {
        
    }

   

}
