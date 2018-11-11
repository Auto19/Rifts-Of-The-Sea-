using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator : MonoBehaviour {

	public GameObject Corral1;
	public GameObject Corral2;
	public GameObject Corral3;
	public GameObject Corral4;
	public GameObject Corral5;
	public GameObject Corral6;
	public GameObject Corral7;
	public GameObject Corral8;
	public GameObject Corral9;
	public GameObject Corral10;
	public GameObject manager;
	public GameObject Rift1;
	public bool Starting;
	private Vector3[] Transforms; 
	private int i = 0;
	private GameObject CorralInst;
	private GameObject RiftInst;



	// Use this for initialization
	void Start () {
		Starting = true;
		Transforms = new Vector3[7000];
	}

	void Update() {
		if (i > 6999) {
			Starting = false;
			enabled = false;
		}
		if(Starting==true) {
			SpawnRift ();
			while(i < 7000) {
				Spawn1Corral ();
			}
		}
	}

	void Spawn1Corral() {
		
		var which = Random.Range (1, 10);
		GameObject Corral = Corral1;


		if (which == 1) {
			Corral = Corral1;
		} else if (which == 2) {
			Corral = Corral2;
		} else if (which == 3) {
			Corral = Corral3;
		} else if (which == 4) {
			Corral = Corral4;
		} else if (which == 5) {
			Corral = Corral5;
		} else if (which == 6) {
			Corral = Corral6;
		} else if (which == 7) {
			Corral = Corral7;
		} else if (which == 8) {
			Corral = Corral8;
		} else if (which == 9) {
			Corral = Corral9;
		} else if (which == 10) {
			Corral = Corral10;
		}

		float YRot = Random.Range (0, 360);
		//float YRot = 0.0f;


		Vector3 Pos = new Vector3 (Random.Range (0, 1000), 0, Random.Range (0, 1000));

		//Quaternion pieceRotation;
		//pieceRotation = Quaternion.AngleAxis(YRot, Vector3.up);
		Pos.y = Terrain.activeTerrain.SampleHeight(Pos);
		Pos.y = Pos.y + 0.4f;
		
	
		CorralInst = (GameObject) Instantiate (Corral, Pos, Quaternion.Euler(0, YRot, 0), manager.transform);
		i = i + 1;
	}

	void SpawnRift() {
		GameObject Rift = Rift1;

		Vector3 PosRift = new Vector3 (Random.Range (0, 1000), 0, Random.Range (0, 1000));
		PosRift.y = Terrain.activeTerrain.SampleHeight(PosRift);
		PosRift.y = PosRift.y + 0.4f;

		float RiftYRot = Random.Range(0,270);

		RiftInst = (GameObject) Instantiate (Rift, PosRift, Quaternion.Euler(0, RiftYRot, 0), manager.transform);
		Transforms [i] = RiftInst.gameObject.transform.position;


	}
}
