using UnityEngine;
using System.Collections;

public class gunControl : MonoBehaviour {


	//strings for the axes
	public string vertAxis;
	public string horizAxis;
	public string shootAxis;

	
	private Vector3 direction;//direction that the gun points
	private Quaternion rotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gunDirection ();
	}

	void gunDirection()
	{
		direction = new Vector3(Input.GetAxis (horizAxis), Input.GetAxis (vertAxis), 0);
		rotation = Quaternion.LookRotation (direction, Vector3.up);
		transform.rotation = rotation;
	}
}
