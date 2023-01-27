using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostProcessingManager : MonoBehaviour
{
    private PostProcessVolume _ppvolume;
    private ChromaticAberration _ca;
    private Bloom _bl;
    private LensDistortion _ld;
    public Player player;

    float maxintensity = 0f;
    float maxX = 0f;
    float maxY = 0;

    float intensity = 0f;
    float dintensity = 0.1f;
    float dintensity0 = 0.1f;

    float x = 0;
    float y = 0;
    float dx0 = 0.01f;
    float dy0 = 0.025f;
    float dx = 0.01f;
    float dy = 0.025f;

    float timer = 0f;

    private void Start()
    {
        _ppvolume = GetComponent<PostProcessVolume>();
        _ppvolume.profile.TryGetSettings(out _ca);
        _ppvolume.profile.TryGetSettings(out _bl);
        _ppvolume.profile.TryGetSettings(out _ld);
    }



    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.016) 
        {
            ldmove();
            timer = 0f;
        }

    }

    public void caIntensity(float value)
    {
        value = value / 5;
        _ca.intensity.value = value;
    }

    public void blIntensity(float value)
    {
        value = value / (float)2.5;
        _bl.intensity.value = value;
    }

    public void ldmove()
    {
        if (player.updateldvalue == true)
        {
            int health = player.currentHealth;


            maxintensity = (float) health * 10;
            maxX = (float) health / 10;
            maxY = (float) health / 20;

            player.updateldvalue = false;
        }

        if((Mathf.Abs(maxintensity) - Mathf.Abs(intensity)) >= 0.1)
        {
            dintensity = dintensity0 * (Mathf.Abs(maxintensity) - Mathf.Abs(intensity));
        }

        if((Mathf.Abs(maxX) - Mathf.Abs(x)) >= 0.1)
        {
            dx = dx0 * (Mathf.Abs(maxX) - Mathf.Abs(x));
        }

        if((Mathf.Abs(maxY) - Mathf.Abs(y)) >= 0.1)
        {
            dy = dy0 * (Mathf.Abs(maxY) - Mathf.Abs(y));
        }
        

        if (intensity >= maxintensity || intensity <= -maxintensity)
        {
            dintensity *= -1;
            dintensity0 *= -1;
        }

        intensity += dintensity;
        _ld.intensity.value = intensity;


        if (x >= maxX || x <= -maxX)
        {
            dx *= -1;
            dx0 *= -1;
        }

        x += dx;
        _ld.centerX.value = x;

        if (y >= maxY || y <= maxY)
        {
            dy *= -1;
            dy0 *= -1;
        }


        y += dy;
        _ld.centerY.value = y; 

    }

}
