using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

	// Use this for initialization
	public float RotationSpeed = 5;
	float rotationZ = 0;
	public float sens2 = 5.0f;
	//private float y = 0f;

	// Use this for initialization
//	void Start () {
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//
//		var y = Input.GetAxis ("Mouse Y") * -1 * RotationSpeed * Time.deltaTime;
//		//var x = Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime;
//
//		//y += Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
//
//		//y = Mathf.Clamp (y, 100, -100);//MinClamp, MaxClamp);
//
//		//transform.localEulerAngles = new Vector3(0, -y, 0);
//
//
//			//y = 10f;
//
//
//		Debug.Log (transform.rotation.);
//	
//		//if (transform.rotation.y * 100 > 3) {// transform.rotation.x < -90) {
//			//transform.Rotate (0, 0, 0, Space.Self);
//		//} else if (transform.rotation.y * 100 < -3) {
//			//transform.Rotate (0, 0, 0, Space.Self);
//		//} else {
//			transform.Rotate (y, 0, 0, Space.Self);
//		//}
//	
//
//
//	}

	void Start()
	{
		transform.rotation = Quaternion.identity;
	}

	void Update()
	{
		Debug.Log(transform.rotation.eulerAngles.y);
		LockedRotation();

		if (Input.GetMouseButton(1)) {
			RotationSpeed = 0f;
		} else {
			RotationSpeed = sens2;
			}
	}

	void LockedRotation()
	{
		rotationZ += Input.GetAxis("Mouse Y") * RotationSpeed * 10;
		rotationZ = Mathf.Clamp(rotationZ, -45.0f, 90.0f);

		transform.localEulerAngles = new Vector3( -rotationZ, 0, 0);//transform.localEulerAngles.x, -rotationZ, transform.localEulerAngles.y);
	}

}
