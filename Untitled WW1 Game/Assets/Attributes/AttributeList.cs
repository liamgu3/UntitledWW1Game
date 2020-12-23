using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttributeList : MonoBehaviour
{
	public Attribute[] attributeList;       //stores all available attributes

	public System.Random rng;		//used to give random attributes to soldiers

	private void Awake()
	{
		rng = new System.Random();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
