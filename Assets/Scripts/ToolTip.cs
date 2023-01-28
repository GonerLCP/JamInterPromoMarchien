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
            slider.value = 0;
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
            slider.value += 1;

            if (slider.value == slider.maxValue)
            {
                if (!drogue)
                {
                    gameObject.SetActive(false);
                    ToolTipManager.instance.HideToopTip();
                }

                if(drogue && doublecheck && !failed)
                {
                    doggo.damagecontrol(1);
                    ToolTipManager.instance.HideToopTip();
                    failed = true;
                }

                if (drogue && !doublecheck)
                {
                    slider.value = 0;
                    slider.maxValue = Random.Range(450, 761);
                    doublecheck = true;
                }
            }
        }
    }
}
