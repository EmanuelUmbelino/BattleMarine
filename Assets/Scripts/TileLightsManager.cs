﻿using UnityEngine;
using System.Collections;

public class TileLightsManager : MonoBehaviour {

	public static GameObject shipSelect;
    public static int nOnCol = 0;

	void Start () 
	{
		shipSelect = null;
	}

	void OnMouseEnter()
	{
		this.GetComponent<SpriteRenderer> ().color = Color.red;
		try{shipSelect.GetComponent<ShipSelectController>().SetPosition(this.transform.position);}catch{}
	}
	void OnMouseExit()
	{
		this.GetComponent<SpriteRenderer> ().color = Color.white;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        nOnCol++;
        print(nOnCol);
    }
    void OnCollisionExit2D(Collision2D col)
    {
        nOnCol--;
        print(nOnCol);
    }

}
