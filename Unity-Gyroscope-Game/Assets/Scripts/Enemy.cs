using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	[SerializeField]
	Animator animator;
	[SerializeField]
	Cannon player;
	bool isReadyToSpawn;
	bool isAlive;
	[SerializeField]
	private AudioSource scoreSound;


	void Start () 
	{
		isAlive = true;
		animator = GetComponent<Animator>();
	}
	
	void FixedUpdate ()
	{
		if(!isAlive)
		{
			if(RandomSpawn(.01f))
			{
				Spawn();
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Bullet")
		{
			scoreSound.Play();
			isAlive = false;
			animator.SetBool("isAlive", isAlive);
			player.AddScore(1);
			player.AddAmmo(1);
		}
		else
			isAlive = true;
	}
	
	private void Spawn()
	{

		isAlive = true;
		animator.SetBool("isAlive", isAlive);
	}

	public bool RandomSpawn(float chanceOfSuccess)
	{
		return Random.value < chanceOfSuccess;
	}

}
