using UnityEngine;
using System.Collections;

public class DrawGridForBuilding : MonoBehaviour {

	public float PlaneSizeX = 10;
	public float PlaneSizeZ = 10;

	// only change if using with a custom created plane that has a different number of segments
	private int m_planeSegments = 1;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		UpdatePlane();
		newPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		UpdatePlane();
		GoToMose ();
	}

	void GoToMose() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			newPosition = hit.point;
			newPosition.y = transform.position.y;
			transform.position = newPosition;
		}

	}

	/// <summary>
	/// Update the plane so that its the same shape as the terrain under it
	/// Call after the position of the plane has changed
	/// </summary>
	public void UpdatePlane()
	{
		Mesh mesh = ((MeshFilter)GetComponent(typeof(MeshFilter))).mesh as Mesh;
		if (mesh != null)
		{
			Vector3 position = new Vector3(transform.position.x+ (PlaneSizeX/2), transform.position.y, transform.position.z+(PlaneSizeZ/2));
			Vector3[] vertices = mesh.vertices;
			float xStep = (PlaneSizeX / m_planeSegments);
			float zStep = (PlaneSizeZ / m_planeSegments);
			int squaresize = m_planeSegments + 1;
			for (int n = 0; n < squaresize; n++)
			{
				for (int i = 0; i < squaresize; i++)
				{
					vertices[(n*squaresize)+i].y = Terrain.activeTerrain.SampleHeight(position);
					position.x -= xStep;
				}
				position.x += (((float)squaresize) *xStep);
				position.z -= zStep;
			}
			mesh.vertices = vertices;
			mesh.RecalculateBounds();
		}
	}
}