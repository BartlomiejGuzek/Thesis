using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGen : MonoBehaviour
{
    //Track related variables
    [SerializeField]
    private GameObject trackPrefab;
    [SerializeField]
    private int trackLenght = 20;
    private Vector3 trackOffset = new Vector3(0, 16, 0);
    private Vector3 actualOffset;
    //Enemies related variables
    [SerializeField]
    private GameObject zapperPrefab;
    [SerializeField]
    private int zapperAmmount = 20;


    void Start ()
    {
        //Instantiate trackPrefab, trackLenght times
        for (int i = 0; i < trackLenght; ++i)
        {
            GameObject trackPart = Instantiate(trackPrefab, GetComponent<Transform>().position + actualOffset, Quaternion.identity) as GameObject;
            actualOffset = actualOffset + trackOffset;
            trackPart.transform.Rotate(-90, 0, 180);
        }
        for (int i = 0; i < zapperAmmount; ++i)
        {
            Vector3 zapperPosition = new Vector3(Random.Range(-6, 4), Random.Range(5, 350), -2.6f);
            GameObject zapper = Instantiate(zapperPrefab, zapperPosition, Quaternion.identity) as GameObject;
        }

    }
	
	void Update ()
    {
		
	}
}
