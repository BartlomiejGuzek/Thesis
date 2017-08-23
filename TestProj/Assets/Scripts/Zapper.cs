using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : MonoBehaviour
{
    public float damage;
    public Player playerScript;

    // Use this for initialization
    void Start ()
    {
     
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            playerScript.ApplyDamage(damage);
        }
    }

}
