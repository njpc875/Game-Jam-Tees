using UnityEngine;
using System.Collections;

public class shipController : MonoBehaviour 
{
    public GameObject shipBody;
    public Rigidbody shipRigidbody;

    private float rotationSpeed = 2.5f;
    private float moveSpeed = 0.5f;
    private float maxSpeed = 20f;
    private Vector3 direction;

    private bool leftPress = false;
    private bool rightPress = false;
    private bool spacePress = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Left key handler.
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left Down");
            leftPress = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("Left Up");
            leftPress = false;
        }

        // Right key handler.
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Right Down");
            rightPress = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("Right Up");
            rightPress = false;
        }

        // Spacebar handler.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Down");
            spacePress = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space Up");
            spacePress = false;
        }

        // Left key held down, rotate anti-clockwise.
        if(leftPress)
        {
            shipBody.transform.Rotate(rotationSpeed * new Vector3(0, 0, 1));
        }

        // Right key held down, rotate clockwise.
        if(rightPress)
        {
            shipBody.transform.Rotate(rotationSpeed * new Vector3(0, 0, -1));
        }

        // Get the up direction in local coordinates.
        direction = shipBody.transform.up;

        // Spacebar held down, generate thrust in the up direction.
        if(spacePress)
        {
            shipRigidbody.velocity += (direction * moveSpeed);
        }

        // Clamp the maximum velocity.
        shipRigidbody.velocity = Vector3.ClampMagnitude(shipRigidbody.velocity, maxSpeed);
	}
}
