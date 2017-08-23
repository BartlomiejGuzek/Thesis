using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : MonoBehaviour
{
    public float damage;


    void Start ()
    {

    }


    void Update ()
    {
     
    }


    void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            GhostForm();
        }
    }

    void GhostForm()
    {
        //Disable collider
        GetComponent<Collider>().enabled = false;
        //SHADER NEEDS TO BE SET TO : TRANSPARENT!!!
        Color color = GetComponent<Renderer>().material.color;
        color.a = .5f;
        GetComponent<Renderer>().material.SetColor("_Color", color);
        return;
    }

    // TODO
    void Zapp()
    {

    }

}
