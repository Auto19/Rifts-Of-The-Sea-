using UnityEngine;
using System.Collections;

public class ISTouchingOtherCorral : MonoBehaviour {
	public Transform transa;
	public GameObject Me;
	private bool LineTouch;


	void Start() {
	}

	void Update() {
		//transform.Translate(0, 0, 1, Space.World);
		if (LineTouch == true) {
			Destroy (Me);
		}


		
	}

	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("Entered the Collision");
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Corral"))
		{

			LineTouch = true;

		}
	}

}
