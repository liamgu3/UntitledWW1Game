using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinBlooded : Attribute
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//applys any modifier effects to soldier
	public override void ApplyEffects(Soldier soldier)
	{
		soldier.HealthModifier = 1.2f;
	}

	//returns the name and description of the attribute
	public override string GetDescription()
	{
		return "Thin Blooded: This soldier will lose health more quickly.";        //should this be more flavor texty?
	}
}
