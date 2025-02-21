using UnityEngine;

//namespace MyProject
//{
public class GameController : MonoBehaviour
{
    private IHMController IHM;

    int nbreEssais = 5;//

    //constante pour le restart
    const int essais = 5;
    const int range = 50;

    bool isWin = false;

    //bool isApplicationOn = true;

    int nbreChoisi;

    bool isError = false;
    int chiffreMystereRandom = 0;

    public bool isDevOn = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        IHM = GetComponent<IHMController>();

        restart("1");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkUserNumber(string stringRecu)
    {
        //while (nbreEssais >= 1 && !isWin)
        if (nbreEssais >= 1 && !isWin)
        {
            //demande un chiffre à l'utilisateur
            //Console.WriteLine("Entrez votre chiffre ...");
            IHM.showActionMessage("Entrez votre chiffre ...");
            //string stringRecu = Console.ReadLine(); //met en pause le programme et attend un input

            //int nbreChoisi = Convert.ToInt32(stringRecu);   //WARNING

            if (isNumeric(stringRecu))
            {
                //affichage console
                //Console.WriteLine("Vous avez choisi : " + nbreChoisi);
                //IHM.toggleDebugInfo(false, "Vous avez choisi : " + nbreChoisi);

                //on compare nbreChoisi avec chiffreMystereRandom

                //si c'est égal alors l'utilisateur a gagné
                //sinon il faut continuer à jouer
                if (nbreChoisi == chiffreMystereRandom)
                {
                    //Console.WriteLine("Vous avez gagné !!");
                    IHM.showInfoMessage("vous avez gagné !!");
                    IHM.showSecondInfoMessage("rejouez ou quitter? (1 ou 0)");
                    IHM.setInputFieldText("");
                    isWin = true;
                }
                else
                {
                    nbreEssais--;
                    IHM.showInfoMessage("et non ... il vous reste : " + nbreEssais + " essais - indice : " + giveIndice());
                    //Console.WriteLine("Rejouez ... il vous reste : " + nbreEssais + " essais ==> Indice : " + giveIndice());


                    if (nbreEssais == 0)
                    {
                        IHM.showInfoMessage("rejouez ou quitter? (1 ou 0)");
                        IHM.setInputFieldText("");
                    }

                }
            }
            else
            {
                IHM.showErrorMessage("Entrez des chiffres et pas des lettres ...");
                //Console.WriteLine("Entrez des chiffres et pas des lettres ...");
            }
        }
        else
        {

            IHM.showInfoMessage("Rejouez ou quitter? (1 ou 0)");
            IHM.setInputFieldText("");

            restart(stringRecu);
        }

    }

    void restart(string choixRecu)
    {
        if (choixRecu == "0")
        {
            //isApplicationOn = false;

            //unity
            Application.Quit();
        }
        else if (choixRecu == "1")
        {
            isWin = false;
            nbreEssais = essais;
            isError = false;

            IHM.showInfoMessage("Il vous reste " + nbreEssais + " essais");
            IHM.showActionMessage("choississez un nombre entre 0 et " + (range - 1));

            System.Random rnd = new();
            chiffreMystereRandom = rnd.Next(range);

            if (isDevOn)
            {
                //affichage du chiffre mystère
                IHM.toggleDebugInfo(true, "Le chiffre mystère est: " + chiffreMystereRandom);
            }
            else{
                IHM.toggleDebugInfo(false, "Le chiffre mystère est: " + chiffreMystereRandom);
            }
        }
        else
        {
            //showError("Entrez 0 ou 1 ...rien d'autre !!");
            //Console.WriteLine("Entrez 0 ou 1 ...rien d'autre !!");
            IHM.showErrorMessage("Entrez 0 ou 1 ...rien d'autre !!");
            isError = true;
        }

    }

    bool isNumeric(string value)
    {
        bool isNumeric = false;

        /* try
         {
             isNumeric = int.TryParse(value, out nbreChoisi);
         }
         catch (System.FormatException)
         {
             isNumeric = false;
         }*/

        isNumeric = int.TryParse(value, out nbreChoisi);

        return isNumeric;
    }

    string giveIndice()
    {
        if (chiffreMystereRandom > nbreChoisi)
        {
            return "$";
        }
        else
        {
            return "#";
        }
    }
}

//}