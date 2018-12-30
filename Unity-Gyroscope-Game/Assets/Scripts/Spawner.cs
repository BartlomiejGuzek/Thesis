using UnityEngine;

public class Spawner : MonoBehaviour 
{
	[SerializeField]
	private GameObject prefab;
	void Start () 
	{
		InvokeRepeating("Spawn", 5, 1);
	}
	
	void Update () 
	{
		
	}

	void Spawn()
	{
		Instantiate(prefab, transform);
	}
}
