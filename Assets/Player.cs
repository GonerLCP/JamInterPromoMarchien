using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public bool updateldvalue;
    public float transparency = 0f;

    public Healthbar healthbar;
    public PostProcessingManager ppmanager;
    public Image effect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 0;
        healthbar.setMaxHealth(maxHealth);
        effect.color = new Color(1f,0.5f, 0.9f, transparency);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            damagecontrol(1);
        }
    }

    public void damagecontrol(int cocadelamama)
    {
        if (currentHealth < maxHealth)
        {
            Ilaprisdeladrogue(cocadelamama);
            updateldvalue = true;
            transparency += 0.05f;
        }
        effect.color = new Color(1f, 0.5f, 0.9f, transparency);
    }


    public void Ilaprisdeladrogue(int cocadelamama)
    {
        currentHealth += cocadelamama;
        healthbar.setHealth(currentHealth);

        float value = (float)currentHealth;
        ppmanager.caIntensity(value);
        ppmanager.blIntensity(value);
    }
}
