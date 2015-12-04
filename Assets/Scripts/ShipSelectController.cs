using UnityEngine;
using System.Collections;

public class ShipSelectController : MonoBehaviour {

	public GameObject father;
    public int select;

    private Vector3 movePosition;
    private Color myColor;
  
	void OnMouseDown()
	{
        //quando clicar para mudar a posição
		if(select.Equals(0))
		{
            myColor = Color.blue;
			select = 1;
            TileLightsManager.shipSelect = this.gameObject;
            this.GetComponent<SpriteRenderer>().color = myColor;
		}
        //quando  clicar para setar a posição
        else if (select.Equals(1) && TileLightsManager.nOnCol == (this.transform.localScale.y - 3) / 3 && movePosition == new Vector3(0,0,0)) 
		{
            myColor = Color.green;
            this.GetComponent<SpriteRenderer>().color = myColor;
			select = 2;
            TileLightsManager.shipSelect = null;
            TileLightsManager.nOnCol = 0;
            // colocar pra salvar os tiles que estao na posicao dele no php
            // verificar se ja tem um barco no local
		}
	}

	void Update()
    {
        //se ele tiver selecionado e tentar virar o barco
        if (select.Equals(1))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                father.transform.rotation = new Quaternion(0, 0, -90, 90);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                father.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        //para continuar o movimento em direcao ao tile caso n tenha chegado
        if (movePosition != new Vector3(0,0,0))
        {
            SetPosition(movePosition);
        }

	}
    // setar a posicao do barco em direcao ao tile
    public void SetPosition(Vector3 position)
    {
        if (father.transform.position != position)
        {
            father.transform.position = Vector3.Lerp(father.transform.position, position, 0.05f);
            movePosition = position;
        }
        if (Vector3.Distance(father.transform.position, position) < 0.05)
        {
            movePosition = new Vector3(0,0,0);
        }
    }
}
