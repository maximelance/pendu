/*
 gère l'affichage du pendu
*/

using UnityEngine;
using UnityEngine.UI;

namespace Assets.pendu
{

    public class Pendu : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public Sprite[] sprites;
        private int index = 0;

        private int spriteArrayLength;

        void Start()
        {
            image = GetComponent<Image>();
            image.sprite = sprites[0];
            spriteArrayLength = sprites.Length;

        }

        public void Init()
        {
            index = 0;
            image.sprite = sprites[index];
        }

        public void UpdateSprite()
        {
            image.sprite = sprites[++index];
        }

        public int Size()
        {
            return spriteArrayLength;
        }

    }
}