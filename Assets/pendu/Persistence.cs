/*
 gère la persistence du son entre les scènes
*/

using UnityEngine;
using UnityEngine.Audio;

namespace Assets.pendu
{
    public class Persistence : MonoBehaviour
    {
        public static Persistence instance;
        public AudioMixer audioMixer;
        public string effectParameter = "EffectVolume";
        public string musicParameter = "MusicVolume";

        void Start()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void UpdateAudioMixer()
        {
            float effectVolume = PlayerPrefs.GetFloat(effectParameter, 0.5f);
            float musicVolume = PlayerPrefs.GetFloat(musicParameter, 0.5f);

            float effectDB = Mathf.Lerp(-80f, 20f, effectVolume);
            float musicDB = Mathf.Lerp(-80f, 20f, musicVolume);

            audioMixer.SetFloat(effectParameter, effectDB);
            audioMixer.SetFloat(musicParameter, musicDB);
        }
    }
}
