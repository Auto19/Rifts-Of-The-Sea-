using UnityEngine;
using System.Collections;

public class ObjectIsTouching : MonoBehaviour {
	public Transform transa;
	public GameObject Me;
	private bool LineTouch;
	public bool SetDown = true;


	void Start() {

	}

	void Update() {
		//transform.Translate(0, 0, 1, Space.World);
		if (LineTouch == true) {
			SetItemDown();
		}
		
	}

	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("Entered the Collision");
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("SpawnedItem"))
		{

			LineTouch = true;

		}
	}

	public void SetItemDown() {
		SetDown = false;
	}
}
