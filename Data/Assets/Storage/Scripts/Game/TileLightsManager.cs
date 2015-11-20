using UnityEngine;
using System.Collections;

public class TileLightsManager : MonoBehaviour {

    // Ship to selected.
    // Navio a ser selecionado.
	public static GameObject shipSelect;

    // Started the variable shipSelect.
    // Iniciando a variavel shipSelect.
	void Start () 
	{
		shipSelect = null;
	}

    // On mouse over through one tiled, there color will change to red.
    // Quando o mouse passar por um tiled, a cor dele vai mudar para vermelho.
    void OnMouseEnter()
	{
		this.GetComponent<SpriteRenderer> ().color = Color.red;
		shipSelect.GetComponent<ShipSelectController>().SetPosition(this.transform.position);
	}

    // On mouse exit the color will back to white.
    // Quando o mouse sair da range a cor voltará ao normal.
	void OnMouseExit()
	{
		this.GetComponent<SpriteRenderer> ().color = Color.white;
	}


}
