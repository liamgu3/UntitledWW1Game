﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{
	private int day;    //which day the game is on
	enum Location { FrontLine, RestCamp }
	Location currentLocation;
	public Soldier[] soldiers;	//list of active soldiers


	public GameObject dayUI;    //text displaying day
	private GameObject nextDayButton;

	// Start is called before the first frame update
	void Start()
    {
		day = 1;
		dayUI.GetComponent<Text>().text = "Day " + day;
		currentLocation = Location.RestCamp;

		nextDayButton = GameObject.Find("NextDayButton");
		nextDayButton.GetComponent<Button>().interactable = false;
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

		foreach (Soldier soldier in soldiers)	//updates all soldiers' stats on day change
		{
			soldier.StatsUpdate((int)currentLocation);
			soldier.NightGuard = false;
		}

		nextDayButton.GetComponent<Button>().interactable = false;	//disable next day button until all daily activites have been performed
	}

	public void AssignNightGuard()
	{
		foreach (Soldier soldier in soldiers)
		{
			soldier.NightGuardSelectActive = true;
		}
	}

	
}
