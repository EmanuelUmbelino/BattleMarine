using UnityEngine;
using System.Collections;

public class ShipSelectController : MonoBehaviour {

    /// <summary>
    /// Script to manager the ships selects.
    /// Scrpt para controlar os navios selecionados.
    /// </summary>

    // GameObject to represent the object father. 
    // O gameObject que representa o objeto pai.
    public GameObject father;

    // Proprite to detect the select type.
    // Propriedade para detectar o tipo de seleção.
	private int select;

    // possibilities of clicks.
    // Possibilidade de clicks.
    void OnMouseDown()
	{
		if(select.Equals(0))
		{
			this.GetComponent<SpriteRenderer> ().color = Color.blue;
			select = 1;
			TileLightsManager.shipSelect = this.gameObject;
		}
		else if (select.Equals(1)) 
		{
			this.GetComponent<SpriteRenderer> ().color = Color.green;
			select = 2;
			TileLightsManager.shipSelect = null;
		}
	}

    // Rotation modifiers.
    // Modificadores da rotação.
    void FixedUpdate()
	{
		if(select.Equals(1) && Input.GetAxis("Horizontal") > 0)
		{
			father.transform.rotation = new Quaternion(0,0,-90,90);
		}

		if(select.Equals(1) && Input.GetAxis("Horizontal") < 0)
		{
			father.transform.rotation = new Quaternion(0,0,0,0);
		}
	}

	public void SetPosition(Vector3 position)
	{
        if (select.Equals(1))
        { father.transform.position = position; }
	}
}
