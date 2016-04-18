using UnityEngine;
using System.Collections;

public class jetControl : MonoBehaviour {

	//strings for the axes
	public string vertAxis;
	public string horizAxis;
	public string powerAxis;
	public float maxSpeed = 20f;

	private Vector3 direction;//direction that the jet points
	private float power;
	private Quaternion rotation;
	public float powerModifier = 1f;//used to increase or decrease the power of the jet

	void Start()
	{
	}

	// Update is called once per frame
	void Update () 
	{

		jetDirection ();
		jetPower ();
		gameObject.transform.rotation = rotation;
		//gameObject.GetComponent<Rigidbody>().velocity += (direction * power);
		gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * power);

		//makes sure that the jet never moves off its axis
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
	}

	void jetDirection()
	{
		
		/*direction = new Vector3(Input.GetAxis (horizAxis), Input.GetAxis (vertAxis), 0);

		Vector3 axis = Vector3.Cross(gameObject.transform.forward, direction);
		rotation = Vector3.Angle(gameObject.transform.forward, direction) / 180.0f * (axis.y < 0 ? -1 : 1);
		transform.rotation = rotation;*/
		Transform mainCamera = Camera.main.transform;
		direction = new Vector3(Input.GetAxis (horizAxis), Input.GetAxis (vertAxis), 0);
		rotation = Quaternion.LookRotation (direction, Vector3.up);
		transform.rotation = rotation;
	}

	void jetPower()
	{
		power = (Input.GetAxis (powerAxis)) * powerModifier;
		Debug.Log(power);
	}
}
