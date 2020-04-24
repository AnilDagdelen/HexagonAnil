using UnityEngine;
using System.Collections;

public class PSColor : MonoBehaviour {

	void OnSetColor(Color color)
	{
		GetComponent<Renderer>().material.SetColor("_TintColor", color);
	}
	
	void OnGetColor(ColorPicker picker)
	{
		picker.NotifyColor(GetComponent<Renderer>().material.GetColor("_TintColor"));
	}
}
