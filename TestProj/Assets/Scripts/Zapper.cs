using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : MonoBehaviour
{
    public float damage;
    public float ghostTimer;

    /// <summary>
    /// / ZROBIC GHOST FORM
    /// </summary>


    // Use this for initialization
    void Start ()
    {
    ghostTimer = 4;

    }

// Update is called once per frame
void Update ()
    {
        ghostTimer = -1 * Time.deltaTime;
        Debug.Log(ghostTimer);
    }


    void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), _col.collider, true);
            GhostForm();
        }
    }

    void GhostForm()
    {
        Debug.Log("kolizja");
        //SHADER NEEDS TO BE SET TO : TRANSPARENT!!!
        Color color = GetComponent<Renderer>().material.color;
        color.a = .5f;
        GetComponent<Renderer>().material.SetColor("_Color", color);
        return;
    }

}
