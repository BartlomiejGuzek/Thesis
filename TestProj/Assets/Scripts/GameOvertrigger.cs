using UnityEngine;

public class GameOvertrigger : MonoBehaviour
{
    public Player player;
    public TrackGen trackGen;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            trackGen.isRunning = false;
            player.ApplyDamage(player.maxHealth);
        }
    }
}
