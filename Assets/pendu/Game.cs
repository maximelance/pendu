/*
 gère le jeu et les interactions entre classes
*/

using System.Collections.Generic;
using UnityEngine;

namespace Assets.pendu
{

public class Game : MonoBehaviour
{
    public bool isDevOn = true;
    public GameObject panel;
    private IHMController IHM;
    private Pendu pendu;
    private Word word;
    private Player player;
    private AudioSource effect1;
    private AudioSource effect2;
    private AudioSource effect3;
    private List<string> stringList = new() { "Bonjour", "Salut", "Hello", "Hi", "Coucou", "Hola", "Ciao", "Hallo", "Ola", "Ahoj", "Hej" };

    void Start()
    {
        IHM = GetComponent<IHMController>();

        pendu = GameObject.Find("PanelPendu").GetComponent<Pendu>();
        // on aurait aussi pu définir un GameObject panel, assigner le pendu à panel dans unity et faire ici un appel à :
        //pendu = panel.GetComponent<Pendu>();

        effect1 = GameObject.Find("EFFECT1").GetComponent<AudioSource>();
        effect2 = GameObject.Find("EFFECT2").GetComponent<AudioSource>();
        effect3 = GameObject.Find("EFFECT3").GetComponent<AudioSource>();

        Persistence.instance.UpdateAudioMixer();

        Restart("1");
    }

    void Update()
    {
        GiveTip();
    }

    public void Process(string stringRecu)
    {
        effect1.Play();
        IHM.ShowSecondInfoMessage("");

        if (!word.IsWordGuessed() && player.HasAttemptsLeft())
        {
            bool letterFound = word.CheckUserLetter(stringRecu);
            if (letterFound)
            {
                if (player.AddGuessedLetter(word.GetGuessedLetter()))
                {
                    IHM.ShowSecondInfoMessage("Félicitations, vous avez trouvé une lettre correspondante: " + word.GetGuessedLetter());
                }
                else
                {
                    IHM.ShowSecondInfoMessage("Lettre : " + word.GetGuessedLetter() + " déja trouvée.");
                }
            }
            else
            {

                IHM.ShowSecondInfoMessage("Dommage, vous n'avez pas trouvé de lettre!");
                if (player.UpdateAttempsLeft(word.GetGuessedLetter()))
                {
                    pendu.UpdateSprite();
                }
            }
            IHM.SetInputFieldText("");
        }
        IHM.ShowResult(word.DisplayWord);

        if (word.IsWordGuessed())
        {
            effect3.Play();
            IHM.ShowInfoMessage("Félicitations, vous avez deviné le mot !");
            IHM.ShowSecondInfoMessage("rejouez ou quitter? (1 ou 0)");
            IHM.SetInputFieldText("");
            word.Clear();
        }
        else if (player.HasAttemptsLeft())
        {
            int number = player.NumberOfAttemptsLeft();
            IHM.ShowInfoMessage("il vous reste : " + number + " essais");
        }
        else
        {
            effect2.Play();
            IHM.ShowInfoMessage("Désolé, vous avez perdu.");
            IHM.ShowSecondInfoMessage("rejouez ou quitter? (1 ou 0)");
        }
        Restart(stringRecu);
    }

    void Restart(string choixRecu)
    {
        if (choixRecu == "0")
        {
            IHM.ShowInfoMessage("bye");
            IHM.ShowSecondInfoMessage("");
            word.Clear();
            Application.Quit();
        }
        else if (choixRecu == "1")
        {
            player = new Player(pendu.Size() - 1);
            pendu.Init();

            IHM.ShowInfoMessage("il vous reste " + player.NumberOfAttemptsLeft() + " essais");
            IHM.ShowSecondInfoMessage("");
            IHM.ShowActionMessage("choississez une lettre");

            System.Random random = new();
            int index = random.Next(stringList.Count);
            word = new Word(stringList[index]);
            IHM.ShowResult(word.DisplayWord);
        }
    }


    private void GiveTip()
    {
        if (isDevOn)
        {
            IHM.ToggleDebugInfo(true, "Mot à deviner : " + word.WordToGuess);
        }
        else
        {
            IHM.ToggleDebugInfo(false, "Mot à deviner : " + word.WordToGuess);
        }
    }

}

}