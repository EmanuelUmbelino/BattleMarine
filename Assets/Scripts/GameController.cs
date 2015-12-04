using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text feedBack;

	//minha jogada
    void MyTurn()
    {
        feedBack.text = "Your Turn";
        /*poder selecionar um tile do player 2
         * quando ele selecionar um, verificar se tem barco no php que salvou os tiles de cada barco
         * com barco: mostrar que atingiu um barco e pode jogar de novo
         * sem barco: mostrar que atingiu o mar e ir pra jogada do outro
         * mandar pro php onde atirou
         * mandar pro php que acabou a jogada
         * */
    }
}
