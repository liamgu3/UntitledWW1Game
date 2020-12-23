using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public virtual void ApplyEffects(Soldier soldier)
	{ 
		
	}

	public virtual string GetDescription()
	{
		return "Error: Descriptions Not Found";
	}

	public virtual string GetName()
	{
		return gameObject.name;
	}
}
