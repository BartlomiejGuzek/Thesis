using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public Transform[] listOfSpawns;
    public Transform[] listOfLaserSpawns;
    public GameObject enemy;
    public GameObject laser;

    // Use this for initialization
    void Start ()
    {
		
        int i = Random.Range(0, listOfSpawns.Length);
        Instantiate(enemy, listOfSpawns[i].position, enemy.transform.rotation);
		int j = Random.Range(0, listOfLaserSpawns.Length);
		Instantiate(laser, listOfLaserSpawns[j].position, laser.transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
