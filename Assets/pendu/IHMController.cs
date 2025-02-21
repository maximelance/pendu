using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//namespace MyProject
//{

public class IHMController : MonoBehaviour {

    [SerializeField]
    private GameObject errorPanel;
    [SerializeField]
    private Text textError;
    

    [SerializeField]
    private Text textInfo;

    [SerializeField]
    private Text textInfo2;

    [SerializeField]
    private Text textAction;

    [SerializeField]
    private Text textFound;

    [SerializeField]
    private InputField userInput;

    [SerializeField]
    private Text debugInfo;

    [SerializeField]
    private Image result;

    public bool debugOn;

    //objet GAME pour gérer le traitement
    //private GameController game;

    private Game game_pendu;

	// Use this for initialization
	void Start () {
		//ajout pour Unity IHM 
        game_pendu = GetComponent<Game>();

        //debugInfo.gameObject.SetActive(false);
        errorPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		

        //only in debug mode
        /*if(debugOn){
            if(Input.GetKeyDown(KeyCode.E)){
                showErrorMessage("ERROR : ceci est un messge de dev");
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                showErrorMessage("il vous reste 6 essais - indice : $");
            }
        }*/
	}


    //method needed from GameController
    public void showErrorMessage(string message){
        errorPanel.SetActive(true);
        textError.text = message;
        StartCoroutine(waitAndClose(errorPanel));
    }

    IEnumerator waitAndClose(GameObject panelToClose){
        yield return new WaitForSeconds(2f);
        panelToClose.SetActive(false);
    }

    public void showInfoMessage(string message){
        textInfo.text = message;
    }
    public void showSecondInfoMessage(string message){
        textInfo2.text = message;
    }

    public void showActionMessage(string message)
    {
        textAction.text = message;
    }

    public void showResult(string message)
    {
        textFound.text = message;
    }

    public void toggleDebugInfo(bool state,string message){
        debugInfo.gameObject.SetActive(state);
        debugInfo.text = message;
    }

    public void setInputFieldText(string message){
        userInput.text = message;
        //userInput.GetComponent<Text>().text = message;
    }

    public void ShowWord(string message)
    {
        textInfo.text = message;
    }


    // methods called by IHM

    //called by OK button
    public void OnUserInputFieldValidate(){

        string inputValue = userInput.text;
        //Debug.Log("InputField value : " + inputValue);

        
        game_pendu.Process(inputValue);
        
    }

}

//}