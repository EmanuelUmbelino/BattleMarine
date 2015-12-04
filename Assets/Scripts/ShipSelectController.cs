using UnityEngine;
using System.Collections;

public class ShipSelectController : MonoBehaviour {

	public GameObject father;

    private int select;
    private Vector3 movePosition;
    private Color myColor;

	void OnMouseDown()
	{
		if(select.Equals(0))
		{
            myColor = Color.blue;
			select = 1;
			TileLightsManager.shipSelect = this.gameObject;
		}
        else if (select.Equals(1) && TileLightsManager.nOnCol == (this.transform.localScale.y - 3) / 3 && movePosition == new Vector3(0,0,0)) 
		{
			myColor = Color.green;
			select = 2;
			TileLightsManager.shipSelect = null;
		}
	}

	void Update()
    {
        if (select.Equals(1))
        {
            if (TileLightsManager.nOnCol < (this.transform.localScale.y - 3) / 3)
            {
                myColor.a = 50;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                father.transform.rotation = new Quaternion(0, 0, -90, 90);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                father.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            this.GetComponent<SpriteRenderer>().color = myColor;
        }
        if (movePosition != new Vector3(0,0,0))
        {
            SetPosition(movePosition);
        }

	}
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
