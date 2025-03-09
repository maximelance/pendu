/*
Permet de sauvegarder la valeurs des volumes des effets et de la musique dans les préférences utilisateur
*/

using UnityEngine;
using UnityEngine.UI;

namespace Assets.pendu
{

    public class VolumeSaver : MonoBehaviour
    {
        private Slider effetcSlider;
        private Slider musicSlider;

        public string effectParameter = "EffectVolume";
        public string musicParameter = "MusicVolume";

        void Start()
        {
            effetcSlider = GameObject.Find("SliderEffect").GetComponent<Slider>();
            effetcSlider.value = PlayerPrefs.GetFloat(effectParameter, 0.5f);
            effetcSlider.onValueChanged.AddListener((value) => SaveVolume(effectParameter, value));

            musicSlider = GameObject.Find("SliderMusic").GetComponent<Slider>();
            musicSlider.value = PlayerPrefs.GetFloat(musicParameter, 0.5f);
            musicSlider.onValueChanged.AddListener((value) => SaveVolume(musicParameter, value));
        }

        void SaveVolume(string parameter, float value)
        {
            PlayerPrefs.SetFloat(parameter, value);
            Persistence.instance.UpdateAudioMixer();
        }
    }
}