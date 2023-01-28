using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public Player doggo;
    public bool drogue;
    public Slider slider;

    private bool doublecheck = false;
    private bool failed = false;
    private float compteur = 0;

    public void Start()
    {
        drogue = (Random.value > 0.5f);
    }

    private void OnMouseEnter()
    {
        if (!failed)
        {
            ToolTipManager.instance.SetAndShowToolTip();
            print("enter");
            compteur = 0;
            slider.value = compteur;
            if (!doublecheck)
            {
                slider.maxValue = 1000;
            }
        }
    }

    private void OnMouseExit()
    {
        ToolTipManager.instance.HideToopTip();
        print("exit");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            compteur += 1;
            slider.value = compteur;
            print(compteur);

            if (slider.value == slider.maxValue)
            {
                if (!drogue)
                {
                    gameObject.SetActive(false);
                    compteur = 0;
                    ToolTipManager.instance.HideToopTip();
                }

                if(drogue && doublecheck && !failed)
                {
                    doggo.damagecontrol(1);
                    ToolTipManager.instance.HideToopTip();
                    compteur = 0;
                    failed = true;
                }

                if (drogue && !doublecheck)
                {
                    slider.value = 0;
                    compteur = 0;
                    slider.maxValue = Random.Range(450, 761);
                    doublecheck = true;
                }
            }
        }


        if (!Input.GetMouseButton(0))
        {
            compteur = 0;
            if (slider.value >= (slider.maxValue - (slider.maxValue / 10)) && doublecheck)
            {
                print("masterclass jacob");
                gameObject.SetActive(false);
                ToolTipManager.instance.HideToopTip();
            }
        }
        
    }
}
