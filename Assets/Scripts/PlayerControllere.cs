using UnityEngine;
using UnityEngine.Networking;

public class PlayerControllere : NetworkBehaviour
{
	public Material theMaterial;
	public GameObject bulletPrefab;
	public GameObject bulletPrefab2;
	public Transform bulletSpawn;
	public Camera cameraa;
	public Camera camera2;
	public Camera AimCam;
	public Rigidbody rb;
	public float spacing = 0.01f;
	private Vector3 pos;
	public float speed = 0.001f;
	public Texture2D crosshairTexture;
	public Texture2D crosshairTextUnAim;
	public Rect position;
	public Rect positionw;
	public bool OriginalOn = true;
	public bool IsAiming = false;
	public bool isTeam1 = false;

	//public bool rightClick = false;

	void Update()
	{
		if (!isLocalPlayer)
		{
			enabled = false;
			cameraa.enabled = false;
			camera2.enabled = false;
			AimCam.enabled = false;
			//bulletPrefab = bulletprefab2;
			return;
		}



		Vector3 pos = new Vector3(0, 0, 0);
		if (Input.GetKey(KeyCode.A))
		{
			pos.x -= spacing;// * Time.deltaTime;
			//transform.Translate(-1 * p, 0, 0, Space.Self);
		}
		if (Input.GetKey(KeyCode.D))
		{
			pos.x += spacing;// * Time.deltaTime;
			//transform.Translate(1 * p, 0, 0, Space.Self);
		}
		if (Input.GetKey(KeyCode.W))
		{
			pos.z += spacing;// * Time.deltaTime;
			//transform.Translate(0, 0, 1 * p, Space.Self);
		}
		if (Input.GetKey(KeyCode.S))
		{
			pos.z -= spacing;// * Time.deltaTime;
			//transform.Translate(0, 0, -1 * p, Space.Self);
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Cursor.lockState = Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
		} else {
			Cursor.lockState =  Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		if (Input.GetMouseButton(1)) {
			AimCam.enabled = true;
			IsAiming = true;
			//speed = 0.0001f;
		} else {
			AimCam.enabled = false;
			IsAiming = false;
			//speed = 0.001f;
		}



		Vector3 v3 = transform.TransformDirection( pos );
		v3.y = 0;
		transform.localPosition += v3;
		//transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
		//Vector3 movement = transform.forward * w * speed * Time.deltaTime;
		//rb.MovePosition(rb.position + movement);
		//transform.Translate(0, 0, z);

		if (Input.GetMouseButtonDown(0))
		{
		CmdFire();
		}
	}


	// This [Command] code is called on the Client …
	// … but it is run on the Server!
	[Command]
	void CmdFire()
	{

		if (isTeam1) {
			var bullet = (GameObject)Instantiate(
				bulletPrefab,
				bulletSpawn.position,
				this.transform.rotation);
			
			bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 100;
			NetworkServer.Spawn (bullet);
			Destroy (bullet, 2.0f);
		} else {
			var bullet2 = (GameObject)Instantiate(
				bulletPrefab2,
				bulletSpawn.position,
				this.transform.rotation);

			bullet2.GetComponent<Rigidbody> ().velocity = bullet2.transform.forward * 100;
			NetworkServer.Spawn (bullet2);
			Destroy (bullet2, 2.0f);
		}
	}

	//public override void OnStartLocalPlayer ()
	//{//
	//	GetComponent<MeshRenderer>().material.color = Color.blue;
	//}

	void Start()
	{
		gameObject.tag = "Player" + netId;
		foreach(Transform t in transform)
		{
			if (gameObject.tag != "Main Camera") {
				t.gameObject.tag = "Player" + netId;
			}
		}
		if (gameObject.tag == "Player1" || gameObject.tag == "Player3" || gameObject.tag == "Player5" || gameObject.tag == "Player7" || gameObject.tag == "Player9" || gameObject.tag == "Player11" || gameObject.tag == "Player13") {
			isTeam1 = true;
			gameObject.layer = LayerMask.NameToLayer ("Team2");
		}

		if (isTeam1) {
			gameObject.GetComponent<Renderer> ().sharedMaterial = theMaterial;
			gameObject.GetComponent<Renderer> ().material = theMaterial;
			bulletPrefab = bulletPrefab2;
			gameObject.transform.position = new Vector3 (Random.Range(210, 290), 50, 140);
		} else {
			gameObject.transform.position = new Vector3 (Random.Range(210, 290), 50, 360);
		}
		cameraa.enabled = true;
		camera2.enabled = true;
		AimCam.enabled = false;
		position = new Rect((Screen.width - crosshairTexture.width/5) / 2, (Screen.height - crosshairTexture.height/5) /2, crosshairTexture.width/5, crosshairTexture.height/5);
		positionw = new Rect((Screen.width - crosshairTextUnAim.width/3) / 2, (Screen.height - crosshairTextUnAim.height/3) /2, crosshairTextUnAim.width/3, crosshairTextUnAim.height/3);
	}

	void OnGUI()
	{
		if(OriginalOn == true)
		{
			if (IsAiming == true) {
				GUI.DrawTexture (position, crosshairTexture);
			} else { 
				GUI.DrawTexture (positionw, crosshairTextUnAim);
			}
		}
	}


}