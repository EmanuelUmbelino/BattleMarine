using UnityEngine;
using System.Collections;

public class TileLightsManager : MonoBehaviour {


	void Start () 
	{
	}

	void OnMouseEnter()
	{
		this.GetComponent<SpriteRenderer> ().color = Color.red;
	}
	void OnMouseExit()
	{
		this.GetComponent<SpriteRenderer> ().color = Color.white;
	}


}
