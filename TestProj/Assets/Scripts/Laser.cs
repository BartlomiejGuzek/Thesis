using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private Player player;
    public AudioSource hitSound;
    public bool isEnabled;

    // Use this for initialization
    void Start ()
    {
		player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            player.ApplyDamage(20);
            hitSound.Play();
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
}
