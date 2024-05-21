using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    
    private void Start()
    {
        slider.interactable = false; 
    }

    public void SetMaxMana(float mana)
    {
        slider.maxValue = mana;
        slider.value = 0;        
    }
    
    public void SetMana()
    {
        slider.value+=5;
    }
}
