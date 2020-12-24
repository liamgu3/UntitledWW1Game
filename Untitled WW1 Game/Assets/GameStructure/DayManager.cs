using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DayManager : MonoBehaviour
{
	private int day;    //which day the game is on
	enum Location { FrontLine, RestCamp }
	Location currentLocation;
	public Soldier[] soldiers;	//list of active soldiers

	public GameObject dayUI;    //text displaying day
	private GameObject nextDayButton;

	private System.Random rng;

	// Start is called before the first frame update
	void Start()
    {
		day = 1;
		dayUI.GetComponent<Text>().text = "Day " + day;
		currentLocation = Location.RestCamp;

		nextDayButton = GameObject.Find("NextDayButton");
		nextDayButton.GetComponent<Button>().interactable = false;

		rng = new System.Random();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	//advances game to next day on button press
	public void NextDay()
	{
		day++;
		dayUI.GetComponent<Text>().text = "Day " + day;

		if (UnityEngine.Random.Range(0, 10) >= 6)   //event occurs 40% of days
		{
			GetComponent<EventList>().eventList[rng.Next(0, GetComponent<EventList>().eventList.Length)].TriggerEvent();    //chooses a random event to occur (might change to use weighted randomness later)
		}

		foreach (Soldier soldier in soldiers)	//updates all soldiers' stats on day change
		{
			soldier.StatsUpdate((int)currentLocation);
			soldier.NightGuard = false;
		}

		nextDayButton.GetComponent<Button>().interactable = false;  //disable next day button until all daily activites have been performed
	}

	public void AssignNightGuard()
	{
		foreach (Soldier soldier in soldiers)
		{
			soldier.NightGuardSelectActive = true;
		}
	}

	
}
