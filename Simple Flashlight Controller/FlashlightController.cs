using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    // READ ME
    /*
        Put this script inside the flashlight object. 
        Please don't forget to add one DIRECTIONAL LIGHT and AUDIO SOURCE to the flashlight.
     */


    [SerializeField] private Light flashLight;
    private AudioSource switchSound;
    private bool isFlashlightOpen = false;
    private float batteryHealth = 5;
    private int batteryCount = 3;

    private void Start()
    {
        switchSound = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOpen = !isFlashlightOpen; 
            switchSound.Play();
        }

        FlashLightInvensity();
        FlashLightHealth();
    }

    void FlashLightInvensity()
    {
        if (isFlashlightOpen)
        {
            if (flashLight.intensity < 10)
            {
                flashLight.intensity += 0.1f;
            }
        }
        else
        {
            if (flashLight.intensity > 0)
            {
                flashLight.intensity -= 0.1f;
            }
        }
    }

    void FlashLightHealth()
    {

        if (isFlashlightOpen)
        {
            batteryHealth -= Time.deltaTime;
            if (batteryHealth <= 0)
            {
                if (batteryCount > 0)
                {
                    batteryHealth = 5;
                    batteryCount--;
                }
                else
                {
                    isFlashlightOpen = false;
                }
            }
        }

    }
}
