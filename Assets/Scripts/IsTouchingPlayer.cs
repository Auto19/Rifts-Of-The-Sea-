using UnityEngine;
using System.Collections;

public class IsTouchingPlayer : MonoBehaviour {
	public Transform transa;
	public Material grey;
	public Material red;
	public Material blue;

	//private Vector3 pos = gameObject.transform.position

	void Start() {

	}

	void Update() {
		//transform.Translate(0, 0, 1, Space.World);
		if (LineTouch == true && LineTouch2 == false) {
			Debug.Log ("TouchingTeam1");
			//Change forless sloppy looking
			transa.Translate (0, 0, -15 * Time.deltaTime, Space.World);
			var ph = this.transform.parent.gameObject.GetComponentsInChildren<Renderer> ();
			foreach(Renderer r in ph){
				r.material = red;
			}
		} else if (LineTouch2 == true && LineTouch == false) {
			Debug.Log ("TouchingTeam2");
			//Change forless sloppy looking
			transa.Translate (0, 0, 15 * Time.deltaTime, Space.World);
			var ph = this.transform.parent.gameObject.GetComponentsInChildren<Renderer> ();
			foreach(Renderer r in ph){
				r.material = blue;
			}
		} else if (LineTouch2 == true && LineTouch == true) {
			var ph = this.transform.parent.gameObject.GetComponentsInChildren<Renderer> ();
			foreach(Renderer r in ph){
				r.material = grey;
			}

		}
	}
	public bool LineTouch;
	public bool LineTouch2;
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Collision Entered");
		//transa.Translate(0, 0, 10, Space.World);
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Team1"))
		{
			Debug.Log("Touched a rail");
		//if (collision.gameObject.layer == 8){
			LineTouch = true;

		}
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Team2"))
		{
			Debug.Log("Touched a yoyr");
			//if (collision.gameObject.layer == 8){
			LineTouch2 = true;

		}
	}
	void OnCollisionExit(Collision collision)
	{
		Debug.Log ("Collision Exited");
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Team1"))
		{
			LineTouch = false;
		}

		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Team2"))
		{
			LineTouch2 = false;
		}
	}
}
