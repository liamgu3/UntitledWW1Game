using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEvent : MonoBehaviour
{
	protected GameObject eventSheet;

    // Start is called before the first frame update
    void Start()
    {
		GetEventSheet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//assigns gameobjects for ease of calling in sub classes
	protected void GetEventSheet()
	{
		eventSheet = GameObject.Find("GameManager").GetComponent<EventList>().eventSheet;
	}

	public void TriggerEvent()
	{
		GetEventSheet();
		ApplyEffects();
		ShowEventSheet();
	}

	//displays event sheet and edits text and title of event sheet
	public virtual void ShowEventSheet()
	{
		eventSheet.SetActive(true);
	}

	//closes event sheet
	public void CloseEventSheet()
	{
		GetEventSheet();
		eventSheet.SetActive(false);
	}

	//applies event effects
	public virtual void ApplyEffects()
	{ 
		
	}
}
