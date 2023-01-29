using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider slider;

    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = 0;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

}