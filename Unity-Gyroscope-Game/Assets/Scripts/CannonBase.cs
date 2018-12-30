using UnityEngine;

public class CannonBase : MonoBehaviour 
{
	float yAxis;
	[SerializeField]
	private Controller controller;
	void Start()
	{

	}

	void Update()
	{
		yAxis = controller.y;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yAxis, 0), Time.deltaTime);

	}
}
