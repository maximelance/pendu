using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pendu : MonoBehaviour
{
  [SerializeField]
    public Image img;

    public Sprite[] sprites;
    private         int index = 0;
     
     private int spriteArrayLength;


     
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
        img.sprite = sprites[0];

        spriteArrayLength = sprites.Length;

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

    public void UpdateSprite()
    {
         img.sprite = sprites[index++];
    }

    public int Size()
    {
        return spriteArrayLength;
    }
        
}
