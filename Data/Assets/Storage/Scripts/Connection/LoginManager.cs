using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour {

    // This will change when the mysql/php connection was ready...
    // Isso vai mudar quando houver uma conexão com um banco de dados mysql, por enquanto "root" será o único usário registrado... 
    private const string login = "root";
    private const string pass = "";

    // Variables to the login proprietes.
    [SerializeField]
    private InputField userFiled = null;
    [SerializeField]
    private InputField passFiled = null;
    [SerializeField]
    private Text feedBackMenssager = null;
    [SerializeField]
    private Toggle rememberData = null;

    // Config the playerPrefs, on toggle "rememberData" is on is necessary save the varibles.
    // Configurando o playerPrefs, quando o toggle "rememberData" estiver ativo será necessario salvar as informações.
    void Start ()
    {
        if(PlayerPrefs.HasKey("remember") && PlayerPrefs.GetInt("remember") == 1)
        {
            userFiled.text = PlayerPrefs.GetString("rememberLogin");
            passFiled.text = PlayerPrefs.GetString("rememberPass");
        }
    }

    // Method to do the login system.
    // Método para fazer o sistema de login.
    public void DoLogin()
    {
        string user = userFiled.text;
        string passw = passFiled.text;

        if(rememberData.isOn)
        {
            PlayerPrefs.SetInt("remember", 1);
            PlayerPrefs.SetString("rememberLogin", user);
            PlayerPrefs.SetString("rememberPass", passw);
        }

        // Conditions for login enable and login desable.
        // Condições para caso o login ocorra ou não ocorra.
        if(user.Equals(login) && pass.Equals(pass))
        {
            feedBackMenssager.CrossFadeAlpha(100f, 0f, false);
            feedBackMenssager.color = Color.green;
            feedBackMenssager.text = "Login Concluded";
            StartCoroutine(ChangeScene(1));
        } else {
            feedBackMenssager.CrossFadeAlpha(100f, 0f, false);
            feedBackMenssager.color = Color.red;
            feedBackMenssager.text = "Login Failed";
            userFiled.text = "";
            passFiled.text = "";
            Debug.Log("O Login foi mal sucedido");
        }

    }

    public IEnumerator ChangeScene(int scene)
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(scene);
    }
}
