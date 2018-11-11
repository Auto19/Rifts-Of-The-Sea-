using UnityEngine;
using System.Collections;
public class GoToMouseBuildings: MonoBehaviour
{
	private Vector3 newPosition;
	private bool Move;

	void Start () {
		newPosition = transform.position;
		gameObject.GetComponent<BoxCollider> ().enabled = false;
		//gameObject.GetComponent<Rigidbody>().detectCollisions = true;
		Move = true;
	}
	void Update()
	{
		IsItClicking ();
	}

	void IsItClicking() {
		if (Input.GetMouseButton (0)) {
				Move = false;
		}

		if (Move == true) {
			GoToMose ();
		} else {
			gameObject.GetComponent<BoxCollider> ().enabled = true;
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			//gameObject.GetComponent<Rigidbody>().detectCollisions = false;
		}
	}

	void GoToMose() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			newPosition = hit.point;
			newPosition.y = Terrain.activeTerrain.SampleHeight(newPosition);
			newPosition.y = newPosition.y + gameObject.transform.localScale.y/2f;
			transform.position = newPosition;

		}
	}
}