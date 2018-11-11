using UnityEngine;
using System.Collections;
public class GoToMouse : MonoBehaviour
{
	private Vector3 newPosition;
	void Start () {
		newPosition = transform.position;
		//gameObject.GetComponent<BoxCollider> ().enabled = false;
	}
	void FixedUpdate()
	{
		GoToMose ();
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