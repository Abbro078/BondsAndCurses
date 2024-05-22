using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private GameObject settingsMenu;

    [SerializeField]
    private Button backButton;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(settingsMenu.activeSelf)
            {
                backButton.onClick.Invoke();
            }
        }
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
