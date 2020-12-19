using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Soldier : MonoBehaviour, IDropHandler, IPointerDownHandler
{
	//core soldier stats
	private float health;
	private float morale;
	private float fatigue;
	private float hunger;
	//attribute variable once attribute exists
	//list of items once items exist
	public string name; //varaible might be changes later

	private bool nightGuardSelectActive;       //true when assign night guard button is pressed
	private bool nightGuard;               //true if selected as night guard
	private GameObject nightGuardIcon;

	//getting componenets
	//private Animator animator;
	private Image image;
	public Sprite[] sprites;
	private DayManager dayManager;
	private GameObject nextDayButton;


	#region Getter/Setters
	public float Health
	{
		get { return health; }
		set
		{
			if (value <= 0)
				health = -1;
			//else if (value > 100)
				//health = 100;
			else
				health = value;
		}
	}
	public float Morale
	{
		get { return morale; }
		set
		{
			if (value < 0)
				morale = 0;
			//else if (value > 100)
				//morale = 100;
			else
				morale = value;
		}
	}
	public float Fatigue
	{
		get { return fatigue; }
		set
		{
			if (value < 0)
				fatigue = 0;
			//else if (value > 100)
				//fatigue = 100;
			else
				fatigue = value;
		}
	}
	public float Hunger
	{
		get { return hunger; }
		set
		{
			if (value < 0)
				hunger = 0;
			//else if (value > 100)
				//hunger = 100;
			else
				hunger = value;
		}
	}

	public bool NightGuard
	{
		get { return nightGuard; }
		set
		{
			if (value == true)
			{
				nightGuard = true;
				nightGuardIcon.SetActive(true);
			}
			else
			{
				nightGuard = false;
				nightGuardIcon.SetActive(false);
			}
		}
	}

	public bool NightGuardSelectActive
	{
		get { return nightGuardSelectActive; }
		set
		{
			if (value == true)
			{
				nightGuardSelectActive = true;
				GetComponent<Image>().color = new Color(.5f, .5f, 1.0f, 1.0f);
			}
			else
			{
				nightGuardSelectActive = false;
				GetComponent<Image>().color = Color.white;
			}
		}
	}
	#endregion

	// Start is called before the first frame update
	void Start()
	{
		health = morale = fatigue = hunger = 100;
		//set name to random from preset list unless specified otherwise

		nightGuardSelectActive = false;
		nightGuard = false;
		nightGuardIcon = transform.Find("nightGuardIcon").gameObject;
		nightGuardIcon.SetActive(false);

		//animator = GetComponent<Animator>();
		image = GetComponent<Image>();
		AppearanceChange();
		dayManager = GameObject.Find("GameManager").GetComponent<DayManager>();
		nextDayButton = GameObject.Find("NextDayButton");

		PrintStatsToConsole();
	}

	// Update is called once per frame
	void Update()
	{

	}

	//adjusts soldiers stats based on other values when day changes
	public void StatsUpdate(int location)
	{
		//all stat changes temporary and subject to change
		if (location == 0)  //stat changes in rest camp
		{
			Health += 10;    //Health heals in rest camp
			Morale += 10;  //Morale improves in rest camp
			Fatigue += 10;   //fatigue reduces in rest camp
			Hunger += 10;   //hunger reduces in rest camp
		}
		else if (location == 1) //stat changes on front line
		{
			Health -= (.25f * (100 - fatigue)) + (.25f * (100 - hunger)) - 10;    //Health adjusted based on fatigue and hunger stats
			Morale -= (.25f * (100 - health)) - 10;  //Morale adjusted based on health
			if (nightGuard)	//add artillery later
				Fatigue -= 20;
			else
				Fatigue -= 5;
			Hunger -= 20;   //goes down each day, requires food to replenish
		}

		if (health > 100)
			health = 100;
		if (morale > 100)
			morale = 100;
		if (fatigue > 100)
			fatigue = 00;
		if (hunger > 100)
			hunger = 100;

		PrintStatsToConsole();
		AppearanceChange();
	}

	//prints soldier's name and stats in console
	public void PrintStatsToConsole()
	{
		Debug.Log(name + " | " + "Health: " + health + " Morale: " + morale + " Fatigue: " + fatigue + " Hunger: " + hunger);
	}

	//method for changing soldiers appearance based on stats
	private void AppearanceChange()
	{
		//animator.SetFloat("Health", health);
		//animator.SetFloat("Morale", morale);

		//0 = happy
		//1 = neutral
		//2 = sad
		//3 = sick
		//4 = dead

		if (health < 50f && health > 0f)
		{
			image.sprite = sprites[3];
		}
		else if (health <= 0f)
		{
			image.sprite = sprites[4];
		}
		else if (morale >= 67f)
		{
			image.sprite = sprites[0];
		}
		else if (morale < 67f && morale > 33f)
		{
			image.sprite = sprites[1];
		}
		else if (morale <= 33f)
		{
			image.sprite = sprites[2];
		}
	}

	//detects item drop on soldier
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("OnDrop");
		eventData.pointerDrag.GetComponent<Item>().ApplyItem(gameObject);
	}

	//performs appropriate methods when soldier is clicked
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("OnPointerDown");
		if (nightGuardSelectActive)
		{
			Debug.Log(name + " | Night Guard Assigned");
			foreach (Soldier soldier in dayManager.soldiers)
			{
				soldier.NightGuardSelectActive = false;	
				soldier.NightGuard = false;					//sets all other soldiers to not night guard
			}
			NightGuard = true;  //sets this guard to night guard
			nextDayButton.GetComponent<Button>().interactable = true;
		}
	}
}
