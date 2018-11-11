using UnityEngine;
using System.Collections;

public class MovementSquareTouch : MonoBehaviour {
	private bool LineTouch;
	public bool SetDown = true;
	public Material RedText;
	public Material BlackText;


	void Start() {

	}

	void Update() {
		//transform.Translate(0, 0, 1, Space.World);
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Entered the Collision");

		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("SpawnedItem"))
		{
			gameObject.GetComponent<MeshRenderer> ().material = RedText;
			LineTouch = true;

		}
	}

	void OnCollisionExit(Collision collision) {
			Debug.Log ("Exited the Collision");
			gameObject.GetComponent<MeshRenderer> ().material = BlackText;
			LineTouch = true;
	}

	public void SetItemDown() {
		SetDown = false;
	}
}
