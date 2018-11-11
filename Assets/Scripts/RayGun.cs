using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

//add damage component
// var player = hit.collider
// var health = hit.GetComponent<Health>();
//if (health  != null)
//{
	//health.TakeDamage(10);
//}
// do stuff to player

[RequireComponent(typeof(LineRenderer))]

public class RayGun : NetworkBehaviour 
{
	Vector2 mouse;
	RaycastHit hit;
	float range = 10000.0f;
	LineRenderer line;
	public Material lineMaterial;
	public Transform trans;
	float cooldowntime = 0.1f;
	float cooldown = 0.1f;
	Vector3 mousez;
	public Material theMaterial;
	public GameObject playerColor;
	public bool isTeam1 = false;

	void Start()
	{
		if (!isLocalPlayer) {
			enabled = false;
		}
		line = GetComponent<LineRenderer>();
		line.SetVertexCount(2);
		line.GetComponent<Renderer>().material = lineMaterial;
		gameObject.GetComponent<Renderer> ().sharedMaterial = theMaterial;
		gameObject.GetComponent<Renderer> ().material = theMaterial;
		line.SetWidth(0.1f, 0.1f);

		if (gameObject.tag == "Player1" || gameObject.tag == "Player3" || gameObject.tag == "Player5" || gameObject.tag == "Player7" || gameObject.tag == "Player9" || gameObject.tag == "Player11" || gameObject.tag == "Player13") {
			isTeam1 = true;
			gameObject.layer = LayerMask.NameToLayer ("Team2");
		}
		if (isTeam1) {
			//gameObject.GetComponent<LineRenderer> ().material = lineMaterial;
			gameObject.GetComponent<Renderer> ().sharedMaterial = theMaterial;
			gameObject.GetComponent<Renderer> ().material = theMaterial;
		}
		//enabled = false;
	}

	void Update()
	{
		cooldown -= Time.deltaTime;
		enabled = true;

		if (isLocalPlayer) {
			Ray();
			enabled = true;
			return;
		}

	}
	Vector3 mousep = new Vector3(Screen.width/2, Screen.height/2, 0);
	void Ray() {
		Ray ray = Camera.main.ScreenPointToRay (mousep);
		if (Physics.Raycast (ray, out hit, range)) {
			if (Input.GetMouseButton (0)) {

				if (cooldown > 0) {
					line.enabled = false;
					CmdUnShowLaser ();
					return;
				} else {

				//have to network the next two lines
				ShowLaser (trans.position, hit.point + hit.normal);
				CmdShowLaser (trans.position, hit.point + hit.normal);

				}
				var player = hit.transform.tag;
				CmdShotit (gameObject, player);

				//Debug.Log ("well");
				//Debug.Log (player.name);
			}
			cooldown = cooldowntime;
		} else {
			CmdUnShowLaser ();
			line.enabled = false;
		}
		}

	[Command]
	void CmdShotit(GameObject fromplayer, string hitPlayer) {//GameObject hitPlayer) {
		//error here: fix
		//if (hitPlayer != null) {
			//var parent = hitPlayer.transform.parent.gameObject;
			//if (parent != null) {
				//if (parent.GetComponent<Health> () != null) {
					//parent.GetComponent<Health> ().TakeDamage (100);
				//} else {
		Debug.Log(hitPlayer);
		if (hitPlayer != null) {//.transform.parent.gameObject != null) {
			try {
				var gh = GameObject.FindGameObjectsWithTag(hitPlayer);
				foreach (GameObject h in gh) {
					//h.transform.parent.gameObject.GetComponent<Health> ().TakeDamage (100);
					try {
						h.GetComponent<Health> ().TakeDamage (100);
					} catch {
						Debug.Log("No Health script");
					}
				}

			} catch {
				Debug.Log ("Dammage not given");
			}
			//transform.parent.gameObject.GetComponent<Health> ().TakeDamage (100);
		} else {
			Debug.Log ("NOT A PLAYER");
			Debug.Log (hitPlayer);
		}
					//Debug.Log (hitPlayer.name);
				//}
			//}
		//}
	}

	void ShowLaser(Vector3 start, Vector3 end) {
			
			line.enabled = true;
			line.SetPosition (0, start);
			line.SetPosition (1, end);
	}

	void UnShowLaser() {
		line.enabled = false;
	}

	[Command]
	void CmdUnShowLaser () {
		RpcUnShowLaser ();
	}

	[ClientRpc]
	void RpcUnShowLaser() {
		UnShowLaser ();
	}


	[Command]
	void CmdShowLaser(Vector3 start, Vector3 end) {
		RpcShowLaser (start, end);
	}

	[ClientRpc]
	void RpcShowLaser(Vector3 start, Vector3 end) {
			ShowLaser (start, end);
		//line.enabled = false;
	}

}