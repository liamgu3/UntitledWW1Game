using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("OnDrop");
		if (eventData.pointerDrag != null)		//snaps item to item slot
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y - 125f);  //hardcoded num might be bad
			eventData.pointerDrag.transform.parent = transform;		//makes item child of slot
		}
	}
}
