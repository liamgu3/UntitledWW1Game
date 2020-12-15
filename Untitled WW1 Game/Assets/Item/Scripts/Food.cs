using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Item
{
	public float value;		//amount of hunger given back to soldier
	
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void ApplyItem(GameObject soldier)
	{
		Debug.Log(soldier.GetComponent<Soldier>().name + "| Hunger: " + soldier.GetComponent<Soldier>().Hunger);
		soldier.GetComponent<Soldier>().Hunger += 20;
		Debug.Log(soldier.GetComponent<Soldier>().name + "| Hunger: " + soldier.GetComponent<Soldier>().Hunger);
		base.ApplyItem(soldier);
	}
}
