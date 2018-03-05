using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGen : MonoBehaviour
{
    //Track related variables
    [SerializeField]
    private GameObject trackPrefab;
    [SerializeField]
    private GameObject emptyTrackPrefab;
    private Vector3 trackOffset = new Vector3(0, 6, 0);
    private Vector3 actualOffset = new Vector3(0, 0, 0);
    //Enemies related variables
    [SerializeField]
    private GameObject zapperPrefab;
    private int trackNumber = 0;
    private int previousTrackNumber = 0;
    public bool isRunning;


    void Start()
    {
        isRunning = true;
        //Instantiate trackPrefab, trackLenght times
        for (int i = 0; i < 2; ++i)
        {
            GameObject trackPart = Instantiate(emptyTrackPrefab, GetComponent<Transform>().position + actualOffset, Quaternion.identity) as GameObject;
            actualOffset = actualOffset + trackOffset;
            trackPart.transform.Rotate(-90, 0, 180);
            trackPart.transform.parent = gameObject.transform;
            trackNumber++;
            trackPart.name = "BaseTrack" + trackNumber.ToString();
        }
        
    }
	
	void Update ()
    {
        if(isRunning)
        {
            if (previousTrackNumber >= 3)
            {
                DeleteTrack(1);
                DeleteTrack(2);
                DeleteTrack(previousTrackNumber);
            }


        }
		
	}

    public void SpawnTrack()
    {
        GameObject trackPart = Instantiate(trackPrefab, GetComponent<Transform>().position + actualOffset, Quaternion.identity) as GameObject;
        actualOffset = actualOffset + trackOffset;
        trackPart.transform.Rotate(-90, 0, 180);
        trackPart.transform.parent = gameObject.transform;
        trackNumber++;
        previousTrackNumber = trackNumber - 4;
        trackPart.name = "BaseTrack" + trackNumber.ToString();
        
    }

    public void DeleteTrack(int _trackToDelete)
    {
            Destroy(GameObject.Find("BaseTrack" + _trackToDelete.ToString()));  
    }
   
}
