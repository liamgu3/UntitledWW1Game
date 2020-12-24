using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightBarrage : BaseEvent
{
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void ShowEventSheet()
	{
		eventSheet.transform.Find("Title").gameObject.GetComponent<Text>().text = "Night Barrage";
		eventSheet.transform.Find("Text").gameObject.GetComponent<Text>().text = "The Krauts were hitting us with artillery all night. No one got very much sleep.";    //this could probably be rewritten
		base.ShowEventSheet();
	}

	public override void ApplyEffects()
	{
		Soldier[] soldiers = GameObject.Find("GameManager").GetComponent<DayManager>().soldiers;

		foreach (Soldier soldier in soldiers)
		{
			if (!soldier.NightGuard)	//fatigues all soldiers extra except soldier who was already nightGuard
			{
				soldier.Fatigue -= 15;
			}
		}
	}
}
