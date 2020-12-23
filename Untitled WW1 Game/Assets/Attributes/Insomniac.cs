using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insomniac : Attribute
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
		soldier.FatigueModifier = 1.2f;
	}

	//returns the name and description of the attribute
	public override string GetDescription()
	{
		return "Insomniac: This soldier will get fatigued more quickly.";        //should this be more flavor texty?
	}
}
