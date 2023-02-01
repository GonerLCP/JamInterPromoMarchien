using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour
{
    public Player doggo;
    public bool drogue;
    public Slider slider;

    private bool doublecheck = false;
    private bool failed = false;
    private float compteur = 0;

    public TextMeshProUGUI scoring;
    int score;

    public void Start()
    {
        //drogue = (Random.value > 0.5f);
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
                slider.maxValue = 300;
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
                    score = int.Parse(scoring.text) + 10;
                    scoring.text = score.ToString();
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
                    slider.maxValue = Random.Range(120, 211);
                    doublecheck = true;
                }
            }
        }


        if (!Input.GetMouseButton(0))
        {
            compteur = 0;
            if (slider.value >= (slider.maxValue - (slider.maxValue / 10))  && doublecheck && !failed)
            {
                print("masterclass jacob");
                score = int.Parse(scoring.text) + 50;
                scoring.text = score.ToString();
                gameObject.SetActive(false);
                ToolTipManager.instance.HideToopTip();
            }
        }
        
    }
}
