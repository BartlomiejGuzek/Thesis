using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGen : MonoBehaviour
{
    public GameObject trackPrefab;
    public int trackLenght = 20;
    public int trackOffset = 16;

    void Start ()
    {
        for (int i = 0; i < trackLenght; i++)
        {
            float angle = i * Mathf.PI * 2 / trackLenght;
            //Vector3 position = new Vector3(Game);
           // Instantiate(trackPrefab, position, Quaternion.identity);
        }

    }
	
	void Update ()
    {
		
	}
}
