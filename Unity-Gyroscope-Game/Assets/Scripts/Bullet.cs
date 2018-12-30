using UnityEngine;

public class Bullet : MonoBehaviour 
{
	[SerializeField]
	private AudioSource expliosionSound;
	[SerializeField]
	private GameObject explosionPrefab;
	//[SerializeField]
	//private ParticleSystem _psystem;


	void Start () 
	{
		GetComponent<Collider>().enabled = true;
		expliosionSound = GameObject.Find("Explosion sound").GetComponent<AudioSource>();
	}


	void Update () 
	{

	}

	private void OnCollisionEnter(Collision collision)
	{
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		GetComponent<Collider>().enabled = false;
		expliosionSound.Play();
		Destroy(gameObject.GetComponent<MeshFilter>().mesh);
		GetComponent<TrailRenderer>().enabled = false;
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		Destroy(gameObject,6);
	}
}
