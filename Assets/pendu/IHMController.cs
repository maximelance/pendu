using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.pendu
{
    public class IHMController : MonoBehaviour
    {
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

        private Game gamePendu;

        void Start()
        {
            //ajout pour Unity IHM 
            gamePendu = GetComponent<Game>();
            debugInfo.gameObject.SetActive(false);
        }

        void Update()
        {
            string inputValue = userInput.text;
            if (!string.IsNullOrWhiteSpace(inputValue) && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
            {
                gamePendu.Process(inputValue);
            }
        }

        //method needed from GameController
        public void ShowInfoMessage(string message)
        {
            textInfo.text = message;
        }
        public void ShowSecondInfoMessage(string message)
        {
            textInfo2.text = message;
        }

        public void ShowActionMessage(string message)
        {
            textAction.text = message;
        }

        public void ShowResult(string message)
        {
            textFound.text = message;
        }

        public void ToggleDebugInfo(bool state, string message)
        {
            debugInfo.gameObject.SetActive(state);
            debugInfo.text = message;
        }

        public void SetInputFieldText(string message)
        {
            userInput.text = message;
        }

        public void ShowWord(string message)
        {
            textInfo.text = message;
        }

        // methods called by IHM
        public void OnUserInputFieldValidate()
        {
            string inputValue = userInput.text;
            gamePendu.Process(inputValue);
        }

        public void ChangeScene()
        {
            SceneManager.LoadScene("SettingsPendu");
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}