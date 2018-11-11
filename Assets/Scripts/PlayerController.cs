using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	public float spacing = 0.01f;
	private Vector3 pos;
	public float speed = 0.001f;
	public Texture2D BackgroundPicture;
	public Rect positionw;

	public GameObject MainMenu;
	public GameObject ObjectivesMenu;
	public GameObject SurfaceMenu;
	public GameObject BasesMenu;
	public GameObject ShipMenu;
	public GameObject ExplorationMenu;
	public GameObject ResourceMenu;
	public GameObject CivilianMenu;
	public GameObject HunterMenu;
	public GameObject Panel;
	public GameObject Background;
	public GameObject Day;
	public GameObject DayNum;

	public bool IsInMainMenu;
	private bool IsInObjectivesMenu;
	private bool IsInSurfaceMenu;
	private bool IsInBasesMenu;
	private bool IsInShipMenu;
	private bool IsInExplorationMenu;
	private bool IsInResourceMenu;
	private bool IsInCivilianMenu;
	private bool IsInHunterMenu;

	public GameObject MoneyNum;

	public RawImage image;
	private int Money = 1000;


	//public bool rightClick = false;

	public void AddMoney(int amount) {
		Money = Money + amount;
		MoneyNum.GetComponent<Text>().text = "Money: " + Money.ToString();
	}

	public void SubtractMoney(int amount) {
		Money = Money - amount;
		MoneyNum.GetComponent<Text>().text = "Money: " + Money.ToString();
	}

	public int MoneyAmount() {
		return Money;
	}


	void Update()
	{



		if (transform.position.z > 940) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 940);
		}
		if (transform.position.x < 60) {
			transform.position = new Vector3 (60, transform.position.y, transform.position.z);
		} 
		if (transform.position.x > 940) {
			transform.position = new Vector3 (940, transform.position.y, transform.position.z);
		} 
		if (transform.position.z < 60) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 60);
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

	
		Vector3 v3 = transform.TransformDirection( pos );
		v3.y = 0;
		transform.localPosition += v3;
		//transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
		//Vector3 movement = transform.forward * w * speed * Time.deltaTime;
		//rb.MovePosition(rb.position + movement);
		//transform.Translate(0, 0, z);

	}

	void Start()
	{

		//Button.gameObject.SetActive (true);
		Color c = image.color;
		c.a = 0.5f;
		image.color = c;
		positionw = new Rect((Screen.width - BackgroundPicture.width/2) / 2, (Screen.height - BackgroundPicture.height/2) /2, BackgroundPicture.width/2, BackgroundPicture.height/2);

	}

	void TurnButtonsOff() {
		MainMenu.SetActive(false);
		ObjectivesMenu.SetActive(false);
		SurfaceMenu.SetActive(false);
		BasesMenu.SetActive(false);
		ShipMenu.SetActive(false);
		ExplorationMenu.SetActive(false);
		ResourceMenu.SetActive(false);
		CivilianMenu.SetActive(false);
		HunterMenu.SetActive(false);
		Day.SetActive (false);
		DayNum.SetActive (false);
	}
		

	public bool allowClick = true;
	void OnGUI() {
		

		if(allowClick==true) {
			if (IsInMainMenu == false) {
				if (Input.GetMouseButtonDown (1)) {
					//GUI.DrawTexture (positionw, BackgroundPicture);
					Background.SetActive (true);
					Panel.SetActive (true);
					MainMenu.SetActive (true);
					Day.SetActive (true);
					DayNum.SetActive (true);
					IsInMainMenu = true;
					allowClick = false;
				} 
			}
		} else {
			allowClick = true;
		}
	}

	public void SetMainMenu() {
		IsInMainMenu = false;
	}

}