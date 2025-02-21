//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;



public class Pendu_old : MonoBehaviour
{

    [SerializeField]
    private Image img;

    public Sprite[] list_sprite;
    public         int index = 0;
     


     
    //private IHMController IHM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        IHM = GetComponent<IHMController>();
        if(IHM.gameObject.CompareTag("result"))
        {
            img = IHM.gameObject.GetComponent<Image>();
        }
        */


        img = GetComponent<Image>();
        img.sprite = list_sprite[0];

    }

    // Update is called once per frame
    /*void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {     
            change_sprite();
        }
    }*/


    /*public void init()
    {
        img = GetComponent<Image>();
        //img.sprite = list_sprite[0];
    }*/

    public void change_sprite()
    {
         img.sprite = list_sprite[index++];
    }
}
