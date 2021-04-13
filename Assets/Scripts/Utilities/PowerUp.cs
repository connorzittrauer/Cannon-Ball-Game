using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public Slider slider;
    public float launchForce = 0;
    public float timer = 0.0f;
    
    // Start is called before the first frame update
    
    void Update()
    {
        Power();
    }
    
    public void Power()
    {
        
        if (Input.GetMouseButton(0))
        {
            //Calculate the amount of time the button is held
            
            slider.value = 0;

            timer += Time.deltaTime * 10.0f;
            launchForce = timer;
            slider.value = launchForce;

            //20 is the launchforce limit
            if (launchForce > 20.0f)
            {
                launchForce = 20.0f;
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
    
            slider.value = 0;
        }
    }
}
