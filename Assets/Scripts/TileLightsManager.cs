using UnityEngine;
using System.Collections;

public class TileLightsManager : MonoBehaviour {

	public static GameObject shipSelect;
    public static int nOnCol = 0;

	void Start () 
	{
		shipSelect = null;
        nOnCol = 0;
	}
    // para setar a posicao do barco quando tiver selecionado e mudar a cor do tile
	void OnMouseEnter()
	{
		this.GetComponent<SpriteRenderer> ().color = Color.red;
        try { shipSelect.GetComponent<ShipSelectController>().SetPosition(this.transform.position); }
        catch { }
        // impedir de ir no player 2 quando estiver colocando o barco
        // nao trocar a cor no player 1 quando for sua rodada
	}
	void OnMouseExit()
	{
		this.GetComponent<SpriteRenderer> ().color = Color.white;
	}

    // para ver quantos tiles estao colidindo com o barco
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<ShipSelectController>().select != 2)
            nOnCol++;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        nOnCol--;
    }

}
