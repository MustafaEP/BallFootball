using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    Slider volumeSlider;

    void Start()
    {
        //Bellekte kayıtlımı kontrolü
        if(PlayerPrefs.HasKey("audioVolume"))
        {
            //Direk full ses başlattık
            PlayerPrefs.SetFloat("audioVolume", 1);
            Load();
        }
        else{
            Load();
        }
    }

    public void setVolume()
    {
        //Sliderdaki değeri AudioListener.volume ' e atayarak istediğimiz ses seviyesini seçtik
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("audioVolume");
        //bellekteki değeri Slidera geçirdik
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("audioVolume", volumeSlider.value);
        //Ayarları belleğe kaydettik
    }
}
