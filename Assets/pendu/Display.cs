/*
gère l'affichage des informations à transmettre à l'utilisateur
*/

using UnityEngine;

namespace Assets.pendu
{
    //[ExtensionOfNativeClass]
    public class Display : MonoBehaviour
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
            IHM.ToggleDebugInfo(state, "Mot à deviner : " + word);
            //        Console.WriteLine("Mot à deviner : " + word);
        }

        public void ShowStarting(int number)
        {
            IHM.ShowInfoMessage("Il vous reste " + number + " essais");
            IHM.ShowActionMessage("choississez une lettre");
        }


        public void ShowSubResult(char letter)
        {
            IHM.ShowInfoMessage("Félicitations, vous avez trouver la lettre:" + letter);
        }

        public void ShowAttempts(int number)
        {
            IHM.ShowInfoMessage("et non ... il vous reste : " + number + " essais");
        }


        public void ShowResult(bool isWordGuessed)
        {
            if (isWordGuessed)
            {
                IHM.ShowInfoMessage("Félicitations, vous avez deviné le mot !");
                IHM.ShowInfoMessage("rejouez ou quitter? (1 ou 0)");
                IHM.SetInputFieldText("");
            }
            else
            {
                IHM.ShowInfoMessage("Désolé, vous avez perdu.");
            }
        }

        public void ShowWord(string word)
        {
            IHM.ShowActionMessage(word);
        }

        public void UpdateImage()
        {
            //IHM.ShowNextPenduStep();
        }
    }

}