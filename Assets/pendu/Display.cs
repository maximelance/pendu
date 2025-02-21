/*
gère l'affichage des informations à transmettre à l'utilisateur
*/


using System;
using UnityEngine;
using UnityEngine.UI;

//namespace MyProject
//{

//[ExtensionOfNativeClass]
public class Display :  MonoBehaviour
{
    private IHMController IHM;

  


    /*public Display(IHMController ihm)
    {
        IHMInstance = ihm;
    }*/

    void Start()
    {
        IHM = GetComponent<IHMController>();

    }

    public void ShowWordToFind(bool state, string word)
    {
        IHM.toggleDebugInfo(state, "Mot à deviner : " + word);
//        Console.WriteLine("Mot à deviner : " + word);
    }

     public void ShowStarting(int number)
    {
        IHM.showInfoMessage("Il vous reste " + number + " essais");
        IHM.showActionMessage("choississez une lettre");
    }

    
    public void ShowSubResult(char letter)
    {
        IHM.showInfoMessage("Félicitations, vous avez trouver la lettre:" + letter);
    }

    public void ShowAttempts(int number)
    {
        IHM.showInfoMessage("et non ... il vous reste : " + number + " essais");
    }


    public void ShowResult(bool isWordGuessed)
    {
        if (isWordGuessed)
        {
            IHM.showInfoMessage("Félicitations, vous avez deviné le mot !");
            IHM.showInfoMessage("rejouez ou quitter? (1 ou 0)");
            IHM.setInputFieldText("");
        }
        else
        {
            IHM.showInfoMessage("Désolé, vous avez perdu.");
        }

    }

    public void ShowWord(string word)
    {
        IHM.showActionMessage(word);
    }

    public void UpdateImage()
    {
         //IHM.ShowNextPenduStep();
    }
}

//}