/*
 gère le jeu et les interactions entre classes
*/
using System;
using System.Collections.Generic;

using UnityEngine;

//namespace MyProject
//{

public class Game : MonoBehaviour
{
    private IHMController IHM;
    private Pendu pendu;
    private Word word;
    private Player player;

    private List<string> stringList = new List<string> { "Bonjour", "Salut", "Hello", "Hi", "Coucou" };

    private int attemptsNumber = 9;

    public bool isDevOn = true;

    public GameObject panel;

    private AudioSource son;

    void Start()
    {
        IHM = GetComponent<IHMController>();
        //pendu = panel.GetComponent<Pendu>(); // il faut  assigner panel à pendu  dans unity> game

        pendu = GameObject.Find("PanelPendu").GetComponent<Pendu>();
        //pendu = GameObject.FindFirstObjectByType<Pendu>();

        son = GetComponent<AudioSource>();


        Restart("1");
    }

    void Update()
    {
        GiveTip();
    }


    public void Process(string stringRecu)
    {
        son.Play();
        IHM.showSecondInfoMessage("");

        if (!word.IsWordGuessed() && player.HasAttemptsLeft())
        {
            bool letterFound = word.CheckUserLetter(stringRecu);
            if (letterFound)
            {
                if (player.AddGuessedLetter(word.GetGuessedLetter()))
                {
                    IHM.showSecondInfoMessage("Félicitations, vous avez trouvé une lettre correspondante: " + word.GetGuessedLetter());
                }
                else
                {
                    IHM.showSecondInfoMessage("Lettre : " + word.GetGuessedLetter() + " déja trouvée.");
                }
            }
            else
            {
                IHM.showSecondInfoMessage("Dommage, vous n'avez pas trouvé de lettre!");
                if (player.UpdateAttempsLeft(word.GetGuessedLetter()))
                {
                    pendu.UpdateSprite();
                }
            }
            IHM.setInputFieldText("");
        }

        IHM.showResult(word.GetDisplayWord());


        if (word.IsWordGuessed())
        {
            IHM.showInfoMessage("Félicitations, vous avez deviné le mot !");
            IHM.showSecondInfoMessage("rejouez ou quitter? (1 ou 0)");
            IHM.setInputFieldText("");
        }
        else if (player.HasAttemptsLeft())
        {
            int number = player.NumberOfAttemptsLeft();
            IHM.showInfoMessage("il vous reste : " + number + " essais");
            //pendu.UpdateSprite();
        }
        else
        {
            IHM.showInfoMessage("Désolé, vous avez perdu.");
                        IHM.showSecondInfoMessage("rejouez ou quitter? (1 ou 0)");
            IHM.showSecondInfoMessage("");


        }
        Restart(stringRecu);
    }

    void Restart(string choixRecu)
    {
        if (choixRecu == "0")
        {
            IHM.showInfoMessage("bye");
            IHM.showSecondInfoMessage("");
            word.Clear();

            Application.Quit();
        }
        else if (choixRecu == "1")
        {
            player = new Player(pendu.Size());
            IHM.showInfoMessage("Il vous reste " + player.NumberOfAttemptsLeft() + " essais");
            IHM.showSecondInfoMessage("");
            IHM.showActionMessage("choississez une lettre");

            System.Random random = new();
            int index = random.Next(stringList.Count);
            word = new Word(stringList[index]);
        }
    }


    private void GiveTip()
    {
        if (isDevOn)
        {
            IHM.toggleDebugInfo(true, "Mot à deviner : " + word.GetGuessingWord());
        }
        else
        {
            IHM.toggleDebugInfo(false, "Mot à deviner : " + word.GetGuessingWord());
        }
    }

}

//}