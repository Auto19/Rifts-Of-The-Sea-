using UnityEngine;
using System.Collections;


public class rotatePlayer : MonoBehaviour {

	public float RotationSpeed = 5;
	float rotationY = 0;
	float rotationX = 0;
	float rotationZ = 0;
	public float sens2 = 5.0f;
	public float mousesen = 0.05f;

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {


		//var x = Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime;

		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (0, -1, 0, Space.Self);
		}

		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (0, 1, 0, Space.Self);
		}

		//transform.Rotate(0, x, 0, Space.Self);

		//Debug.Log(transform.rotation.eulerAngles.y);
		//LockedRotation();

	
	}

	void LockedRotation()
	{
		rotationY += Input.GetAxis("Mouse Y") * RotationSpeed * 10;
		rotationY = Mathf.Clamp(rotationY, -45.0f, 90.0f);
		rotationX += Input.GetAxis("Mouse X") * RotationSpeed * 10;
		//rotationX = Mathf.Clamp(rotationX, -1000.0f, 1000.0f);
		rotationZ += Input.GetAxis("Mouse X") * RotationSpeed * 10;
		rotationZ = Mathf.Clamp(rotationZ, 0.000f, 0.000f);

		transform.eulerAngles = new Vector3(0/* -rotationY */, rotationX, rotationZ);//transform.localEulerAngles.x, -rotationZ, transform.localEulerAngles.y);
	}
}
