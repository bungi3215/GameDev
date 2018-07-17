using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewShipControl : Photon.MonoBehaviour {

	public float verticalForce = 5f;
	public float horizontalForce = 3f;
	public float liftForce = 3f;
	public float rotationSpeed = 100.0f;

	private Text textElement;

	private Rigidbody shipRigidbody;
	private Vector3 vecForward;
	private Vector3 vecUp;
	private Vector3 vecRight;
	void Start () {
		textElement = GameObject.Find("Velocity").GetComponent<Text>();

		shipRigidbody = GetComponent<Rigidbody>();
		vecForward = transform.forward;
		vecUp = transform.up;
		vecRight = transform.right;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!photonView.isMine)
		{
			return;
		}

		HandleMovement();
		HandleRotation();

	}

	void HandleMovement()
	{
		if (Input.GetAxis("Vertical") > 0)
		{
			shipRigidbody.AddForce(vecForward * 100 * verticalForce * Time.deltaTime);
		}
		else if (Input.GetAxis("Vertical") < 0)
		{
			shipRigidbody.AddForce(-vecForward * 100 * verticalForce * Time.deltaTime);
		}


		if (Input.GetAxis("Horizontal") > 0)
		{
			shipRigidbody.AddForce(vecRight * 50 * horizontalForce * Time.deltaTime);
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			shipRigidbody.AddForce(-vecRight * 50 * horizontalForce * Time.deltaTime);
		}

		if (Input.GetAxis("lift") > 0)
		{
			shipRigidbody.AddForce(vecUp * 50 * liftForce * Time.deltaTime);
		}
		else if (Input.GetAxis("lift") < 0)
		{
			shipRigidbody.AddForce(-vecUp * 50 * liftForce * Time.deltaTime);
		}

		textElement.text = shipRigidbody.velocity.ToString();
		Debug.Log(shipRigidbody.velocity);

		UpdateTransform();
	}

	void HandleRotation()
	{
		var rX = Input.GetAxis("rotateHorizontal") * Time.deltaTime * rotationSpeed;
		var rY = Input.GetAxis("rotateVertical") * Time.deltaTime * rotationSpeed;
		var rZ = Input.GetAxis("rotateSides") * Time.deltaTime * rotationSpeed;

		transform.Rotate(0, 0, rX);
		transform.Rotate(0, rZ, 0);
		transform.Rotate(rY, 0, 0);
	}


	void UpdateTransform()
	{
		vecForward = transform.forward;
		vecRight = transform.right;
		vecUp = transform.up;
	}
}
