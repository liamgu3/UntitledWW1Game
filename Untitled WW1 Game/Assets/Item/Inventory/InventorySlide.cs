using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private Animator inventoryAnimator;

	// Start is called before the first frame update
	void Start()
	{
		inventoryAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	//public void ToggleMenu()
	//{
	//	bool isHidden = sliding.GetBool("isHidden");
	//	sliding.SetBool("isHidden", !isHidden);
	//}

	private void OnMouseOver()
	{
		
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnPointerEnter");
		bool isHidden = inventoryAnimator.GetBool("isHidden");
		inventoryAnimator.SetBool("isHidden", !isHidden);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnPointerExit");
		bool isHidden = inventoryAnimator.GetBool("isHidden");
		inventoryAnimator.SetBool("isHidden", !isHidden);
	}
}
