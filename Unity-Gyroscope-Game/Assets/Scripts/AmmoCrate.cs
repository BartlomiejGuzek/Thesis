using UnityEngine;

public class AmmoCrate : MonoBehaviour 
{
	[SerializeField]
	Cannon cannonScript;
	[SerializeField]
	AudioSource scoreSound;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Bullet")
		{
			scoreSound.Play();
			cannonScript.AddAmmo(5);
			Destroy(gameObject);
		}
	}
}
